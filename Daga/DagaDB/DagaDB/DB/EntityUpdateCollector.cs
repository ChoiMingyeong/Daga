using DagaCommon;
using DagaCommon.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Calculate]
        [Column("value3")]
        public string Value3 { get; set; } = string.Empty;
    }

    public class CalculatorTest
    {
        public readonly Dictionary<object, TestTable> Entities = [];

        public bool AddEntity(TestTable addEntity)
        {
            if(CommonUtility.GetOrAddKey(addEntity) is not object key)
            {
                return false;
            }

            if (Entities.TryGetValue(key, out var originEntity))
            {
                CommonUtility.MergeProperties(originEntity, addEntity);
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
