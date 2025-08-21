using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using VideoGameApi.Data;

namespace VideoGameApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGameController(VideoGameDbContext context) : ControllerBase
    {
        private readonly VideoGameDbContext _context = context;

        [HttpGet]
        public async  Task<ActionResult<List<VideoGame>>> GetVideoGames()
        {
            return Ok(await _context.VideoGames.ToListAsync());
        }

        [HttpGet("{id}")]
        //[Route("{id}")]
        public async Task<ActionResult<VideoGame>> GetVideoGameById(int id)
        {
            var game = await _context.VideoGames.FindAsync(id);
            if (game is null)
                return NotFound();

            return Ok(game);
        }

        [HttpPost]
        public async Task<ActionResult<VideoGame>> AddVideoGame(VideoGame newGame)
        {
            if (newGame is null)
                return BadRequest();
            _context.VideoGames.Add(newGame);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetVideoGameById), new { id = newGame.Id }, newGame);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVideoGame(int id, VideoGame updategame)
        {
            var game = await _context.VideoGames.FindAsync(id);
            if (game is null)
                if (game is null)
                return NotFound();

            game.Title = updategame.Title;
            game.Platform = updategame.Platform;
            game.Developer = updategame.Developer;
            game.Publisher = updategame.Publisher;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVideoGame(int id)
        {
            var game = await _context.VideoGames.FindAsync(id);
            if (game is null)
                return NotFound();

            _context.VideoGames.Remove(game);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
