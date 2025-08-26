using Ants3Arena.Api.Business.MediatR.Requests;
using Ants3Arena.Api.Business.MediatR.Responses;
using Ants3Arena.Api.Business.Services;
using Ants3Arena.Api.Models.Dtos;
using MediatR;

namespace Ants3Arena.Api.Business.Handlers
{
    public class GetDirectionHandler: IRequestHandler<GetBaseRequest<DirectionDto>, GetBaseResponse<DirectionDto>>
    {
        private readonly IBaseService<DirectionDto> _baseService;

        public GetDirectionHandler(IBaseService<DirectionDto> baseService)
        {
            _baseService = baseService;
        }

        public async Task<GetBaseResponse<DirectionDto>> Handle(GetBaseRequest<DirectionDto> request, CancellationToken cancellationToken)
        {
            var result = await _baseService.GetByIdAsync(request.Id, cancellationToken);
            return new GetBaseResponse<DirectionDto> { Data = result };
        }
    }
}
