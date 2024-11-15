namespace DagaSourceGenerator
{
    public class Uid
    {
        private uint Value { get; set; } = 0;

        public static implicit operator Uid(uint value)
        {
            return new() { Value = value };
        }

        public static implicit operator Uid(int value)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(value);
            return new Uid() { Value = (uint)value };
        }

        public static implicit operator uint(Uid value)
        {
            return value.Value;
        }

        public static implicit operator int(Uid value)
        {
            ArgumentOutOfRangeException.ThrowIfGreaterThan(value.Value, (uint)int.MaxValue);
            return (int)value.Value;
        }
    }
}
