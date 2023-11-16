using art_store.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace art_store.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly art_storeDbContext _context;

        public OrderController(art_storeDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetAll()
        {
            return await _context.Orders
            // По умолчанию и без доп настроек EF не будет подтягивать арты, поэтому добавил следующую строчку
                .Include(x => x.Arts)
                .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] Order order)
        {

            var newOrder = new Order
            {
                UserId = order.UserId,
                DeliveryAddress = order.DeliveryAddress,
                DeliveryData = order.DeliveryData,
                // Если хотим создать ордер сразу с артами, то передаём сразу объекты
                // Если хочешь выбрать уже существующие арты, то нужно делать как в методе AddArtsToOrder
                // То есть сначала добавить Order, а потом уже в артах менять OrderId
                Arts = order.Arts,
            };

            await _context.Orders.AddAsync(newOrder);
            await _context.SaveChangesAsync();
            return newOrder.Id;
        }

        [HttpPost("AddArtsToOrder/{orderId}")]
        public async Task<IActionResult> AddArtsToOrder(int orderId, [FromBody] List<int> artIds)
        {
            var order = await _context.Orders.FindAsync(orderId)
                ?? throw new Exception("Order not found");

            // Тут ты добавляешь новые арты в ордер а не добавляешь существующие, а по сути у тебя нужно просто Id в оредере менять, потому что у тебя арты только в одинарном количестве
            //var arts = await _context.Arts.Where(a => artIds.Contains(a.Id)).ToListAsync();
            //order.Arts.AddRange(arts);

            var arts = await _context.Arts.Where(a => artIds.Contains(a.Id)).ToListAsync()
                ?? throw new Exception("Arts not found");

            foreach (var art in arts)
            {
                art.OrderId = orderId;
            }

            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, [FromBody] Order order)
        {
            var existingOrder = await _context.Orders.FindAsync(id);

            if (existingOrder == null)
                return NotFound();

            existingOrder.UserId = order.UserId;
            existingOrder.DeliveryAddress = order.DeliveryAddress;
            existingOrder.DeliveryData = order.DeliveryData;

            _context.Orders.Update(existingOrder);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrderById(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
                return NotFound();

            return Ok(order);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrderById(int id)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
                return NotFound();

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
