namespace DagaCommon.Models
{
    public class Account
    {
        public uint ID { get; set; }

        public string Name { get; set; } = string.Empty;

        public List<Project> Projects { get; set; } = [];
    }
}
