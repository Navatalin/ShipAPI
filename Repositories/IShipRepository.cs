namespace ShipAPI.Repositories{
    using System.Threading.Tasks;
    using ShipAPI.Models;

    public interface IShipRepository
    {
        Task<Ship> GetAsync(int id);
        Task AddShip(Ship ship);
        Task<bool> UpdateShipLocation(Ship ship, int planetId);
    }
}