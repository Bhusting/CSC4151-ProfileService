using System;
using System.Net.Http;
using System.Threading.Tasks;
using Domain;
using Newtonsoft.Json;
using Xunit;

namespace EndToEndTests
{
    public class UnitTest1
    {
        [Fact]
        public async Task GetProfile()
        {
            var httpClient = new HttpClient() { BaseAddress = new Uri("http://localhost:32770") };

            var res = await httpClient.GetAsync($"Profile/{Guid.Empty}");

            Assert.True(res.IsSuccessStatusCode);

            var body = await res.Content.ReadAsStringAsync();

            var profile = JsonConvert.DeserializeObject<Profile>(body);

            Assert.True(profile.ProfileId == Guid.Empty);
            Assert.True(profile.FirstName == "Rodney");
        }



    }
}

