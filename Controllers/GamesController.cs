using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

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

        [HttpGet]
        public IEnumerable<Game> GetAll()
        {
            return games;
        }

        //On crée une methode HttpGet pour récupérer le jeu que l'on souhaite en fonction de son id (URL/games/id)
        //On fait id - 1 car la position dans la liste de l'id 1 = 0

        [HttpGet("{id}")]
        public ActionResult<Game> GetByID(int id)
        {
            id -= 1;
            
            if (id < 0 || id >= games.Count)
            {
                return NotFound();
            }

            return games[id];

        }

    }
}
