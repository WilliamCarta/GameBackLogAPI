using Microsoft.AspNetCore.Mvc;

namespace GameBackLogApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GamesController : ControllerBase
    {
        private static List<Game> games = new List<Game>
        {
            new() {ID = 1, Title = "Hollow Knight", Genre = "Platformer", Status = "PLAYING"},
            new() {ID = 2, Title = "CS:GO", Genre = "FPS", Status = "DROPPED"},
            new() {ID = 3, Title = "Cyberpunk 2077", Genre = "RPG", Status = "Wishlist" }
        };
    }
}
