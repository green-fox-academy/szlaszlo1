using Frontend;
using Frontend.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
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
            var response = await Client.GetAsync($"/appenda/{appendable}");
            Assert.Equal(JsonConvert.SerializeObject(new { appended = appendable + "a" }), response.Content.ReadAsStringAsync().Result);
        }
        [Fact]
        public async Task AppendaWithoutArgument()
        {
            var respnse = await Client.GetAsync($"/appenda");
            var statusCode = respnse.StatusCode;
            Assert.Equal(HttpStatusCode.NotFound, statusCode);
        }

        [Fact]
        public async Task DoUntilWithoutWhat()
        {
            var body = JsonConvert.SerializeObject(new Until() { until = 5 });
            var respnse = await Client.PostAsync("/dountil",new StringContent(body,Encoding.UTF8,"application/json"));
            var statusCode = respnse.StatusCode;
            Assert.Equal(HttpStatusCode.NotFound, statusCode);
        }
        [Fact]
        public async Task DoUntilSumWithoutUntil()
        {
            var body = JsonConvert.SerializeObject(new Until());
            var response = await Client.PostAsync("/dountil/sum", new StringContent(body, Encoding.UTF8, "application/json"));
            Assert.Equal(JsonConvert.SerializeObject(new { error = "Please provide a number!" }), response.Content.ReadAsStringAsync().Result);
        }
        [Fact]
        public async Task DoUntilFactorWithoutUntil()
        {
            var body = JsonConvert.SerializeObject(new Until());
            var response = await Client.PostAsync("/dountil/factor", new StringContent(body, Encoding.UTF8, "application/json"));
            Assert.Equal(JsonConvert.SerializeObject(new { error = "Please provide a number!" }), response.Content.ReadAsStringAsync().Result);
        }
        [Fact]
        public async Task DoUntilSumWithUntil()
        {
            Until until = new Until() { until = 5 };
            var body = JsonConvert.SerializeObject(until);
            int untilSum = UntilModelMethods.CalculateSum(until.until);
            var response = await Client.PostAsync("/dountil/sum", new StringContent(body, Encoding.UTF8, "application/json"));
            Assert.Equal(JsonConvert.SerializeObject(new { result = untilSum }), response.Content.ReadAsStringAsync().Result);
        }
        [Fact]
        public async Task DoUntilFactorWithUntil()
        {
            Until until = new Until() { until = 5 };
            int untilFactorial = UntilModelMethods.CalculateFactor(until.until);
            var body = JsonConvert.SerializeObject(until);
            var response = await Client.PostAsync("/dountil/factor", new StringContent(body, Encoding.UTF8, "application/json"));
            Assert.Equal(JsonConvert.SerializeObject(new { result = untilFactorial }), response.Content.ReadAsStringAsync().Result);
        }



        [Fact]
        public async Task ArraysWithoutWhat()
        {
            Arrays intArray = new Arrays() { Numbers =new int[]{1,2,5,10 }  };
            var body = JsonConvert.SerializeObject(intArray);
            var response = await Client.PostAsync("/arrays", new StringContent(body, Encoding.UTF8, "application/json"));
            Assert.Equal(JsonConvert.SerializeObject(new { error = "Please provide what to do with the numbers!" }), response.Content.ReadAsStringAsync().Result);
        }

        [Fact]
        public async Task ArraysWithoutNumbers()
        {
            Arrays intArray = new Arrays() {What="sum" };
            var body = JsonConvert.SerializeObject(intArray);
            var response = await Client.PostAsync("/arrays", new StringContent(body, Encoding.UTF8, "application/json"));
            Assert.Equal(JsonConvert.SerializeObject(new { error = "Please provide numbers!" }), response.Content.ReadAsStringAsync().Result);
        }
    }
}
