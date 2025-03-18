using DagaCommon;
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

        [Calculate]
        [Column("value")]
        public int Value { get; set; }

        [Calculate]
        [Column("value2")]
        public int Value2 { get; set; } = 0;
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
