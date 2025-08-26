using Ants3Arena.Api.Models.Dtos;

namespace Ants3Arena.Api.Business.MediatR.Responses
{
    public class GetAllBaseResponse<T> where T : BaseDto
    {
        public IEnumerable<T> Data { get; set; } = new List<T>();
    }
}
