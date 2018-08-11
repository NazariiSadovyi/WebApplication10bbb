using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication10bbb.DB;

namespace WebApplication10bbb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ScoresController : ControllerBase
    {
        private readonly PacmanDBContext _context;

        public ScoresController(PacmanDBContext context)
        {
            _context = context;
        }

        // GET: api/Scores
        [HttpGet]
        public async Task<List<string>> GetScores()
        {
            var scores = _context.Scores.ToList().OrderByDescending(a => a.Score).Take(10);

            List<string> userscore = new List<string>();

            foreach (var item in scores)
            {
                userscore.Add(item.UserName + "  " + item.Score.ToString());
            }

            return userscore;
        }

        // GET: api/Scores/user
        [HttpGet("{user}")]
        public async Task<IActionResult> GetScores([FromRoute] string user)
        {
            IEnumerable<Scores> scores = _context.Scores.Where(a => a.UserName == user).OrderByDescending(a => a.Score).Take(10);

            List<string> userscore = new List<string>();

            foreach (var item in scores)
            {
                userscore.Add(item.Score.ToString());
            }

            if (scores == null)
            {
                return NotFound();
            }

            return Ok(userscore);
        }
              

        // POST: api/Scores
        [HttpPost]
        public async Task<List<string>> PostScores([FromBody] Scores userscores)
        {
           
            _context.Scores.Add(userscores);

            await _context.SaveChangesAsync();

            var best_score = _context.Scores.ToList().Where(a => a.UserName == userscores.UserName).OrderByDescending(a => a.Score).Take(10);

            List<string> userscore = new List<string>();

            foreach (var item in best_score)
            {
                userscore.Add(item.Score.ToString());
            }

            return userscore;
        }

       
    }
}