using AutoMapper;
using CoffeeListApp.Domain.Dtos;
using CoffeeListApp.Domain.Interfaces;
using CoffeeListApp.Domain.Models;

namespace CoffeeListApp.Domain.Services
{
    public class CoffeeService
    {
        private readonly ICoffeeRepository _coffeeRepository;
        private readonly IMapper _mapper;

        public CoffeeService(ICoffeeRepository coffeeRepository, IMapper mapper)
        {
            _coffeeRepository = coffeeRepository;
            _mapper = mapper;
        }

        public async Task<List<Coffee>> GetAllAsync()
        {
            List<Coffee> coffees = await _coffeeRepository.GetAllAsync();
            if (coffees == null)
            {
                throw new ArgumentException("No Coffees found");
            }

            return coffees;
        }

        public async Task<Coffee> GetByIdAsync(int id)
        {
            var coffee = await _coffeeRepository.GetByIdAsync(id);
            if (coffee == null)
            {
                throw new ArgumentException("Coffee with such Id does not exist");
            }

            return coffee;
        }

        public async Task RemoveAsync(int id)
        {
            await _coffeeRepository.RemoveAsync(id);
        }

        public async Task<int> CreateAsync(Coffee createCoffee)
        {
            var doesCoffeeExist = await _coffeeRepository.CheckCoffeeExistAsync(createCoffee.Name);

            var coffee = new Coffee()
            {
                Name = createCoffee.Name,
                Price = createCoffee.Price,
            };

            var coffeeId = await _coffeeRepository.CreateAsync(coffee);

            return coffeeId;
        }
    }
}
