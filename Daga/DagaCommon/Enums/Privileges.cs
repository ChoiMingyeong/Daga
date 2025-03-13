namespace DagaCommon.Enums
{
    public enum Privileges
    {
        Select = 1 << 0,    // 0001
        Insert = 1 << 1,    // 0010
        Update = 1 << 2,    // 0100
        Delete = 1 << 3,    // 1000
    }
}
