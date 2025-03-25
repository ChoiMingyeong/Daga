namespace DagaCommon.Enums
{
    [Flags]
    public enum Privileges : byte
    {
        Create  = 1 << 0,
        Read    = 1 << 1,
        Update  = 1 << 2,
        Delete  = 1 << 3,
    }
}
