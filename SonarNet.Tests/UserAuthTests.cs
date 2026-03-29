using System;
using Xunit;
using SonarNet.Infrastructure.Services;

namespace SonarNet.Tests
{
    public class UserAuthTests
    {
        private readonly UserAuth _auth;

        public UserAuthTests()
        {
            _auth = new UserAuth();
        }

        [Fact]
        public void Authenticate_ValidAdminCredentials_ReturnsTrue()
        {
            // Arrange
            string username = "admin";
            string password = "admin123";

            // Act
            bool result = _auth.Authenticate(username, password);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Authenticate_ValidUserCredentials_ReturnsTrue()
        {
            // Arrange
            string username = "user";
            string password = "user123";

            // Act
            bool result = _auth.Authenticate(username, password);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Authenticate_InvalidPassword_ReturnsFalse()
        {
            // Arrange
            string username = "admin";
            string password = "wrongpassword";

            // Act
            bool result = _auth.Authenticate(username, password);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Authenticate_NonExistentUser_ReturnsFalse()
        {
            // Arrange
            string username = "nonexistent";
            string password = "any";

            // Act
            bool result = _auth.Authenticate(username, password);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void GetUserRole_ExistingUser_ReturnsCorrectRole()
        {
            // Arrange
            string username = "admin";

            // Act
            string role = _auth.GetUserRole(username);

            // Assert
            Assert.Equal("Administrator", role);
        }

        [Fact]
        public void GetUserRole_NonExistentUser_ReturnsNull()
        {
            // Arrange
            string username = "ghost";

            // Act
            string role = _auth.GetUserRole(username);

            // Assert
            Assert.Null(role);
        }

        [Theory]
        [InlineData(null, "admin123")]
        [InlineData("admin", null)]
        [InlineData("", "admin123")]
        [InlineData("admin", "")]
        [InlineData(" ", "admin123")]
        public void Authenticate_NullOrEmptyInputs_ReturnsFalse(string username, string password)
        {
            // Act
            bool result = _auth.Authenticate(username, password);

            // Assert
            Assert.False(result);
        }
    }
}