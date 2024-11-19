using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Filmes.Services.Token
{
    public class JwtService
    {
        private readonly string _secretKey;
        private readonly string _issuer;
        private readonly string _audience;

        public JwtService()
        {
            // Substitua pelos seus valores reais
            _secretKey = "filmes_tops_demais"; // Chave secreta usada para assinar o token
            _issuer = "search-flix";                      // Identifica o emissor
            _audience = "users";                 // Identifica os consumidores do token
        }

        public string GenerateToken(string userId, string username)
        {
            // Configuração das credenciais de assinatura
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Definindo as declarações (claims) do token
            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, userId),
            new Claim(JwtRegisteredClaimNames.UniqueName, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), // ID único para o token
            new Claim("role", "User") // Você pode adicionar outros claims personalizados
        };

            // Configuração do token
            var token = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1), // Expiração do token
                signingCredentials: credentials
            );

            // Retorna o token gerado como string
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
