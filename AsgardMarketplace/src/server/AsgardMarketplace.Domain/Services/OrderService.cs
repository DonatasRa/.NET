using AsgardMarketplace.Domain.Dtos;
using AsgardMarketplace.Domain.Interfaces;
using AsgardMarketplace.Domain.Models;

namespace AsgardMarketplace.Domain.Services
{
    public class OrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Order> GetByUserIdAsync(int userId)
        {
            var order = await _orderRepository.GetByUserIdAsync(userId);
            if (order == null)
            {
                throw new ArgumentException("Order with such UserId does not exist");
            }

            return order;
        }

        public async Task<int> CreateAsync(CreateOrderDto createOrder)
        {
            var order = new Order
            {
                UserId = createOrder.UserId,
                ItemId = createOrder.ItemId,
            };
             
            var createdId = await _orderRepository.CreateAsync(order);

            return createdId;
        }

        public async Task UpdateStatusAsync(UpdateOrderStatusDto updateStatus)
        {
            var order = await _orderRepository.GetByIdAsync(updateStatus.Id);
            if (order == null)
            {
                throw new ArgumentException("Order with such Id does not exist");
            }

            order.Status = updateStatus.OrderStatus.ToString();
            await _orderRepository.Update(order);
        }

        public async Task RemoveAsync(int orderId)
        {
            await _orderRepository.RemoveAsync(orderId);
        }
    }
}
