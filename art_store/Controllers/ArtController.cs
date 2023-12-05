using Microsoft.AspNetCore.Mvc;
using art_store.Services.Contract;
using art_store.art_storeDto;

namespace art_store.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArtController : ControllerBase
    {

        public readonly IArtService _artService;

        public ArtController(IArtService artService)
        {
            _artService = artService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArtDto>>> GetAll()
        {
            return await _artService.GetAll();

        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] ArtDto art)
        {
            return await _artService.Create(art);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<int>> UpdateArt([FromBody] ArtDto art)
        {
            return await _artService.Update(art);
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<ArtDto>> GetArtById(int id)
        {
            return await _artService.GetById(id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<int>>DeleteProductById(int id)
        {
            return await _artService.Delete(id);
        }
    }
}
