using Ants3Arena.Api.Business.MediatR.Responses;
using Ants3Arena.Api.Models.Dtos;
using MediatR;

namespace Ants3Arena.Api.Business.MediatR.Requests
{
    public class GetAllBaseRequest<T> : IRequest<GetAllBaseResponse<T>> where T : BaseDto
    {
    }
}
