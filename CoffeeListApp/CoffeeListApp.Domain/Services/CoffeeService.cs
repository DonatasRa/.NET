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
    }
}
