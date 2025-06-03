using Microsoft.AspNetCore.Mvc;
using SimuladorCredito.Testes.UnitTestsController;
using SimuladorCredito.WebApi.Controllers;

namespace SimuladorCredito.Testes.UnitTests
{
    public class RateTests(UnitTestController unitTestController) : IClassFixture<UnitTestController>
    {
        private readonly RateController _controller = new(unitTestController.rateService);

        [Fact]
        public async Task GetAll_OkResult()
        {
            var rates = await _controller.GetAllAsync();
            var okResult = Assert.IsType<OkObjectResult>(rates.Result);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async Task GetRateByAsync_OkResult()
        {
            var rate = await _controller.GetRateByAsync("Pessoa Física", "Pré-Fixado", "Empréstimo Pessoal", "PF2");
            var okResult = Assert.IsType<OkObjectResult>(rate.Result);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async Task GetRateByAsync_NotFoundResult()
        {
            var rate = await _controller.GetRateByAsync("Pessoa Física", "Pré-Fixado", "Empréstimo Pessoal", "PF5");
            var okResult = Assert.IsType<NotFoundObjectResult>(rate.Result);
            Assert.Equal(404, okResult.StatusCode);
        }
    }
}
