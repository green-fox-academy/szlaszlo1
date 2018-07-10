using Frontend;
using Frontend.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace FrontEndTestProject
{
    public class UnitTest1
    {
        public TestServer Server { get; set; }
        public HttpClient Client { get; set; }

        public UnitTest1()
        {
            Server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            Client = Server.CreateClient();
        }


        [Fact]
        public void Test1()
        {
            //arrange
            Assert.Equal(1, 1);

        }

        [Fact]
        public async Task DoublingWithNoNumber()
        {
            var response = await Client.GetAsync("/doubling");
            //var noNumber = await JsonConvert.DeserializeObject<Error>(await response.Content.ReadAsStringAsync());

            Assert.Equal("{\"error\":\"Please provide an input!\"}", await response.Content.ReadAsStringAsync());
        }

        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(-6)]
        public async Task DoublingWithNumber(int input)
        {
            var response = await Client.GetAsync("/doubling?input="+input);
            //var doubleObject = JsonConvert.DeserializeObject<GeneralResponse>(await response.Content.ReadAsStringAsync());
            //GeneralResponse gr = new GeneralResponse() { Input = input, Result = input * 2 };

            Assert.Equal(JsonConvert.SerializeObject(new { received = input, result = input * 2 }),
                         response.Content.ReadAsStringAsync().Result);

        }
        [Theory]
        [InlineData(null, null)]
        [InlineData(null, "megtorló")]
        public async Task GreetingWithoutName(string name, string title)
        {
            var response = await Client.GetAsync($"/greeter?name={name}&title={title}");
            Assert.Equal(JsonConvert.SerializeObject(new { error = "Please provide a name!" }), response.Content.ReadAsStringAsync().Result);
        }

        [Theory]
        [InlineData("Petit",null)]
        [InlineData("Alex",null)]
        public async Task GreetingWithNameWithoutTitle(string name, string title)
        {
            var response = await Client.GetAsync($"/greeter?name={name}&title={title}");
            Assert.Equal(JsonConvert.SerializeObject(new { error = "Please provide a title!" }), response.Content.ReadAsStringAsync().Result);
        }

        [Theory]
        [InlineData("Petit", "megtorló")]
        [InlineData("Alex", "ninja")]
        public async Task GreetingWithParameters(string name, string title)
        {
            var response = await Client.GetAsync($"/greeter?name={name}&title={title}");
            Assert.Equal(JsonConvert.SerializeObject(new { welcome_message = "Oh, hi there " + name + ", my dear " + title + "!" }), response.Content.ReadAsStringAsync().Result);
        }


        [Theory]
        [InlineData("kuty")]
        [InlineData("macs")]
        public async Task AppendA(string appendable)
        {
            var response = await Client.GetAsync($"/appenda?appendable={appendable}");
            Assert.Equal(JsonConvert.SerializeObject(new { appended = appendable + "a" }), response.Content.ReadAsStringAsync().Result);
        }
    }
}
