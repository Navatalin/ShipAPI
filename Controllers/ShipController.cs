namespace ShipAPI.Controllers{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using ShipAPI.Models;
    using ShipAPI.Services;

    [Route("startrucker/api/v1/[controller]")]
    [ApiController]
    public class ShipController : ControllerBase
    {
        private readonly ILogger<ShipController> _logger;
        private readonly IShipService _shipService;

        public ShipController(ILogger<ShipController> logger, IShipService shipService){
            _logger = logger;
            _shipService = shipService;
        }

        [Route("{shipId:int}")]
        [HttpGet]
        public async Task<ActionResult<Ship>> GetShip(int shipId){
            return await _shipService.GetShipById(shipId);
        }

        [Route("")]
        [HttpPost]
        public async Task<ActionResult> AddShip([FromBody]Ship ship){
            var result = await _shipService.AddShip(ship);

            if(!result){
                return BadRequest();
            }

            return Ok();
        }
        [Route("{shipId:int}/location/update")]
        [HttpPost]
        public async Task<ActionResult> UpdateLocation([FromBody]int planetId,int shipId){
            var ship = await _shipService.GetShipById(shipId);
            if(ship != null){
                var result = await _shipService.UpdateShipLocation(ship, planetId);

                if(!result){
                    return BadRequest();
                }
                return Ok();
            }
            return BadRequest();
        }
    }
}