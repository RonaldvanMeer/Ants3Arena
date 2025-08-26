using Ants3Arena.Api.Business.MediatR.Responses;
using Ants3Arena.Api.Models.Dtos;
using MediatR;

namespace Ants3Arena.Api.Business.MediatR.Requests
{
    public class GetBaseRequest<T> : IRequest<GetBaseResponse<T>> where T : BaseDto
    {
        public Guid Id { get; set; }
    }
}
