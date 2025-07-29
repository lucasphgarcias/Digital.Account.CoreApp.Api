using System.Text.RegularExpressions;

namespace Domain.ValueObjects
{
    public class Email
    {
        public string Value { get; private set; }

        public Email(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Email cannot be null or empty");

            if (!IsValidEmail(value))
                throw new ArgumentException("Invalid email format");

            Value = value.Trim().ToLower();
        }

        private static bool IsValidEmail(string email)
        {
            try
            {
                var regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
                return regex.IsMatch(email);
            }
            catch
            {
                return false;
            }
        }

        public override string ToString()
        {
            return Value;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Email other)
                return Value.Equals(other.Value);
            return false;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public static implicit operator string(Email email) => email.Value;
        public static explicit operator Email(string value) => new Email(value);
    }
} 