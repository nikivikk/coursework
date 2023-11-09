using Microsoft.AspNetCore.Mvc;
using art_store.Entities;

namespace art_store.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArtController : ControllerBase
    {


        //название метода который мы вызываем, для стандартного get не нужно

        //[HttpGet(Name = "GetWeatherForecast")]
        [HttpGet]

        public IEnumerable<Art> GetAll()
        {
            return new List<Art>()
            {
                new Art()
                {
                    Id = 1,
                    Name = "Test",
                    Status = true,
                    Year = DateTime.Now
                }
            };
                
        }
    }
}
