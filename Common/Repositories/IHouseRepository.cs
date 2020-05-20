using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Common.Repositories
{
    public interface IHouseRepository
    {

        Task<House> GetHouse(Guid id);

        Task<House> GetHouseByProfile(Guid id);

        Task CreateHouse(House house);

        Task DeleteHouse(Guid houseId);
    }
}
