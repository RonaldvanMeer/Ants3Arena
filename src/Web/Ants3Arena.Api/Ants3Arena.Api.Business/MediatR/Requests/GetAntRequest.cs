using Ants3Arena.Api.Business.MediatR.Responses;
using Ants3Arena.Api.Models.Dtos;
using MediatR;

namespace Ants3Arena.Api.Business.MediatR.Requests
{
    public class GetAntRequest : IRequest<GetAntResponse>
    {
        public Guid ColorId { get; set; }
    }
}
