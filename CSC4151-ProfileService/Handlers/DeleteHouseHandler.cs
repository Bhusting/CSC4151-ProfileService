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
    public class DeleteHouseHandler : IMessageHandler
    {
        private readonly ILogger<DeleteHouseHandler> _logger;
        private readonly SqlClient _sqlClient;

        public DeleteHouseHandler(ILogger<DeleteHouseHandler> logger, SqlClient sqlClient)
        {
            _logger = logger;
            _sqlClient = sqlClient;
        }

        public async Task Handle(string messageBody)
        {
            var houseId = JsonConvert.DeserializeObject<Guid>(messageBody);

            _logger.LogInformation($"Deleting User {houseId}");

            var cmd = SqlCommandBuilder.DeleteRecord(typeof(House), houseId);

            await _sqlClient.Delete(cmd);
        }
    }
}
