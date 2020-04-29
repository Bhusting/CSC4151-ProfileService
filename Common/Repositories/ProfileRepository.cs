
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Common.Builders;
using Common.Clients;
using Common.Settings;
using Domain;
using SqlCommandBuilder = Common.Builders.SqlCommandBuilder;

namespace Common.Repositories
{
    public class ProfileRepository : IProfileRepository
    {

        private readonly SqlClient _sqlClient;

        public ProfileRepository(SqlClient sqlClient)
        {
            _sqlClient = sqlClient;
        }

        /// <summary>
        /// Retrieves a profile from the Profile Table.
        /// </summary>
        /// <param name="id">Id of the Profile to retrieve.</param>
        /// <returns>User Profile</returns>
        public async Task<Profile> GetProfile(Guid id)
        {
            var cmd = SqlCommandBuilder.GetIndividualRecordBuilder(typeof(Profile), id);

            var profile = await _sqlClient.Get<Profile>(cmd);

            return profile[0];
        }
    }
}
