using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using Xunit;

namespace EcoColeta.Tests
{
    public class ControllersStatusCodeTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public ControllersStatusCodeTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Get_TiposResiduos_ReturnsHttpStatusCode200()
        {
            var response = await _client.GetAsync("/api/TipoResiduo");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Get_PontosColeta_ReturnsHttpStatusCode200()
        {
            var response = await _client.GetAsync("/api/PontoColeta");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Get_ColetasResiduos_ReturnsHttpStatusCode200()
        {
            var response = await _client.GetAsync("/api/ColetaResiduo");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}