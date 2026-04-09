using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GameBackLogApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AuthController : ControllerBase
    {
        private IConfiguration _configuration;
        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private static List<User> users = new List<User>
        {
           new() {Username = "Willitest", Password = "12345" },
           new() {Username = "Willitest2", Password = "testmdp" },
           new() {Username = "Willitest3", Password = "azerty" }
        };

        [HttpPost("login")]

        public ActionResult<String> CheckAuth(User user)
        {
            var authuser = users.FirstOrDefault(u => u.Username == user.Username);

            if (authuser == null || user.Password != authuser.Password)
            {
                return Unauthorized();
            }
            else
            {
                var claims = new[] { new Claim(ClaimTypes.Name, authuser.Username) };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]!));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    issuer:_configuration["JWT:Issuer"],
                    audience: _configuration["JWT:Audience"],
                    claims: claims,
                    expires: DateTime.UtcNow.AddHours(1),
                    signingCredentials: creds);

                return new JwtSecurityTokenHandler().WriteToken(token);

            }


        }
    }
}
