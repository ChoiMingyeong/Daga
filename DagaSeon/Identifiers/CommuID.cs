namespace DagaSeon.Identifiers
{
    public class CommuID
    {
        public ulong Value { get; set; }

        public CommuID(ulong value)
        {
            Value = value;
        }

        public static implicit operator CommuID(ulong value)
        {
            return new CommuID(value);
        }

        public static explicit operator ulong(CommuID value)
        {
            return value.Value;
        }
    }
}
