using Ants3Arena.Api.Data.Contexts;
using Ants3Arena.Api.Data.Entities;
using Ants3Arena.Api.Models.Dtos;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Ants3Arena.Api.Data.Repositories
{
    // ToDo: Make generic repositor
    // for now => specific dataset usage 'AntColors'
    public class AntColorsRepository : IBaseRepository<AntColorDto>
    {
        private readonly Ant3ArenaContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<AntColorsRepository> _logger;

        public AntColorsRepository(Ant3ArenaContext context, IMapper mapper, ILogger<AntColorsRepository> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<AntColorDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            var entities = await _context.AntColors.ToListAsync(cancellationToken);
            return _mapper.Map<IEnumerable<AntColorDto>>(entities);
        }

        public async Task<AntColorDto?> GetByIdAsync(Guid id , CancellationToken cancellationToken)
        {
            object?[]? keys = { id };
            return _mapper.Map<AntColorDto>(await _context.AntColors.FindAsync(keys, cancellationToken));
        }

        public async Task<AntColorDto?> SaveAsync(AntColorDto antColorDto, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _mapper.Map<AntColor>(antColorDto);
                var addedEntity = await _context.AntColors.AddAsync(entity, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return _mapper.Map<AntColorDto>(addedEntity.Entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error saving ant color entity");
                throw;
            }
        }
    }
}
