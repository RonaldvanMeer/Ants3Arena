using Ants3Arena.Api.Business.MediatR.Requests;
using Ants3Arena.Api.Business.MediatR.Responses;
using Ants3Arena.Api.Business.Services;
using Ants3Arena.Api.Models.Dtos;
using MediatR;

namespace Ants3Arena.Api.Business.Handlers
{
    public class SaveDirectionHandler : IRequestHandler<SaveBaseRequest<DirectionDto>, SaveBaseResponse<DirectionDto>>
    {
        private readonly IBaseService<DirectionDto> _baseService;
        public SaveDirectionHandler(IBaseService<DirectionDto> baseService)
        {
            _baseService = baseService;
        }

        public async Task<SaveBaseResponse<DirectionDto>> Handle(SaveBaseRequest<DirectionDto> request, CancellationToken cancellationToken)
        {
            var result = await _baseService.SaveAsync(request.Data, cancellationToken);
            return new SaveBaseResponse<DirectionDto> { Data = result };
        }
    }
}
