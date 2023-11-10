using Microsoft.AspNetCore.Mvc;
using art_store.Entities;
using art_store.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace art_store.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly art_storeDbContext _art_storeContext;

        public UserController(art_storeDbContext art_storeContext)
        {
            _art_storeContext = art_storeContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            return await _art_storeContext.Users.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] User user)
        {
            var newUser = new User
            {
                Fio = user.Fio,
                Email = user.Email,
                Password = user.Password,
                UserCardId = user.UserCardId,
                Age = user.Age
            };

            await _art_storeContext.Users.AddAsync(newUser);
            await _art_storeContext.SaveChangesAsync();
            return newUser.Id;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] User user)
        {
            var existingUser = await _art_storeContext.Users.FindAsync(id);

            if (existingUser == null)
                return NotFound();

            existingUser.Fio = user.Fio;
            existingUser.Email = user.Email;
            existingUser.Password = user.Password;
            existingUser.UserCardId = user.UserCardId;
            existingUser.Age = user.Age;

            _art_storeContext.Users.Update(existingUser);
            await _art_storeContext.SaveChangesAsync();

            return NoContent();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _art_storeContext.Users.FindAsync(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUserById(int id)
        {
            var user = await _art_storeContext.Users.FindAsync(id);

            if (user == null)
                return NotFound();

            _art_storeContext.Users.Remove(user);
            await _art_storeContext.SaveChangesAsync();
            return Ok();
        }
    }
}
