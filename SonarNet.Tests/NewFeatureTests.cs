using System;
using System.Threading.Tasks;
using Xunit;
using SonarNet.Infrastructure.Services;

namespace SonarNet.Tests
{
    public class NewFeatureTests
    {
        [Fact]
        public void Execute_WithValidInput_ReturnsExpectedResult()
        {
            // Arrange
            var feature = new NewFeature();
            var input = "TestInput";

            // Act
            var result = feature.Execute(input);

            // Assert
            Assert.Equal("NewFeature executed with input: TestInput", result);
        }

        [Fact]
        public void Execute_WithEmptyInput_ThrowsArgumentException()
        {
            // Arrange
            var feature = new NewFeature();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => feature.Execute(""));
            Assert.Throws<ArgumentException>(() => feature.Execute("   "));
        }

        [Fact]
        public async Task ExecuteAsync_WithValidInput_ReturnsExpectedResult()
        {
            // Arrange
            var feature = new NewFeature();
            var input = "AsyncTest";

            // Act
            var result = await feature.ExecuteAsync(input);

            // Assert
            Assert.Equal("NewFeature executed with input: AsyncTest", result);
        }

        [Fact]
        public async Task ExecuteAsync_WithEmptyInput_ThrowsArgumentException()
        {
            // Arrange
            var feature = new NewFeature();

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => feature.ExecuteAsync(""));
            await Assert.ThrowsAsync<ArgumentException>(() => feature.ExecuteAsync("   "));
        }
    }
}