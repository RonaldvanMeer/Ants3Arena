using Ants3Arena.Api.Business.MediatR.Requests;
using Ants3Arena.Api.Business.MediatR.Responses;
using Ants3Arena.Api.Business.Services;
using Ants3Arena.Api.Models.Dtos;
using MediatR;

namespace Ants3Arena.Api.Business.Handlers
{
    public class SaveAntHandler : IRequestHandler<SaveBaseRequest<AntDto>, SaveBaseResponse<AntDto>>
    {
        private readonly IBaseService<AntDto> _baseService;
        private readonly IBaseService<AntColorDto> _antColorService;
        private readonly IBaseService<DirectionDto> _directionService;

        public SaveAntHandler(IBaseService<AntDto> baseService, IBaseService<AntColorDto> antColorService, IBaseService<DirectionDto> directionService)
        {
            _baseService = baseService;
            _antColorService = antColorService;
            _directionService = directionService;
        }

        public async Task<SaveBaseResponse<AntDto>> Handle(SaveBaseRequest<AntDto> request, CancellationToken cancellationToken)
        {
            var result = await _baseService.SaveAsync(request.Data, cancellationToken);
            return new SaveBaseResponse<AntDto> { Data = result };
        }
    }
}
