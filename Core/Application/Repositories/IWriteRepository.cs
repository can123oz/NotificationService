using Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T model);
        Task<bool> AddRangeAsync(List<T> model);
        bool Remove(T model);
        Task<bool> Remove(string id);
        bool Update(T model);
        Task<int> SaveAsync();
    }
}
