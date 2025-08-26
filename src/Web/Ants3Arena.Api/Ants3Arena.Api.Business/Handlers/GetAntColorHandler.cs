using Ants3Arena.Api.Business.MediatR.Requests;
using Ants3Arena.Api.Business.MediatR.Responses;
using Ants3Arena.Api.Business.Services;
using Ants3Arena.Api.Models.Dtos;
using MediatR;

namespace Ants3Arena.Api.Business.Handlers
{
    public class GetGetAntColorHandlerBaseHandler : IRequestHandler<GetBaseRequest<AntColorDto>, GetBaseResponse<AntColorDto>>
    {
        private readonly IBaseService<AntColorDto> _baseService;

        public GetGetAntColorHandlerBaseHandler(IBaseService<AntColorDto> baseService)
        {
            _baseService = baseService;
        }

        public async Task<GetBaseResponse<AntColorDto>> Handle(GetBaseRequest<AntColorDto> request, CancellationToken cancellationToken)
        {
            var result = await _baseService.GetByIdAsync(request.Id, cancellationToken);
            return new GetBaseResponse<AntColorDto> { Data = result };
        }
    }
}
