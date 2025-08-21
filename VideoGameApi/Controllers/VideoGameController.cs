using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace VideoGameApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGameController : ControllerBase
    {
        static private List<VideoGame> videoGames = new List<VideoGame>
        {
            new VideoGame
            {
                Id=1,
                Title="MARIO",
                Platform="PS5",
                Developer="RICHARD",
                Publisher="SAM"
            },
            new VideoGame
            {
                Id=2,
                Title="GTA",
                Platform="PS5",
                Developer="RYAN",
                Publisher="ABRAHAM"
            },
            new VideoGame
            {
                Id=3,
                Title="NFS",
                Platform="PS5",
                Developer="RIORDAN",
                Publisher="BRYAN"
            }
        };

        [HttpGet]
        public ActionResult<List<VideoGame>> GetVideoGames()
        {
            return Ok(videoGames);
        }

        [HttpGet("{id}")]
        //[Route("{id}")]
        public ActionResult<VideoGame> GetVideoGameById(int id)
        {
            var game = videoGames.FirstOrDefault(g => g.Id == id);
            if(game is null)
                return NotFound();
            
            return Ok(game);
        }

        [HttpPost]
        public ActionResult<VideoGame> AddVideoGame(VideoGame newGame)
        {
            if (newGame is null)
                return BadRequest();

            newGame.Id = videoGames.Max(g => g.Id) + 1;
            videoGames.Add(newGame);
            return CreatedAtAction(nameof(GetVideoGameById), new { id = newGame.Id }, newGame);

        }

        [HttpPut("{id}")]
        public IActionResult UpdateVideoGame(int id, VideoGame updategame)
        {
            var game = videoGames.FirstOrDefault(g => g.Id == id);
            if (game is null)
                return NotFound();

            game.Title = updategame.Title;
            game.Platform = updategame.Platform;
            game.Developer = updategame.Developer;
            game.Publisher = updategame.Publisher;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteVideoGame(int id)
        {
            var game = videoGames.FirstOrDefault(g => g.Id == id);
            if (game is null)
                return NotFound();

            videoGames.Remove(game);
            return NoContent();
        }

    }
}
