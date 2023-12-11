using art_store.art_storeDto;
using art_store.Services.Contract;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace art_store.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {

        private readonly ITokenProviderService _tokenProviderService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public readonly IOrderService _orderService;

        public OrderController(
            IOrderService orderService,
            IHttpContextAccessor httpContextAccessor,
            ITokenProviderService tokenProviderService)
        {
            _orderService = orderService;
            _httpContextAccessor = httpContextAccessor;
            _tokenProviderService = tokenProviderService;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] OrderDto order)
        {
            var accessToken = _httpContextAccessor.HttpContext.Request.Headers.Authorization.ToString();
            var userId = _tokenProviderService.GetClaimValueByType(accessToken, ClaimTypes.UserData);

            order.UserId = int.Parse(userId);

            return await _orderService.Create(order);
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetAll()
        {
            return await _orderService.GetAll();

        }

        //[HttpPost]
        //public async Task<ActionResult<int>> Create([FromBody] OrderDto order)
        //{
        //    return await _orderService.Create(order);
        //}

        //[HttpPut("{id}")]
        //public async Task<ActionResult<int>> UpdateOrder([FromBody] OrderDto order)
        //{
        //    return await _orderService.Update(order);
        //}



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

