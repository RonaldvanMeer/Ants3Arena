using Ants3Arena.Api.Data.Contexts;
using Ants3Arena.Api.Data.Entities;
using Ants3Arena.Api.Models.Dtos;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Ants3Arena.Api.Data.Repositories
{
    // ToDo: Make generic repositor
    // for now => specific dataset usage 'Ants'
    public class AntsRepository : IBaseRepository<AntDto>
    {
        private readonly Ant3ArenaContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<AntsRepository> _logger;

        public AntsRepository(Ant3ArenaContext context, IMapper mapper, ILogger<AntsRepository> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<AntDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            var entities = await _context.Ants.ToListAsync(cancellationToken);
            return _mapper.Map<IEnumerable<AntDto>>(entities);
        }

        public async Task<AntDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            object?[]? keys = { id };
            return _mapper.Map<AntDto>(await _context.Ants.FindAsync(keys, cancellationToken));
        }

        public async Task<AntDto?> SaveAsync(AntDto antDto, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _mapper.Map<Ant>(antDto);

                entity.Color = await _context.AntColors.FirstAsync(ac => ac.Id == antDto.Color.Id, cancellationToken);
                entity.Direction = await _context.Directions.FirstAsync(d => d.Id == antDto.Direction.Id, cancellationToken);

                var addedEntity = await _context.Ants.AddAsync(entity, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return _mapper.Map<AntDto>(addedEntity.Entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error saving ant entity");
                throw;
            }
        }
    }
}
