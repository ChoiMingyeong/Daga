namespace DagaDataTableEditor
{
    public readonly record struct Id<T>(uint Value) : IComparable<Id<T>>
    {
        public static Id<T> Empty => new(0);

        public bool IsValid => Value > 0;

        public override string ToString() => $"{typeof(T).Name}#{Value}";

        public int CompareTo(Id<T> other) => Value.CompareTo(other.Value);

        public static implicit operator uint(Id<T> id) => id.Value;

        public static implicit operator Id<T>(uint value) => new(value);
    }
}
