using Ant3Arena.Business.HttpClients;
using Ant3Arena.Business.Interfaces;

namespace Ant3Arena.Business.Services
{
    public interface IAntsService
    {
        Task<IEnumerable<IAnt>> GetAllAntsAsync();
    }
}
