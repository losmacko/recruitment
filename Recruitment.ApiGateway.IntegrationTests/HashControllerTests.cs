using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using Recruitment.ApiGateway.Services;
using Recruitment.Common.Models;

namespace Recruitment.ApiGateway.IntegrationTests
{
    [TestFixture]
    public class Tests : WebApplicationFactory<Startup>
    {
        private readonly Mock<WebApi> _webApiMoq; 

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(WebApi));
                services.Remove(descriptor);
                services.AddTransient(provider =>
                {
                    var moq = new Mock<IWebApi>();
                    return moq.Object;
                });
            });
        }
     
       [Test]
        public async Task ShouldReturnOk()
        {
            //Arrange
            var httpClient = this.CreateClient();

            //Act
            var responseMessage = await httpClient.PostAsJsonAsync("/api/Hash", new LoginDataRequest{Login = "str", Password = "str"});

            //Act
            responseMessage.EnsureSuccessStatusCode();
            Assert.AreEqual(responseMessage.StatusCode, HttpStatusCode.OK);
        }
        ///
        ///
        ///
        ///
        ///
        ///
        ///
        ///
        /// More tests
    }
}