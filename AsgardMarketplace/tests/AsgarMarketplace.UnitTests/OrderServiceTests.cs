using AsgardMarketplace.Domain.Interfaces;
using AsgardMarketplace.Domain.Services;
using Moq;
using Xunit;

namespace AsgarMarketplace.UnitTests
{
    public class OrderServiceTests
    {
        [Fact]
        public void GetByUserIdAsync_GivenValidUserId_GetCorrectOrder()
        {
            //arrange
            var importOrderRepositoryMock = new Mock<IOrderRepository>();
            importOrderRepositoryMock.Setup(its => its.GetByUserIdAsync(int userId))
                .Returns()
            var orderService = new OrderService();
            var validUserId = 1;


            //act
            var answer = orderService.



            //assert
        }
    }
}