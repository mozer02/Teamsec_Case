using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Teamsec_Case.API.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        readonly IConfiguration _configuration;

        public JwtMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task Invoke(HttpContext context)
        {
            var tokenString = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (tokenString != null)
            {
                if (ValidateToken(tokenString, _configuration["AppSettings:Secret"]))
                {
                    var handler = new JwtSecurityTokenHandler();
                    var jsonToken = handler.ReadToken(tokenString) as JwtSecurityToken;

                    if (jsonToken != null)
                    {
                        var identity = new ClaimsIdentity(jsonToken.Claims, "Bearer");
                        var principal = new ClaimsPrincipal(identity);
                        context.User = principal;
                    }
                }
            }

            await _next(context);
        }
        private bool ValidateToken(string token, string secretKey)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);

            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // Diğer gerekli ayarları ekleyebilirsiniz
                }, out SecurityToken validatedToken);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
    public static class JwtMiddlewareExtensions
    {
        public static IApplicationBuilder UseJwtMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<JwtMiddleware>();
        }
    }
}