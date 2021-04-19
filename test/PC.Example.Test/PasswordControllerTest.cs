using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using PC.Example.Domain.Interfaces.Services;
using PC.Exemple.Api.Commands;
using PC.Exemple.Api.Controllers;
using Xunit;

namespace PC.Example.Test
{
    public class PasswordControllerTest
    {
        private readonly PasswordsController _controller;
        private readonly IPasswordService _passwordService;

        public PasswordControllerTest()
        {
            _passwordService = Substitute.For<IPasswordService>();
            
            _controller = new PasswordsController(_passwordService);
        }

        [Fact]
        public void WhenPasswordInvalid_ShouldReturNoConflict()
        {
            _passwordService
                .Validate(Arg.Any<string>())
                .Returns(false);
            
            var result = _controller.ValidatePassword(new PasswordCommand { Password = "password"});

            Assert.IsType<ConflictObjectResult>(result);
        }
        
        [Fact]
        public void WhenPasswordValid_ShouldReturNoContent()
        {
            _passwordService
                .Validate(Arg.Any<string>())
                .Returns(true);
            
            var result = _controller.ValidatePassword(new PasswordCommand { Password = "password"});

            Assert.IsType<NoContentResult>(result);
        }
    }
}