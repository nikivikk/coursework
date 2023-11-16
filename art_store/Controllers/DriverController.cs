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
    public class DriverController : ControllerBase
    {
        private readonly art_storeDbContext _art_storeContext;

        public DriverController(art_storeDbContext art_storeContext)
        {
            _art_storeContext = art_storeContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Driver>>> GetAll()
        {
            return await _art_storeContext.Drivers.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] Driver driver)
        {
            var newDriver = new Driver
            {
                Fio = driver.Fio,
                Email = driver.Email,
                Password = driver.Password
            };

            await _art_storeContext.Drivers.AddAsync(newDriver);
            await _art_storeContext.SaveChangesAsync();
            return newDriver.Id;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Driver>> GetDriverById(int id)
        {
            var driver = await _art_storeContext.Drivers.FindAsync(id);
            if (driver == null)
                return NotFound();

            return Ok(driver);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDriver(int id, [FromBody] Driver driver)
        {
            var existingDriver = await _art_storeContext.Drivers.FindAsync(id);

            if (existingDriver == null)
                return NotFound();

            existingDriver.Fio = driver.Fio;
            existingDriver.Email = driver.Email;
            existingDriver.Password = driver.Password;


            _art_storeContext.Drivers.Update(existingDriver);
            await _art_storeContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDriverById(int id)
        {
            var driver = await _art_storeContext.Drivers.FindAsync(id);

            if (driver == null)
                return NotFound();

            _art_storeContext.Drivers.Remove(driver);
            await _art_storeContext.SaveChangesAsync();
            return Ok();
        }
    }
}
