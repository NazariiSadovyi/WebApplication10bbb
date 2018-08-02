using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace WebApplication10bbb.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    //public class UsersController : ControllerBase
    //{
    //    private readonly Ternopil_DBContext _context;

    //    public UsersController(Ternopil_DBContext context)
    //    {
    //        _context = context;
    //    }


    //    // GET: api/Users
    //    [HttpGet]
    //    public async Task<IActionResult> GetUsers([FromHeader] string UserName, [FromHeader] string UserPassword)
    //    {
    //        if (!ModelState.IsValid)
    //        {
    //            return BadRequest(ModelState);
    //        }

            



    //        var users = await _context.Users.FindAsync(UserName);

    //        if (users == null)
    //        {
    //            return NotFound();
    //        }
    //        else
    //        {
    //            if (users.UserPassword == UserPassword)
    //            {
                   
    //                return Ok();
    //            }
    //            else
    //            {
    //                return Unauthorized();
    //            }
    //        }


    //    }


    //    // POST: api/Users
    //    [HttpPost]
    //    public async Task<IActionResult> PostUsers([FromHeader] string UserName, [FromHeader] string UserPassword)
    //    {
    //        if (!ModelState.IsValid)
    //        {
    //            return BadRequest(ModelState);
    //        }

    //        _context.Users.Add(new Users { UserName = UserName, UserPassword = UserPassword});
    //        try
    //        {
    //            await _context.SaveChangesAsync();
    //        }
    //        catch (DbUpdateException)
    //        {
    //            if (UsersExists(UserName))
    //            {
    //                return new StatusCodeResult(StatusCodes.Status409Conflict);
    //            }
    //            else
    //            {
    //                throw;
    //            }
    //        }

    //        return Ok();
    //    }

    //    // DELETE: api/Users/5
    //    [HttpDelete("{id}")]
    //    public async Task<IActionResult> DeleteUsers([FromRoute] string id)
    //    {
    //        if (!ModelState.IsValid)
    //        {
    //            return BadRequest(ModelState);
    //        }

    //        var users = await _context.Users.FindAsync(id);
    //        if (users == null)
    //        {
    //            return NotFound();
    //        }

    //        _context.Users.Remove(users);
    //        await _context.SaveChangesAsync();

    //        return Ok(users);
    //    }

    //    private bool UsersExists(string id)
    //    {
    //        return _context.Users.Any(e => e.UserName == id);
    //    }
    //}
}