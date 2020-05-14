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

            var profile = JsonConvert.DeserializeObject<House>(body);

            Assert.True(profile.HouseId == Guid.Empty);
        }


    }
}
