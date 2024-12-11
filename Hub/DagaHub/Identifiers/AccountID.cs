namespace DagaHub.Identifiers
{
    public class AccountID
    {
        public uint Value { get; set; }

        public AccountID(uint value)
        {
            Value = value;
        }

        public static implicit operator AccountID(uint value)
        {
            return new AccountID(value);
        }

        public static explicit operator uint(AccountID value)
        {
            return value.Value;
        }
    }
}
