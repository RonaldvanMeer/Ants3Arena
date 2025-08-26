using Ants3Arena.Api.Models.Dtos;

namespace Ants3Arena.Api.Business.MediatR.Responses
{
    public class GetAntResponse
    {
        public AntDto Ant { get; set; } = new AntDto();
    }
}
