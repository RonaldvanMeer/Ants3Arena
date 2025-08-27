using Ant3Arena.Business.Ants;
using Ant3Arena.Business.Helpers;
using Ant3Arena.Business.HttpClients;
using Ant3Arena.Business.Interfaces;

namespace Ant3Arena.Business.Services
{
    public class AntsService : IAntsService
    {
        private readonly IAntsClient _antsClient;
        private readonly Random _random;

        private Dictionary<string, string> _antColors = new()
        {
            { "Red", "#FF0000" },
            { "Yellow", "#FFFF00" },
            { "Black", "#000000" },
            { "White", "#FFFFFF" }
        };

        public AntsService(IAntsClient antsClient, Random random)
        {
            _antsClient = antsClient;
            _random = random;
        }

        public async Task<IEnumerable<IAnt>> GetAllAntsAsync()
        {
            IEnumerable<AntViewModel> allAnts = await _antsClient.GetAllAntsAsync();

            return allAnts.Select(ant
                => new Ant(ScreenHelper.GetScreenSize(),
                ant.VerticalVelocity,
                ant.HorizontalVelocity, 
                _antColors.Single(k => k.Key == ant.Color.Name).Value, 
                ant.Direction.Name,
                _random));
        }
    }
}
