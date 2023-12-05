using Microsoft.AspNetCore.Mvc;
using art_store.art_storeDto;
using art_store.Services.Contract;

namespace driver_store.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DriverController : ControllerBase
    {

        public readonly IDriverService _driverService;

        public DriverController(IDriverService driverService)
        {
            _driverService = driverService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<DriverDto>>> GetAll()
        {
            return await _driverService.GetAll();

        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] DriverDto driver)
        {
            return await _driverService.Create(driver);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<int>> UpdateDriver([FromBody] DriverDto driver)
        {
            return await _driverService.Update(driver);
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<DriverDto>> GetDriverById(int id)
        {
            return await _driverService.GetById(id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeleteProductById(int id)
        {
            return await _driverService.Delete(id);
        }
    }
}
