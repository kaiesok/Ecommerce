using Core.Entities.Enum;

namespace Core.Entities
{
    public class User : BaseEntity 
    {    
        public int Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
        public UserRole Role { get; set; } // "Admin" ou "User"
        public DateTime PasswordLastUpdated { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

     

        public bool IsPasswordExpired() => (DateTime.UtcNow - PasswordLastUpdated).TotalDays > 90;
    }
}
