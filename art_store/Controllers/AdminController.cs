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
    public class AdminController : ControllerBase
    {
        private readonly art_storeDbContext _art_storeContext;

        public AdminController(art_storeDbContext art_storeContext)
        {
            _art_storeContext = art_storeContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Admin>>> GetAll()
        {
            return await _art_storeContext.Admins.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] Admin admin)
        {
            var newAdmin = new Admin
            {
                Fio = admin.Fio,
                Email = admin.Email,
                Password = admin.Password,
            };

            await _art_storeContext.Admins.AddAsync(newAdmin);
            await _art_storeContext.SaveChangesAsync();
            return newAdmin.Id;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAdmin(int id, [FromBody] Admin admin)
        {
            var existingAdmin = await _art_storeContext.Admins.FindAsync(id);

            if (existingAdmin == null)
                return NotFound();

            existingAdmin.Fio = admin.Fio;
            existingAdmin.Email = admin.Email;
            existingAdmin.Password = admin.Password;

            _art_storeContext.Admins.Update(existingAdmin);
            await _art_storeContext.SaveChangesAsync();

            return NoContent();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Admin>> GetAdminById(int id)
        {
            var admin = await _art_storeContext.Admins.FindAsync(id);
            if (admin == null)
                return NotFound();

            return Ok(admin);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAdminById(int id)
        {
            var admin = await _art_storeContext.Admins.FindAsync(id);

            if (admin == null)
                return NotFound();

            _art_storeContext.Admins.Remove(admin);
            await _art_storeContext.SaveChangesAsync();
            return Ok();
        }
    }
}

