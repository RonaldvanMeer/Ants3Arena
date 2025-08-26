using Ants3Arena.Api.Business.MediatR.Requests;
using Ants3Arena.Api.Business.MediatR.Responses;
using Ants3Arena.Api.Business.Services;
using Ants3Arena.Api.Models.Dtos;
using MediatR;

namespace Ants3Arena.Api.Business.Handlers
{
    public class GetAllDirectionHandlerBaseHandler : IRequestHandler<GetAllBaseRequest<DirectionDto>, GetAllBaseResponse<DirectionDto>>
    {
        private readonly IBaseService<DirectionDto> _baseService;

        public GetAllDirectionHandlerBaseHandler(IBaseService<DirectionDto> baseService)
        {
            _baseService = baseService;
        }

        public async Task<GetAllBaseResponse<DirectionDto>> Handle(GetAllBaseRequest<DirectionDto> request, CancellationToken cancellationToken)
        {
            var result = await _baseService.GetAllAsync(cancellationToken);
            return new GetAllBaseResponse<DirectionDto> { Data = result };
        }
    }
}
