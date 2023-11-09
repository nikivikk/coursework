using Microsoft.AspNetCore.Mvc;
using art_store.Entities;
using art_store.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace art_store.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArtController : ControllerBase
    {

        public readonly art_storeDbContext _art_storeContext;

        public ArtController(art_storeDbContext art_storeContext)
        {
            _art_storeContext = art_storeContext;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<Art>>> GetAll()
        {
            return await _art_storeContext.Arts.ToListAsync();
                
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] Art art)
        {
            var newArt = new Art
            {
                Name = art.Name,
                Author = art.Author,
                Status = art.Status,
                Driver = art.Driver,
                Year = art.Year,
                Price = art.Price
            };

            await _art_storeContext.Arts.AddAsync(newArt);
            await _art_storeContext.SaveChangesAsync();
            return newArt.Id;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Art>> GetArtById(int id)
        {
            var art = await _art_storeContext.Arts.FindAsync(id);
            if (art == null)
                return NotFound();

            return Ok(art);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProductById(int id)
        {
            var art = await _art_storeContext.Arts.FindAsync(id);

            if (art == null)
                return NotFound();

            _art_storeContext.Arts.Remove(art);
            await _art_storeContext.SaveChangesAsync();
            return Ok();
        }
    }
}
