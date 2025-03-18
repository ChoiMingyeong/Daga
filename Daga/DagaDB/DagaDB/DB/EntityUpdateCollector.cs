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

        [Column("value")]
        public int Value { get; set; }
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
            if(null == entityType)
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
