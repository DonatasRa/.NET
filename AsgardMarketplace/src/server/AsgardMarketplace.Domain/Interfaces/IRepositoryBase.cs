using AsgardMarketplace.Domain.Enums;
using AsgardMarketplace.Domain.Models.Bases;

namespace AsgardMarketplace.Domain.Interfaces
{
    public interface IRepositoryBase<T> where T : Entity
    {
        Task AddAsync(T entity);
        Task<int> CreateAsync(T model);
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task RemoveAsync(int entityId);
        Task Update(T entity);
    }
}