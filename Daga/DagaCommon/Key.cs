namespace DagaCommon
{
    public class Key
    {
        public object?[] KeyValues { get; }

        public Key(params object?[] keyValues)
        {
            KeyValues = keyValues ?? throw new ArgumentNullException(nameof(keyValues));
        }

        public override bool Equals(object? obj)
        {
            if (obj is Key otherKey)
            {
                return KeyValues.SequenceEqual(otherKey.KeyValues);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(KeyValues);
        }

        public override string ToString()
        {
            return string.Join(",", KeyValues);
        }
    }
}
