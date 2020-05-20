using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Builders;
using Common.Clients;
using Common.Repositories;
using Domain;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CSC4151_ProfileService.Handlers
{
    public class DeleteProfileHandler : IMessageHandler
    {
        private readonly ILogger<DeleteProfileHandler> _logger;
        private readonly IProfileRepository _profileRepository;

        public DeleteProfileHandler(ILogger<DeleteProfileHandler> logger, IProfileRepository profileRepository)
        {
            _logger = logger;
            _profileRepository = profileRepository;
        }

        public async Task Handle(string messageBody)
        {
            var profileId = JsonConvert.DeserializeObject<Guid>(messageBody);

            _logger.LogInformation($"Deleting User {profileId}");

            await _profileRepository.DeleteProfile(profileId);
        }
    }
}
