using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Trevo.API.Application.Interfaces;
using Trevo.API.Domain.Models;

namespace Trevo.API.Application.Implementations
{
    public class TokenService : ITokenService
    {
        private readonly JWTModel _config;
        public TokenService(IOptions<JWTModel> config)
        {
            _config = config.Value;
        }
        public string Generate(UsuarioResultModel model)
        {
            var handler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config.PrivateKey);
            var credentials = new SigningCredentials(
            new SymmetricSecurityKey(key),
            SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = GenerateClaims(model),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = credentials,
            };
            var token = handler.CreateToken(tokenDescriptor);
            return handler.WriteToken(token);
        }

        private static ClaimsIdentity GenerateClaims(UsuarioResultModel model)
        {
            var ci = new ClaimsIdentity();
            ci.AddClaim(new Claim(ClaimTypes.Name, model.Login ?? "User Missing"));
            ci.AddClaim(new Claim(ClaimTypes.Role, GetProfileDescription(model.Perfil.Value)) );

            return ci;
        }

        private static string GetProfileDescription(int profile)
        {
            return (profile == 1) ? "Administrador" : "Usuario";
        }
    }
}
