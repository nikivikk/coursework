using art_store.art_storeDto;
using art_store.Services.Contract;
using Microsoft.AspNetCore.Mvc;

namespace art_store.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {

        public readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetAll()
        {
            return await _orderService.GetAll();

        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] OrderDto order)
        {
            return await _orderService.Create(order);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<int>> UpdateOrder([FromBody] OrderDto order)
        {
            return await _orderService.Update(order);
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> GetOrderById(int id)
        {
            return await _orderService.GetById(id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeleteProductById(int id)
        {
            return await _orderService.Delete(id);
        }
    }
}

