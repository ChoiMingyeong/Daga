using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace DagaDB.DB
{
    [Table("test")]
    public class TestTable
    {
        [Key]
        [Column("id")]
        public uint Id { get; set; }

        [Calculator]
        [Column("value")]
        public int Value { get; set; }
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = false)]
    public class CalculatorAttribute : Attribute
    {
    }

    public static class CalculatorHelper
    {
        /// <summary>
        /// <see cref="typeof(T)"/>가 숫자타입일 때, target의 값을 source의 값과 합산합니다.
        /// </summary>
        /// <exception cref="ArgumentNullException">target이나 source가 null이면 발생</exception>
        public static void AddProperties<T>(T target, T source)
        {
            if (target == null || source == null)
            {
                throw new ArgumentNullException();
            }

            // T 타입의 속성(Property) 중 CalculatorAttribute가 붙은 속성만 가져오기
            var properties = typeof(T).GetProperties().Where(p => p.GetCustomAttribute<CalculatorAttribute>() != null);

            foreach (var prop in properties)
            {
                MergeNumericProperties(target, source);
            }
        }

        public static void MergeNumericProperties<T>(T target, T source)
        {
            if (target == null || source == null)
            {
                throw new ArgumentNullException();
            }

            foreach (var prop in typeof(T).GetProperties())
            {
                if (!prop.CanRead || !prop.CanWrite || prop.GetCustomAttribute<CalculatorAttribute>() == null)
                {
                    continue;
                }

                if (IsNumericType(prop.PropertyType))
                {
                    var targetValue = Convert.ToDouble(prop.GetValue(target) ?? 0);
                    var sourceValue = Convert.ToDouble(prop.GetValue(source) ?? 0);
                    prop.SetValue(target, Convert.ChangeType(targetValue + sourceValue, prop.PropertyType));
                }
            }
        }

        private static bool IsNumericType(Type type)
        {
            return type == typeof(byte) || type == typeof(sbyte) ||
                   type == typeof(short) || type == typeof(ushort) ||
                   type == typeof(int) || type == typeof(uint) ||
                   type == typeof(long) || type == typeof(ulong) ||
                   type == typeof(float) || type == typeof(double) ||
                   type == typeof(decimal);
        }
    }

    public class CalculatorTest
    {
        public readonly Dictionary<object, TestTable> Entities = [];

        public static object? GetKey<T>(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var type = typeof(T);
            var keyProperties = type.GetProperties()
                                    .Where(p => p.GetCustomAttribute<KeyAttribute>() != null)
                                    .ToArray();

            if (keyProperties.Length == 0)
                throw new InvalidOperationException($"클래스 {type.Name}에 [Key] 속성이 없습니다.");

            // 단일 키일 경우, 해당 값 반환
            if (keyProperties.Length == 1)
            {
                return keyProperties[0].GetValue(entity);
            }

            // 복합 키일 경우, Tuple 생성
            return Tuple.Create(keyProperties.Select(p => p.GetValue(entity)).ToArray());
        }

        public bool AddEntity(TestTable addEntity)
        {
            if(GetKey(addEntity) is not object key)
            {
                return false;
            }

            if (Entities.TryGetValue(key, out var originEntity))
            {
                CalculatorHelper.AddProperties(originEntity, addEntity);
            }
            else
            {
                Entities.Add(key, addEntity);
            }

            return true;
        }
    }

    public class EntityUpdateCollector<DBContext> where DBContext : DbContext
    {
        private readonly DBContext _dbContext;

        public EntityUpdateCollector(in DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Key: <see cref="EntityType"/><br/>
        /// Value: Entitiy List<br/>
        /// </summary>
        Dictionary<EntityType, object> _todoList = [];

        public void UpsertEntities<T>(IEnumerable<T> upsertEntities)
        {
            var entityType = _dbContext.Model.FindEntityType(typeof(T));
            if (null == entityType)
            {
                return;
            }

            var pk = entityType.FindPrimaryKey();
            if (null == pk)
            {
                return;
            }
        }

    }
}
