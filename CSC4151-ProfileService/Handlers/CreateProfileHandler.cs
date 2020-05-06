using Microsoft.Azure.ServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Builders;
using Common.Clients;
using Domain;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CSC4151_ProfileService.Handlers
{
    public class CreateProfileHandler : IMessageHandler
    {
        private readonly ILogger<CreateProfileHandler> _logger;
        private readonly SqlClient _sqlClient;

        public CreateProfileHandler(ILogger<CreateProfileHandler> logger, SqlClient sqlClient)
        {
            _logger = logger;
            _sqlClient = sqlClient;
        }

        public async Task Handle(string messageBody)
        {
            _logger.LogInformation("Creating User");

            var profile = JsonConvert.DeserializeObject<Profile>(messageBody);

            profile.ProfileId = Guid.NewGuid();

            var cmd = SqlCommandBuilder.InsertRecord(profile);

            await _sqlClient.Insert(cmd);
        }
    }
}
