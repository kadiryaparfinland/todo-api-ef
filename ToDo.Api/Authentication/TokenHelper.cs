using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using ToDo.Domain.Constant;
using ToDo.Domain.DBModel;

namespace ToDo.Api.Authentication
{
    public class TokenHelper
    {
        private readonly IConfiguration _configuration;
        public TokenHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> GetToken(ApplicationUser user, IList<string> userRoles)
        {
            var authClaims = new List<Claim>
            {
                new Claim(ClaimConstant.Id, user.Id.ToString()),
                new Claim(ClaimConstant.UserName, user.UserName),
                new Claim(ClaimConstant.Name, user.Name ?? ""),
                new Claim(ClaimConstant.Email, user.Email ?? ""),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            //TODO** Magic Word Should Be Replaced By Constant
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"] ?? string.Empty));
            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(Convert.ToInt16(_configuration["JWT:TokenValidityInHour"])),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );
            return await Task.Run(() => new JwtSecurityTokenHandler().WriteToken(token));

        }
    }
}
