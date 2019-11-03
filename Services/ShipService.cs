namespace ShipAPI.Services{
    using System.Threading.Tasks;
    using ShipAPI.Models;
    using ShipAPI.Repositories;
    using Microsoft.Extensions.Logging;

    public class ShipService : IShipService
    {
        private readonly IShipRepository _shipRepository;
        private readonly ILogger<ShipService> _logger;

        public ShipService(ILogger<ShipService> logger, IShipRepository shipRepository){
            _logger = logger;
            _shipRepository = shipRepository;
            _shipRepository.AddShip(new Ship{
                ShipId = 1,
                ShipName = "Test Ship",
                ShipSpeed = 1.0
            });
        }
        public async Task<Ship> GetShipById(int id){
            return await _shipRepository.GetAsync(id);
        }

        public async Task<bool> AddShip(Ship ship){
            await _shipRepository.AddShip(ship);
            return true;
        }

        public async Task<bool> UpdateShipLocation(Ship ship, int planetId){
            return await _shipRepository.UpdateShipLocation(ship, planetId);
        }
    }
}