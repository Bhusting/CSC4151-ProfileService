using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Newtonsoft.Json;
using Xunit;

namespace EndToEndTests
{
    public class HouseTests
    {

        [Fact]
        public async Task GetHouse()
        {
            var httpClient = new HttpClient() { BaseAddress = new Uri("http://localhost:5000") };

            var res = await httpClient.GetAsync($"House/{Guid.Empty}");

            Assert.True(res.IsSuccessStatusCode);

            var body = await res.Content.ReadAsStringAsync();

            var house = JsonConvert.DeserializeObject<House>(body);

            Assert.True(house.HouseId == Guid.Empty);
        }

        [Fact]
        public async Task GetHouseByProfile()
        {
            var httpClient = new HttpClient() { BaseAddress = new Uri("http://localhost:5000") };

            var res = await httpClient.GetAsync($"House/Profile/{Guid.Empty}");

            Assert.True(res.IsSuccessStatusCode);

            var body = await res.Content.ReadAsStringAsync();

            var house = JsonConvert.DeserializeObject<House>(body);

            Assert.True(house.HouseId == Guid.Empty);
        }
    }
}
