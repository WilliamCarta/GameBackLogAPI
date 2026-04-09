using Microsoft.AspNetCore.Mvc;

namespace GameBackLogApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AuthController : ControllerBase
    {

        private static List<User> users = new List<User>
        {
           new() {Username = "Willitest", Password = "12345" },
           new() {Username = "Willitest2", Password = "testmdp" },
           new() {Username = "Willitest3", Password = "azerty" }
        };

        [HttpPost("login")]

        public ActionResult<User> CheckAuth(User user)
        {
            var authuser = users.FirstOrDefault(u => u.Username == user.Username);

            if (authuser == null || user.Password != authuser.Password)
            {
                return NotFound();
            }
            else if (authuser.Password == user.Password)
            {

            }


        }
    }
}
