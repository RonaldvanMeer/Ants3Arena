using Ants3Arena.Api.Business.MediatR.Requests;
using Ants3Arena.Api.Business.MediatR.Responses;
using Ants3Arena.Api.Business.Services;
using Ants3Arena.Api.Models.Dtos;
using MediatR;

namespace Ants3Arena.Api.Business.Handlers
{
    public class GetAllAntsHandlerBaseHandler : IRequestHandler<GetAllBaseRequest<AntDto>, GetAllBaseResponse<AntDto>>
    {
        private readonly IBaseService<AntDto> _baseService;

        public GetAllAntsHandlerBaseHandler(IBaseService<AntDto> baseService)
        {
            _baseService = baseService;
        }

        public async Task<GetAllBaseResponse<AntDto>> Handle(GetAllBaseRequest<AntDto> request, CancellationToken cancellationToken)
        {
            var result = await _baseService.GetAllAsync(cancellationToken);
            return new GetAllBaseResponse<AntDto> { Data = result };
        }
    }
}
