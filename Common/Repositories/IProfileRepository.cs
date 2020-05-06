using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Common.Repositories
{
    public interface IProfileRepository
    {
        /// <summary>
        /// Retrieves a profile from the Profile Table.
        /// </summary>
        /// <param name="id">Id of the Profile to retrieve.</param>
        /// <returns>User Profile</returns>
        Task<Profile> GetProfile(Guid id);
    }
}
