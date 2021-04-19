using PC.Example.Domain;
using PC.Example.Domain.Interfaces.Services;
using Xunit;

namespace PC.Example.Test
{
    public class PasswordServiceTest
    {
        private readonly IPasswordService _passwordService;

        public PasswordServiceTest()
        {
            _passwordService = new PasswordService();
        }
        
        [Fact]
        public void WhenPasswordIsEmpty_ShouldReturnFalse()
        {
            var result = _passwordService.Validate(string.Empty);
            Assert.False(result);
        }
        
        [Theory]
        [InlineData("aa")]
        [InlineData("ab")]
        [InlineData("AAAbbbCc")]
        [InlineData("AbTp9!foo")]
        [InlineData("AbTp9!foA")]
        [InlineData("AbTp9 fok")]
        public void WhenPasswordIsInvalid_ShouldReturnFalse(string password)
        {
            var result = _passwordService.Validate(password);
            Assert.False(result);
        }
        
        [Fact]
        public void WhenPasswordIsValid_ShouldReturnTrue()
        {
            var result = _passwordService.Validate("AbTp9!fok");
            Assert.True(result);
        }
    }
}