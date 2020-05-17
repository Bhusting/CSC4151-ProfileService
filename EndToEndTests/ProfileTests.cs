using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Domain;
using Newtonsoft.Json;
using Xunit;

namespace EndToEndTests
{
    public class ProfileTests
    {
        [Fact]
        public async Task GetProfile()
        {
            var httpClient = new HttpClient() { BaseAddress = new Uri("http://localhost:5000") };

            var res = await httpClient.GetAsync($"Profile/{Guid.Empty}");

            Assert.True(res.IsSuccessStatusCode);

            var body = await res.Content.ReadAsStringAsync();

            var profile = JsonConvert.DeserializeObject<Profile>(body);

            Assert.True(profile.ProfileId == Guid.Empty);
            Assert.True(profile.FirstName == "Rodney");
        }

        [Fact]
        public async Task GetProfileByEmail()
        {
            var httpClient = new HttpClient() { BaseAddress = new Uri("http://localhost:5000") };

            var str = "Profile/Email/theruxter18@hotmail";

            var res = await httpClient.GetAsync(str);

            Assert.True(res.IsSuccessStatusCode);

            var body = await res.Content.ReadAsStringAsync();

            var profile = JsonConvert.DeserializeObject<Profile>(body);

            Assert.True(profile.ProfileId == Guid.Empty);
            Assert.True(profile.FirstName == "Rodney");
        }

        [Fact]
        public async Task GetHouseProfiles()
        {

            var httpClient = new HttpClient() { BaseAddress = new Uri("http://localhost:5000") };

            var str = $"Profile/House/{Guid.Empty}";

            var res = await httpClient.GetAsync(str);

            Assert.True(res.IsSuccessStatusCode);

            var body = await res.Content.ReadAsStringAsync();

            var profiles = JsonConvert.DeserializeObject<List<Profile>>(body);


        }
    }
}

