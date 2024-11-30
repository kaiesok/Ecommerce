using Core.DTOs;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _dbContext;
        private readonly IPasswordHasher<User> _passwordHasher;

        public UserService(AppDbContext dbContext, IPasswordHasher<User> passwordHasher)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _passwordHasher = passwordHasher ?? throw new ArgumentNullException(nameof(passwordHasher));
        }

        public async Task<User> AuthenticateAsync(string username, string password)
        {
            var user = await _dbContext.Users.SingleOrDefaultAsync(u => u.Email == username);
            if (user == null || _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password) != PasswordVerificationResult.Success)
            {
                return null; // Unauthorized credentials
            }

            return user;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _dbContext.Users.SingleOrDefaultAsync(u => u.Email == email);
        }

        public async Task<string> GeneratePasswordResetTokenAsync(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));

            // Simulate a password reset token (this should ideally use Identity's token generator)
            var token = Guid.NewGuid().ToString();
          

            await _dbContext.SaveChangesAsync();
            return token;
        }

      

        public async Task<IdentityResult> ChangePasswordAsync(string userId, string currentPassword, string newPassword)
        {
            var user = await _dbContext.Users.FindAsync(userId);
            if (user == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "User not found" });
            }

            var passwordVerification = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, currentPassword);
            if (passwordVerification != PasswordVerificationResult.Success)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Current password is incorrect" });
            }

            user.PasswordHash = _passwordHasher.HashPassword(user, newPassword);
            await _dbContext.SaveChangesAsync();

            return IdentityResult.Success;
        }

        public Task<UserDto> CreateUserAsync(UserDto userDto)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePasswordAsync(int userId, string newPassword)
        {
            throw new NotImplementedException();
        }

        public Task<string> GenerateTwoFactorCodeAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ValidateTwoFactorCodeAsync(string userId, string code)
        {
            throw new NotImplementedException();
        }
    }
}
