using Common.Clients;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Common.Builders;
using Domain;

namespace Common.Repositories
{
    public class HouseRepository : IHouseRepository
    {
        private readonly SqlClient _sqlClient;

        public HouseRepository(SqlClient sqlClient)
        {
            _sqlClient = sqlClient;
        }

        public async Task<House> GetHouse(Guid id)
        {
            var cmd = SqlCommandBuilder.GetIndividualRecordBuilder(typeof(House), id);

            var house = await _sqlClient.Get<House>(cmd);

            return house[0];
        }

        public async Task<House> GetHouseByProfile(Guid id)
        {
            var cmd = SqlCommandBuilder.GetIndividualParentFromId(typeof(Profile), typeof(House), id);

            var house = await _sqlClient.Get<House>(cmd);

            return house[0];
        }
    }
}
