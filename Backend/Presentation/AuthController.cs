using Backend.Application.DTOs.Request;
using Backend.Application.DTOs.Response;
using Backend.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Presentation
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : Controller
    {
        private readonly IAuthRepository _authRepository;

        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UsuarioAutenticadoDto>> Login(LoginDto loginDto)
        {
            try
            {
                var usuario = await _authRepository.LoginAsync(loginDto);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }
    }
}
