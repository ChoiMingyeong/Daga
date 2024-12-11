namespace DagaHub.Identifiers
{
    public class CharacterID
    {
        public ushort Value { get; set; }

        public CharacterID(ushort value)
        {
            Value = value;
        }

        public static implicit operator CharacterID(ushort value)
        {
            return new CharacterID(value);
        }

        public static explicit operator ushort(CharacterID value)
        {
            return value.Value;
        }
    }
}
