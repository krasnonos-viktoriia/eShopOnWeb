using System;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;

namespace SonarNet.Infrastructure.Services
{
    public class UserAuth
    {
        private readonly Dictionary<string, (string PasswordHash, string Role)> _users;

        public UserAuth()
        {
            _users = new Dictionary<string, (string, string)>
            {
                ["admin"] = (HashPassword("admin123"), "Administrator"),
                ["user"] = (HashPassword("user123"), "User")
            };
        }

        public bool Authenticate(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return false;

            if (_users.TryGetValue(username, out var user))
            {
                return VerifyPassword(password, user.PasswordHash);
            }

            return false;
        }

        public string GetUserRole(string username)
        {
            return _users.TryGetValue(username, out var user) ? user.Role : null;
        }

        private static string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }

        private static bool VerifyPassword(string password, string storedHash)
        {
            var hash = HashPassword(password);
            return hash == storedHash;
        }
    }
}