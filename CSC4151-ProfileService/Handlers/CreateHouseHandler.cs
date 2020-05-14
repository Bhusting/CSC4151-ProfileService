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
    public class CreateHouseHandler : IMessageHandler
    {
        private readonly ILogger<CreateHouseHandler> _logger;
        private readonly SqlClient _sqlClient;

        public CreateHouseHandler(ILogger<CreateHouseHandler> logger, SqlClient sqlClient)
        {
            _logger = logger;
            _sqlClient = sqlClient;
        }

        public async Task Handle(string messageBody)
        {
            _logger.LogInformation("Creating House");

            var house = JsonConvert.DeserializeObject<House>(messageBody);

            house.HouseId = Guid.NewGuid();

            var cmd = SqlCommandBuilder.InsertRecord(house);

            await _sqlClient.Insert(cmd);

        }
    }
}
