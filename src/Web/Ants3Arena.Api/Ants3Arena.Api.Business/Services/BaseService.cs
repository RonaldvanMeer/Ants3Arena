using Ants3Arena.Api.Data.Repositories;
using Ants3Arena.Api.Models.Dtos;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace Ants3Arena.Api.Business.Services
{
    public class BaseService<T> : IBaseService<T> where T : BaseDto
    {
        private readonly IBaseRepository<T> _baseRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<BaseService<T>> _logger;

        public BaseService(IBaseRepository<T> baseRepository, IMapper mapper, ILogger<BaseService<T>> logger)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken)
        {
            try
            {
                var entities = await _baseRepository.GetAllAsync(cancellationToken);
                return _mapper.Map<IEnumerable<T>>(entities);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving all entities");
                throw;
            }
        }

        public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                return _mapper.Map<T>(await _baseRepository.GetByIdAsync(id, cancellationToken));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving entity by ID");
                throw;
            }
        }

        public async Task<T?> SaveAsync(T antColorDto, CancellationToken cancellationToken)
        {
            try
            {
                return _mapper.Map<T>(await _baseRepository.SaveAsync(antColorDto, cancellationToken));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error saving entity");
                throw;
            }
        }
    }
}
