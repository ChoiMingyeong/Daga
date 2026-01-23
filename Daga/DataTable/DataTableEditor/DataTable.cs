namespace DataTableEditor.Core
{
    public partial class DataTable
    {

        public ID ProjectId { get; set; }

        public ID Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public 
    }

    public interface IDefaultInfo
    {
        ID Id { get; set; }

        string Name { get; set; }

        string Description { get; set; }
    }
}
