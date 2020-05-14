using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Repositories;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CSC4151_ProfileService.Controllers
{
    [ApiController]
    [Route("House")]
    public class HouseController : ControllerBase
    {
        private readonly ILogger<HouseController> _logger;
        private readonly IHouseRepository _houseRepository;

        public HouseController(ILogger<HouseController> logger, IHouseRepository houseRepository)
        {
            _logger = logger;
            _houseRepository = houseRepository;
        }

        [HttpGet("{id}")]
        public async Task<House> GetHouse(Guid id)
        {
            _logger.LogInformation($"Get House {id}");

            var house = await _houseRepository.GetHouse(id);

            return house;
        }

        [HttpGet("Profile/{id}")]
        public async Task<House> GetHouseByProfile(Guid id)
        {
            _logger.LogInformation($"Get House by Profile {id}");

            var house = await _houseRepository.GetHouseByProfile(id);

            return house;
        }
                
    }
}
