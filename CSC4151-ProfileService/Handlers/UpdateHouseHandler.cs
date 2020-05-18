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
    public class UpdateHouseHandler : IMessageHandler
    {
        private readonly ILogger<UpdateHouseHandler> _logger;
        private readonly SqlClient _sqlClient;

        public UpdateHouseHandler(ILogger<UpdateHouseHandler> logger, SqlClient sqlClient)
        {
            _logger = logger;
            _sqlClient = sqlClient;
        }

        public async Task Handle(string messageBody)
        {
            var update = JsonConvert.DeserializeObject<KeyValuePair<Guid, Guid>>(messageBody);
            
            _logger.LogInformation($"Updating User House {update.Value}");

            var cmd = $"UPDATE Profile SET HouseId = \'{update.Value}\' WHERE ProfileId = \'{update.Key}\'";

            await _sqlClient.Update(cmd);

        }
    }
}
