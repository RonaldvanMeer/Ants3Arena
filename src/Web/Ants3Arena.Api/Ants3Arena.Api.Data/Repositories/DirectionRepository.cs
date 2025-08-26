using Ants3Arena.Api.Data.Contexts;
using Ants3Arena.Api.Data.Entities;
using Ants3Arena.Api.Models.Dtos;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace Ants3Arena.Api.Data.Repositories
{
    // ToDo: Make generic repositor
    // for now => specific dataset usage 'Directions'
    public class DirectionRepository : IBaseRepository<DirectionDto>
    {
        private readonly Ant3ArenaContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<DirectionRepository> _logger;

        public DirectionRepository(Ant3ArenaContext context, IMapper mapper, ILogger<DirectionRepository> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<DirectionDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            object?[]? keys = { id };
            return _mapper.Map<DirectionDto>(await _context.Directions.FindAsync(keys, cancellationToken));
        }

        public async Task<DirectionDto?> SaveAsync(DirectionDto directionDto, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _mapper.Map<Direction>(directionDto);
                var addedEntity = await _context.Directions.AddAsync(entity, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return _mapper.Map<DirectionDto>(addedEntity.Entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error saving direction entity");
                throw;
            }
        }
    }
}
