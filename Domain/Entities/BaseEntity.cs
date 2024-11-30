using Microsoft.AspNetCore.Identity;

namespace Core.Entities
{
    public abstract class BaseEntity: IdentityUser<int>
    {
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
