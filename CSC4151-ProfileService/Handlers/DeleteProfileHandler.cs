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
    public class DeleteProfileHandler : IMessageHandler
    {
        private readonly ILogger<DeleteProfileHandler> _logger;
        private readonly SqlClient _sqlClient;

        public DeleteProfileHandler(ILogger<DeleteProfileHandler> logger, SqlClient sqlClient)
        {
            _logger = logger;
            _sqlClient = sqlClient;
        }

        public async Task Handle(string messageBody)
        {
            var profileId = JsonConvert.DeserializeObject<Guid>(messageBody);

            _logger.LogInformation($"Deleting User {profileId}");

            var cmd = SqlCommandBuilder.DeleteRecord(typeof(Profile), profileId);

            await _sqlClient.Delete(cmd);
        }
    }
}
