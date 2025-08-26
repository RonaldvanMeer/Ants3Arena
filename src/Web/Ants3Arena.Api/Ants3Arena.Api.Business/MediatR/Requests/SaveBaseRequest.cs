using Ants3Arena.Api.Business.MediatR.Responses;
using Ants3Arena.Api.Models.Dtos;
using MediatR;

namespace Ants3Arena.Api.Business.MediatR.Requests
{
    public class SaveBaseRequest<T> : IRequest<SaveBaseResponse<T>> where T: BaseDto
    {
        public T Data { get; set; } = null!;
    }
}
