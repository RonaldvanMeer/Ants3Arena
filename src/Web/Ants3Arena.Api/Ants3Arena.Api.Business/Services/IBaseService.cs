using Ants3Arena.Api.Models.Dtos;

namespace Ants3Arena.Api.Business.Services
{
    public interface IBaseService<T> where T : BaseDto
    {
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);
        Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<T?> SaveAsync(T antColorDto, CancellationToken cancellationToken);
    }
}
