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

        //Récupère le jeu en fonction de son id (URL/games/id)
        //On utilise FirstOrDefault pour retourner le jeu qui correspond à l'id, + propre que de chercher via l'index (games[id])

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

        //Ajoute un nouveau jeu dans la base de données

        [HttpPost]

        public ActionResult<Game> CreateGame(Game newGame)
        {   
            _context.Games.Add(newGame);
            _context.SaveChanges();
            return newGame;
        }

        //Modifie les paramètres d'un jeu (status)

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

        //Supprime un jeu de la base de données

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
