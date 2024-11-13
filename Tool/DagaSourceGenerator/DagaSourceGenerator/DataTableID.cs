namespace DagaSourceGenerator
{
    public class DataTableID
    {
        private uint Value { get; set; } = 0;

        public static implicit operator DataTableID(uint value)
        {
            return new() { Value = value };
        }

        public static implicit operator DataTableID(int value)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(value);
            return new DataTableID() { Value = (uint)value };
        }

        public static implicit operator uint(DataTableID value)
        {
            return value.Value;
        }

        public static implicit operator int(DataTableID value)
        {
            ArgumentOutOfRangeException.ThrowIfGreaterThan(value.Value, (uint)int.MaxValue);
            return (int)value.Value;
        }
    }
}
