using Microsoft.AspNetCore.Mvc;
using art_store.Services.Contract;
using art_store.art_storeDto;

namespace art_store.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        public readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAll()
        {
            return await _userService.GetAll();

        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] UserDto user)
        {
            return await _userService.Create(user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<int>> UpdateArt([FromBody] UserDto user)
        {
            return await _userService.Update(user);
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetArtById(int id)
        {
            return await _userService.GetById(id);
        }

        [HttpGet("/find-user")]
        public async Task<ActionResult<UserDto>> GetByEmai(string email)
        {
            return await _userService.GetByEmail(email);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeleteProductById(int id)
        {
            return await _userService.Delete(id);
        }
    }
}
