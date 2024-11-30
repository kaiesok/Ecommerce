using Core.DTOs;
using Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace Core.Interfaces
{
    public interface IUserService
    {
        Task<User> AuthenticateAsync(string username, string password);

        Task<UserDto> CreateUserAsync(UserDto userDto);
        Task<User> GetByIdAsync(int userId);
        Task<User> GetUserByEmailAsync(string email);  

        Task UpdatePasswordAsync(int userId, string newPassword);

        Task<string> GeneratePasswordResetTokenAsync(User user);

        Task<string> GenerateTwoFactorCodeAsync(string userId);

        Task<bool> ValidateTwoFactorCodeAsync(string userId, string code);

        Task<IdentityResult> ChangePasswordAsync(string userId, string currentPassword, string newPassword);
    }
}

