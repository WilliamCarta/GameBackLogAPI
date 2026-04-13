using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameBackLogApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class GamesController : ControllerBase
    {

        private GameBackLogContext _context;

        public GamesController(GameBackLogContext context) 
        {
            _context = context;
        }
            

        [HttpGet]
        public IEnumerable<Game> GetAll()
        {
            return _context.Games;
        }

        //On crée une methode HttpGet pour récupérer le jeu que l'on souhaite en fonction de son id (URL/games/id)
        //On utilise g => g.ID == id pour que FirstOrDefault nous retourne le jeu qui correspond à l'id, + propre que de chercher via l'index (games[id])

        [HttpGet("{id}")]
        public ActionResult<Game> GetByID(int id)
        {
            var game = _context.Games.FirstOrDefault(g => g.ID == id);
            
            if (game == null)
            {
                return NotFound();
            }

            return game;

        }

        [HttpPost]

        public ActionResult<Game> CreateGame(Game newGame)
        {   
            _context.Games.Add(newGame);
            _context.SaveChanges();
            return newGame;
        }

        [HttpPut("{id}")]

        public ActionResult<Game> UpdateGame(int id, Game UpdatingGame)
        {
            var game = _context.Games.FirstOrDefault(g => g.ID == id);
            if (game == null)
            {
                return NotFound();
            }
            else
            {
                game.Title = UpdatingGame.Title;
                game.Genre = UpdatingGame.Genre;
                game.Status = UpdatingGame.Status;
                _context.SaveChanges();
                return game;
            }


        }

        [HttpDelete("{id}")]

        public ActionResult<Game> DeleteGame(int id)
        {
            var game = _context.Games.FirstOrDefault(g => g.ID == id);

            if (game == null)
            {
                return NotFound();
            }
            else
            {
                _context.Games.Remove(game);
                _context.SaveChanges();
                return NoContent();
            }
        }

    }
}
