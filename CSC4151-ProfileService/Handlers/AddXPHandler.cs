using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Common.Clients;
using Common.Repositories;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CSC4151_ProfileService.Handlers
{
    public class AddXPHandler : IMessageHandler
    {
        private readonly ILogger<AddXPHandler> _logger;
        private readonly SqlClient _sqlClient;
        private readonly IProfileRepository _profileRepository;

        public AddXPHandler(ILogger<AddXPHandler> logger, SqlClient sqlClient, IProfileRepository profileRepository)
        {
            _logger = logger;
            _sqlClient = sqlClient;
            _profileRepository = profileRepository;
        }

        public async Task Handle(string messageBody)
        {
            var profileId = JsonConvert.DeserializeObject<Guid>(messageBody);

            _logger.LogInformation($"Updating User XP {profileId}");

            var profile = await _profileRepository.GetProfile(profileId);

            var xp = profile.XP + 1;

            var cmd = $"UPDATE Profile SET XP = {xp} WHERE ProfileId = \'{profileId}\'";

            await _sqlClient.Update(cmd);
        }
    }
}
