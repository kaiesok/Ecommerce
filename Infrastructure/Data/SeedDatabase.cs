using Core.Entities;
using Core.Entities.Enum;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Data
{
    public static class SeedDatabase
    {
        public static async Task Seed(AppDbContext context, IPasswordHasher<User> passwordHasher)
        {
            if (!context.Users.Any())
            {
                var adminUser = new User
                {
                    FirstName = "Oukhay",
                    LastName = "Kaies",
                    Email = "okkaiess@gmail.com",
                    PhoneNumber = "0123456789",
                    Role = UserRole.Admin,
                    PasswordLastUpdated = DateTime.UtcNow
                };

                adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "Admin");

                context.Users.Add(adminUser);
                await context.SaveChangesAsync();
            }
        }
    }
}
