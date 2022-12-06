using System.IdentityModel.Tokens.Jwt;
using System.Text;
using CompanyEcosystem.BL.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace CompanyEcosystem.PL.Middlewares
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IAccountService userService, IConfiguration configuration, ILogger<JwtMiddleware> logger)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
                AttachUserToContext(context, userService, configuration, logger, token);

            await _next(context);
        }

        private void AttachUserToContext(HttpContext context, IAccountService accountService,IConfiguration configuration, ILogger<JwtMiddleware> logger, string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                
                var key = Encoding.ASCII.GetBytes(configuration["Secret"]);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

                context.Items["User"] = accountService.GetByIdAsync(userId);
            }
            catch(Exception e)
            {
                logger.LogInformation(e.Message);
            }
        }
    }
}
