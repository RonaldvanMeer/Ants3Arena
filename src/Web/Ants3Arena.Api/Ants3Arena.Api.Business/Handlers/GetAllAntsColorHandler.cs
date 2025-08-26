using Ants3Arena.Api.Business.MediatR.Requests;
using Ants3Arena.Api.Business.MediatR.Responses;
using Ants3Arena.Api.Business.Services;
using Ants3Arena.Api.Models.Dtos;
using MediatR;

namespace Ants3Arena.Api.Business.Handlers
{
    public class GetAllAntsColorHandlerBaseHandler : IRequestHandler<GetAllBaseRequest<AntColorDto>, GetAllBaseResponse<AntColorDto>>
    {
        private readonly IBaseService<AntColorDto> _baseService;

        public GetAllAntsColorHandlerBaseHandler(IBaseService<AntColorDto> baseService)
        {
            _baseService = baseService;
        }

        public async Task<GetAllBaseResponse<AntColorDto>> Handle(GetAllBaseRequest<AntColorDto> request, CancellationToken cancellationToken)
        {
            var result = await _baseService.GetAllAsync(cancellationToken);
            return new GetAllBaseResponse<AntColorDto> { Data = result };
        }
    }
}
