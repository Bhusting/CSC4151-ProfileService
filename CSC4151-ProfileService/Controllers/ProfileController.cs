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
        [HttpGet("{id}/XP")]
        public async Task<int> GetXP(Guid id)
        {
            _logger.LogInformation($"Get XP {id}");

            var profile = await _profileRepository.GetProfile(id);

            return profile.XP;
        }

        /// <summary>
        /// Retrieves a User from Email
        /// </summary>
        /// <param name="email">Email of the User</param>
        /// <returns>User Profile</returns>
        [HttpGet("Email")]
        public async Task<Profile> GetProfileByEmail()
        {
            Request.Headers.TryGetValue("Email", out var value);

            var emails = value.AsEnumerable();

            var email = emails.First();

            _logger.LogInformation($"Get Profile Email {email}");

            var profile = await _profileRepository.GetProfileByEmail(email);

            return profile;
        }

        [HttpGet("House/{houseId}")]
        public async Task<List<Profile>> GetHouseProfiles(Guid houseId)
        {

            _logger.LogInformation($"Get Profiles {houseId}");

            var profiles = await _profileRepository.GetHouseProfiles(houseId);

            return profiles;
        }
    }
}
