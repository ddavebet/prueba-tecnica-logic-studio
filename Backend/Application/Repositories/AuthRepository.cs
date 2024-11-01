using Backend.Application.DTOs.Request;
using Backend.Application.Helpers;
using Backend.Application.Interfaces;
using Backend.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthRepository(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<string> LoginAsync(LoginDto loginDto)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(
                x => x.Nombre.ToUpper() == loginDto.Nombre.ToUpper()
            );
            if (usuario == null)
            {
                throw new Exception("El nombre de usuario o contraseña no coinciden.");
            }

            bool verificado = CryptoHelper.VerificarHash(
                loginDto.Contrasena,
                usuario.Contrasena,
                usuario.Salt
            );
            if (!verificado)
            {
                throw new Exception("El nombre de usuario o contraseña no coinciden.");
            }

            JwtHelper jwt = new(_configuration);

            string token = jwt.GenerarAccessToken(usuario);

            return token;
        }
    }
}
