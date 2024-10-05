using ChatApplication.Data;
using ChatApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChatApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ChatDbContext _context;
        public UserController(ChatDbContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(User user)
        {
            //_context.Users.Add(user);
            //await _context.SaveChangesAsync();
            //return Ok(user);
            try
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return Ok(user);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new { error = "Database update error", details = ex.InnerException?.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "An unexpected error occurred", details = ex.Message });
            }
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(string email)
        {
            var user=await _context.Users.FirstOrDefaultAsync(u => u.Email==email);
            if (user!=null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound();
            }
            //return user != null ? Ok(user) : NotFound();
        }
        [HttpGet("users")]
        public async Task<IActionResult> GetUsers()
        {
            var users=await _context.Users.ToListAsync();
            return Ok(users);
        }

    }
}
