using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Teste_001.Application.Services;
using Teste_001.Application.ViewModels;

namespace Teste_001.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        //[HttpPost("register")]
        //public async Task<IActionResult> Register([FromBody] UserViewModel model)
        //{
        //    try
        //    {
        //        await _authService.RegisterAsync(model);
        //        return Ok(new { message = "Usuário registrado com sucesso!" });
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new { message = ex.Message });
        //    }
        //}

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestModel model)
        {
            var token = await _authService.AuthenticateAsync(model.Email, model.Password);
            if (token == null)
                return Unauthorized(new { message = "E-mail ou senha inválidos" });

            return Ok(new { token });
        }
    }
}
