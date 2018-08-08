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
        public IEnumerable<Scores> GetScores()
        {
            return _context.Scores.ToList().OrderByDescending(a => a.Score).Take(10);
        }

        // GET: api/Scores/user
        [HttpGet("{user}")]
        public async Task<IActionResult> GetScores([FromRoute] string user)
        {
            IEnumerable<Scores> scores = _context.Scores.Where(a => a.UserName == user).OrderByDescending(a => a.Score).Take(10);

            if (scores == null)
            {
                return NotFound();
            }

            return Ok(scores);
        }
              

        // POST: api/Scores
        [HttpPost]
        public async Task<IEnumerable<Scores>> PostScores([FromBody] Scores scores)
        {
           
            _context.Scores.Add(scores);

            await _context.SaveChangesAsync();

            var best_score = _context.Scores.ToList().OrderByDescending(a => a.Score).Take(10);
                        
            return best_score;
        }

       
    }
}