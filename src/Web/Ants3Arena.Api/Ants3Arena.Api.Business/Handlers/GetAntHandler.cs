using Ants3Arena.Api.Business.MediatR.Requests;
using Ants3Arena.Api.Business.MediatR.Responses;
using Ants3Arena.Api.Business.Services;
using Ants3Arena.Api.Models.Dtos;
using MediatR;

namespace Ants3Arena.Api.Business.Handlers
{
    public class GetAntHandler : IRequestHandler<GetBaseRequest<AntDto>, GetBaseResponse<AntDto>>
    {
        private readonly IBaseService<AntDto> _baseService;
        public GetAntHandler(IBaseService<AntDto> baseService)
        {
            _baseService = baseService;
        }

        public async Task<GetBaseResponse<AntDto>> Handle(GetBaseRequest<AntDto> request, CancellationToken cancellationToken)
        {
            var result = await _baseService.GetByIdAsync(request.Id, cancellationToken);
            return new GetBaseResponse<AntDto> { Data = result };
            }
    }
}
