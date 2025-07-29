using System.Text.RegularExpressions;

namespace Domain.ValueObjects
{
    public class Document
    {
        public string Value { get; private set; }

        public Document(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Document cannot be null or empty");

            var cleanValue = CleanDocument(value);
            
            if (!IsValidDocument(cleanValue))
                throw new ArgumentException("Invalid document format");

            Value = cleanValue;
        }

        private static string CleanDocument(string document)
        {
            return Regex.Replace(document, @"[^\d]", "");
        }

        private static bool IsValidDocument(string document)
        {
            // Basic validation for Brazilian CPF/CNPJ
            if (document.Length != 11 && document.Length != 14)
                return false;

            // Additional validation can be added here
            return true;
        }

        public override string ToString()
        {
            return Value;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Document other)
                return Value.Equals(other.Value);
            return false;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public static implicit operator string(Document document) => document.Value;
        public static explicit operator Document(string value) => new Document(value);
    }
} 