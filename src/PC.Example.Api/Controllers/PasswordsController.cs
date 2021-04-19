using Microsoft.AspNetCore.Mvc;
using PC.Example.Domain.Interfaces.Services;
using PC.Exemple.Api.Commands;

namespace PC.Exemple.Api.Controllers
{
    /// <summary>
    /// Realiza as operações relacionado a senha.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordsController : ControllerBase
    {
        private readonly IPasswordService _passwordService;
        
        /// <summary>
        /// Instancia um <see cref="PasswordsController"/>.
        /// </summary>
        /// <param name="passwordService">Regras de negocio relacionada a uma senha.</param>
        public PasswordsController(IPasswordService passwordService)
        {
            _passwordService = passwordService;
        }
        
        /// <summary>
        /// Valida se uma senha atende as criterios de segurança.
        /// </summary>
        /// <param name="command">Senha a ser validada.</param>
        /// <returns>NoContent se a senha for valida ou Conflict se invalida.</returns>
        [HttpPost("validate")]
        public IActionResult ValidatePassword([FromBody] PasswordCommand command)
        {
            var isValid = _passwordService.Validate(command.Password);
            return isValid ? NoContent() : Conflict(new { Errors = new [] { "INVALID_PASSWORD_FORMAT" }});
        }
    }
}