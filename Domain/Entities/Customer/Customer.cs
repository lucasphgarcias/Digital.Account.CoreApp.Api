using Domain.ValueObjects;

namespace Domain.Entities
{
    public partial class Customer
    {
        public Guid Id { get; private set; }
        public Name Name { get; private set; }
        public Email Email { get; private set; }
        public Document Document { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public bool IsActive { get; private set; }

        private readonly List<string> _notifications = new();

        public Customer(Name name, Email email, Document document)
        {
            ValidateCustomer(name, email, document);
            
            if (HasNotifications())
                throw new InvalidOperationException(string.Join(", ", _notifications));

            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            Document = document;
            CreatedAt = DateTime.UtcNow;
            IsActive = true;
        }

        private void ValidateCustomer(Name name, Email email, Document document)
        {
            if (name == null)
                AddNotification("Name cannot be null");
            
            if (email == null)
                AddNotification("Email cannot be null");
            
            if (document == null)
                AddNotification("Document cannot be null");
        }

        public void Update(Name name, Email email, Document document)
        {
            ValidateCustomer(name, email, document);
            
            if (HasNotifications())
                return;

            Name = name;
            Email = email;
            Document = document;
            UpdatedAt = DateTime.UtcNow;
        }

        public void Deactivate()
        {
            IsActive = false;
            UpdatedAt = DateTime.UtcNow;
        }

        public void Activate()
        {
            IsActive = true;
            UpdatedAt = DateTime.UtcNow;
        }

        private void AddNotification(string message)
        {
            _notifications.Add(message);
        }

        public bool HasNotifications()
        {
            return _notifications.Any();
        }

        public IReadOnlyList<string> Notifications => _notifications.AsReadOnly();
    }
} 