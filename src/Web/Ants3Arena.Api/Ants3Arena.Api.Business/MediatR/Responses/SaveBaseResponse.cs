using Ants3Arena.Api.Models.Dtos;

namespace Ants3Arena.Api.Business.MediatR.Responses
{
    public class SaveBaseResponse<T> where T : BaseDto
    {
        public T? Data { get; set; }
    }
}
