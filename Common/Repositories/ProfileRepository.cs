
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Builders;
using Common.Clients;
using Common.Settings;
using Domain;
using Microsoft.Extensions.Logging;
using SqlCommandBuilder = Common.Builders.SqlCommandBuilder;

namespace Common.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly ILogger<ProfileRepository> _logger;
        private readonly SqlClient _sqlClient;

        public ProfileRepository(ILogger<ProfileRepository> logger, SqlClient sqlClient)
        {
            _logger = logger;
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

        public async Task<Profile> GetProfileByEmail(string email)
        {
            var cmd = $"SELECT * FROM Profile WHERE Email = \'{email}\'";

            var profile = await _sqlClient.Get<Profile>(cmd);

            return profile[0];
        }

        public async Task<List<Profile>> GetHouseProfiles(Guid houseId)
        {
            var cmd = SqlCommandBuilder.GetIndividualParentFromId(typeof(House), typeof(Profile), houseId);

            var profiles = await _sqlClient.Get<Profile>(cmd);

            profiles.Sort((profile, profile1) => { return profile1.XP.CompareTo(profile.XP); });

            return profiles;
        }

        public async Task CreateProfile(Profile profile)
        {
            var cmd = SqlCommandBuilder.InsertRecord(profile);

            await _sqlClient.Insert(cmd);
        }

        public async Task DeleteProfile(Guid profileId)
        {
            var cmd = SqlCommandBuilder.DeleteRecord(typeof(Profile), profileId);

            await _sqlClient.Delete(cmd);
        }
    }
}
