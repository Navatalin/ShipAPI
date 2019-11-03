namespace ShipAPI.Services{
    using System.Threading.Tasks;
    using ShipAPI.Models;

    public interface IShipService
    {
        Task<Ship> GetShipById(int id);
        Task<bool> AddShip(Ship ship);
        Task<bool> UpdateShipLocation(Ship ship, int planetId);
        
    }
}