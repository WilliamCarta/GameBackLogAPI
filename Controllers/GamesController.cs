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
            new() {ID = 3, Title = "Cyberpunk 2077", Genre = "RPG", Status = "WISHLIST" }
        };

        [HttpGet]
        public IEnumerable<Game> GetAll()
        {
            return games;
        }

        //On crée une methode HttpGet pour récupérer le jeu que l'on souhaite en fonction de son id (URL/games/id)
        //On utilise g => g.ID == id pour que FirstOrDefault nous retourne le jeu qui correspond à l'id, + propre que de chercher via l'index (games[id])

        [HttpGet("{id}")]
        public ActionResult<Game> GetByID(int id)
        {
            var game = games.FirstOrDefault(g => g.ID == id);
            
            if (game == null)
            {
                return NotFound();
            }

            return game;

        }

        [HttpPost]

        public ActionResult<Game> CreateGame(Game newGame)
        {
            int newID = games.Count + 1;

            newGame.ID = newID;

            games.Add(newGame);

            return newGame;

        }

        [HttpPut("{id}")]

        public ActionResult<Game> UpdateGame(int id, Game UpdatingGame)
        {
            var game = games.FirstOrDefault(g => g.ID == id);
            if (game == null)
            {
                return NotFound();
            }
            else
            {
                game.Title = UpdatingGame.Title;
                game.Genre = UpdatingGame.Genre;
                game.Status = UpdatingGame.Status;

                return game;
            }


        }

        [HttpDelete("{id}")]

        public ActionResult<Game> DeleteGame(int id)
        {
            var game = games.FirstOrDefault(g => g.ID == id);

            if (game == null)
            {
                return NotFound();
            }
            else
            {
                games.Remove(game);

                return NoContent();
            }
        }

    }
}
