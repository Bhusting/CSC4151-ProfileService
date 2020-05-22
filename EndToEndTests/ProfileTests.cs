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
        //private readonly Uri _path = new Uri("https://takprofile.azurewebsites.net");
        private readonly Uri _path = new Uri("http://localhost:5000");

        [Fact]
        public async Task GetProfile()
        {
            var httpClient = new HttpClient() { BaseAddress = _path };

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
            var httpClient = new HttpClient() { BaseAddress = _path };

            var str = "Profile/Email";
            var list = new List<string>();
            list.Add("theruxter18@hotmail.com");

            httpClient.DefaultRequestHeaders.Add("Email", list);
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

            var httpClient = new HttpClient() { BaseAddress = _path };

            var str = $"Profile/House/{Guid.Empty}";

            var res = await httpClient.GetAsync(str);

            Assert.True(res.IsSuccessStatusCode);

            var body = await res.Content.ReadAsStringAsync();

            var profiles = JsonConvert.DeserializeObject<List<Profile>>(body);

        }
    }
}

