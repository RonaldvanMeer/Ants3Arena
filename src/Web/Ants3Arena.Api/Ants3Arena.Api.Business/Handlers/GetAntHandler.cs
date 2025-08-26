using Ants3Arena.Api.Business.MediatR.Requests;
using Ants3Arena.Api.Business.MediatR.Responses;
using MediatR;

namespace Ants3Arena.Api.Business.Handlers
{
    public class GetAntHandler : IRequestHandler<GetAntRequest, GetAntResponse>
    {
        public Task<GetAntResponse> Handle(GetAntRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
