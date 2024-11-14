namespace DagaSourceGenerator
{
    public class UID
    {
        private uint Value { get; set; } = 0;

        public static implicit operator UID(uint value)
        {
            return new() { Value = value };
        }

        public static implicit operator UID(int value)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(value);
            return new UID() { Value = (uint)value };
        }

        public static implicit operator uint(UID value)
        {
            return value.Value;
        }

        public static implicit operator int(UID value)
        {
            ArgumentOutOfRangeException.ThrowIfGreaterThan(value.Value, (uint)int.MaxValue);
            return (int)value.Value;
        }
    }
}
