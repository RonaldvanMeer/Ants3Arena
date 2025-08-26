using Ants3Arena.Api.Models.Dtos;

namespace Ants3Arena.Api.Business.Services
{
    public interface IAntService
    {
        Task<AntDto> GetAntAsync();
    }
}
