using Ants3Arena.Api.Business.MediatR.Requests;
using Ants3Arena.Api.Business.MediatR.Responses;
using Ants3Arena.Api.Business.Services;
using Ants3Arena.Api.Models.Dtos;
using MediatR;

namespace Ants3Arena.Api.Business.Handlers
{
    public class SaveAntColorHandler : IRequestHandler<SaveBaseRequest<AntColorDto>, SaveBaseResponse<AntColorDto>>
    {
        private readonly IBaseService<AntColorDto> _baseService;
        public SaveAntColorHandler(IBaseService<AntColorDto> baseService)
        {
            _baseService = baseService;
        }

        public async Task<SaveBaseResponse<AntColorDto>> Handle(SaveBaseRequest<AntColorDto> request, CancellationToken cancellationToken)
        {
            var result = await _baseService.SaveAsync(request.Data, cancellationToken);
            return new SaveBaseResponse<AntColorDto> { Data = result };
        }
    }
}
