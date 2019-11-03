namespace ShipAPI.Repositories{
    using System.Threading.Tasks;
    using ShipAPI.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class ShipRepository : IShipRepository{
        private List<Ship> _ships;

        public ShipRepository(){
            _ships = new List<Ship>();
        }

        public async Task<Ship> GetAsync(int id){
            var ship = await Task.Run(() => _ships.FirstOrDefault(x => x.ShipId == id));
            if(ship is null){
                return null;
            }
            else{
                return ship;
            }
        }

        public async Task AddShip(Ship ship){
            await Task.Run(() => _ships.Add(ship));
        }
        public async Task<bool> UpdateShipLocation(Ship ship, int planetId){
            var s = await Task.Run(() => _ships.FirstOrDefault(x => x.ShipId == ship.ShipId));
            if(s != null){
                s.PlanetId = planetId;
                return true;
            }
            return false;
        }
    }
}