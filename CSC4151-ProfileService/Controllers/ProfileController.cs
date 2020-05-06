using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Common.Repositories;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CSC4151_ProfileService.Controllers
{
    [ApiController]
    [Route("Profile")]
    public class ProfileController : ControllerBase
    {
        private readonly ILogger<ProfileController> _logger;
        private readonly IProfileRepository _profileRepository;

        public ProfileController(ILogger<ProfileController> logger, IProfileRepository profileRepository)
        {
            _logger = logger;
            _profileRepository = profileRepository;
        }

        /// <summary>
        /// Retrieves a Profile from SQL.
        /// </summary>
        /// <param name="id">Id of the profile to retrieve.</param>
        /// <returns>User Profile</returns>
        [HttpGet("{id}")]
        public async Task<Profile> GetProfile(Guid id)
        {
            _logger.LogInformation($"Get Profile {id}");

            var profile = await _profileRepository.GetProfile(id);

            return profile;
        }

        /// <summary>
        /// Retrieves a Users XP Value.
        /// </summary>
        /// <param name="id">Id of the profile to retrieve.</param>
        /// <returns>XP value.</returns>
        public async Task<int> GetXP(Guid id)
        {
            _logger.LogInformation($"Get XP {id}");

            var profile = await _profileRepository.GetProfile(id);

            return profile.XP;
        }
    }
}
