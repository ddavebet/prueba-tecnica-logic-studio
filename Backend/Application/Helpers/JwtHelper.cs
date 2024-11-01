using Backend.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Backend.Application.Helpers
{
    public class JwtHelper
    {
        private readonly IConfiguration _configuration;

        const string securityAlgorithm = SecurityAlgorithms.HmacSha512Signature;

        public JwtHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerarAccessToken(Usuario usuario)
        {
            List<Claim> claims =
                new() { new Claim("id", usuario.Id.ToString()), new Claim("usr", usuario.Nombre), };

            var secretKey = _configuration.GetSection("JWT:SecretKey").Value;
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(signingKey, securityAlgorithm);
            var tiempoDuracion = Convert.ToDouble(
                _configuration.GetSection("JWT:AccessTokenDuracion").Value
            );

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(tiempoDuracion),
                signingCredentials: credentials
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

        public ClaimsPrincipal ObtenerClaimsPrincipalDeToken(string token)
        {
            try
            {
                var secretKey = _configuration.GetSection("JWT:SecretKey").Value;
                var tokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = false,
                    ClockSkew = TimeSpan.Zero
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var claimsPrincipal = tokenHandler.ValidateToken(
                    token,
                    tokenValidationParameters,
                    out SecurityToken securityToken
                );

                if (
                    securityToken is not JwtSecurityToken jwtSecurityToken
                    || !jwtSecurityToken.Header.Alg.Equals(
                        securityAlgorithm,
                        StringComparison.InvariantCultureIgnoreCase
                    )
                )
                {
                    throw new SecurityTokenException();
                }

                return claimsPrincipal;
            }
            catch
            {
                throw new Exception("Access Token no es válido.");
            }
        }
    }
}
