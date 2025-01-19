using System.Data;

namespace DagaDataGenerator.SrcGenerator.DataTable
{
    public class DataTableEntity : IEntity
    {
        public readonly uint DataTableID;

        public DataTableEntity(uint tableID)
        {
            DataTableID = tableID;
        }
    }
}
