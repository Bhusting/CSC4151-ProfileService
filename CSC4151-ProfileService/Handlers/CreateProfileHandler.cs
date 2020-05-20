using Microsoft.Azure.ServiceBus;
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
    public class CreateProfileHandler : IMessageHandler
    {
        private readonly ILogger<CreateProfileHandler> _logger;
        private readonly IProfileRepository _profileRepository;

        public CreateProfileHandler(ILogger<CreateProfileHandler> logger, IProfileRepository profileRepository)
        {
            _logger = logger;
            _profileRepository = profileRepository;
        }

        public async Task Handle(string messageBody)
        {
            var profile = JsonConvert.DeserializeObject<Profile>(messageBody);

            _logger.LogInformation($"Creating User {profile.ProfileId}");

            await _profileRepository.CreateProfile(profile);
        }
    }
}
