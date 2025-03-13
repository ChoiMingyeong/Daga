namespace DagaCommon.Models
{
    public class Role
    {
        public readonly static Role Guest = new(0, nameof(Guest))
        {
            Description = "Guest",
        };

        public readonly static Role Admin = new(1, nameof(Admin))
        {
            Description = "Admin",
        };

        public ushort ID { get; init; }

        private string _name = string.Empty;
        public string Name
        {
            get
            {
                return _name;
            }
            private set
            {
                _name = value.ToLower();
            }
        }

        public string Description { get; private set; } = string.Empty;

        public Role(ushort id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}
