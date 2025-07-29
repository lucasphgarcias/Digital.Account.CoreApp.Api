namespace Domain.ValueObjects
{
    public class Name
    {
        public string Value { get; private set; }

        public Name(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Name cannot be null or empty");

            if (value.Length < 2)
                throw new ArgumentException("Name must have at least 2 characters");

            if (value.Length > 100)
                throw new ArgumentException("Name cannot exceed 100 characters");

            Value = value.Trim();
        }

        public override string ToString()
        {
            return Value;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Name other)
                return Value.Equals(other.Value);
            return false;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public static implicit operator string(Name name) => name.Value;
        public static explicit operator Name(string value) => new Name(value);
    }
} 