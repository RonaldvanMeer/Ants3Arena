using Ants3Arena.Api.Models.Dtos;

namespace Ants3Arena.Api.Data.Repositories
{
    public interface IBaseRepository<T> where T : BaseDto
    {
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);
        Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<T?> SaveAsync(T entity, CancellationToken cancellationToken);
    }
}
