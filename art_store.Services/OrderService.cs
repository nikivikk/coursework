using art_store.art_storeDto;
using art_store.Services.Contract;
using art_store.DataAccess.Repository.Contracts;
using art_store.Entities;
using AutoMapper;
using art_store.DataAccess.Repository;

namespace art_store.Services
{
    public class OrderService : IOrderService
    {
        public readonly IOrderRepository _orderRepository;
        public readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<int> Create(OrderDto order)
        {
            var orderExisted = await _orderRepository.GetById(order.Id);

            if (orderExisted != null)
            {
                throw new Exception("Order exist");
            }

            var orderToAdd = _mapper.Map<Order>(order);
            return await _orderRepository.Create(orderToAdd);
        }

        public async Task<int> Update(OrderDto order)
        {
            var orderToUpdate = await _orderRepository.GetById(order.Id)
                ?? throw new Exception("Order not exist");

            orderToUpdate = _mapper.Map(order, orderToUpdate);
            return await _orderRepository.Update(orderToUpdate);
        }

        public async Task<int> Delete(int id)
        {
            var ToDelete = await _orderRepository.GetById(id)
            ?? throw new Exception("Order not exist");
            return await _orderRepository.Delete(id);
        }

        public async Task<OrderDto> GetById(int id)
        {
            var order = await _orderRepository.GetById(id);

            return _mapper.Map<OrderDto>(order);
        }

        public async Task<List<OrderDto>> GetAll()
        {
            var orders = await _orderRepository.GetAll();
            return _mapper.Map<List<OrderDto>>(orders);
        }

    }
}
