using Microsoft.AspNetCore.Mvc;
using SimuladorCredito.Testes.UnitTestsController;
using SimuladorCredito.WebApi.Controllers;

namespace SimuladorCredito.Testes.UnitTests
{
    public class ModalityTests(UnitTestController unitTestController) : IClassFixture<UnitTestController>
    {
        private readonly ModalityController _controller = new(unitTestController.modalityService);

        [Fact]
        public async Task GetAll_OkResult()
        {
            var modalities = await _controller.GetAllAsync();
            var okResult = Assert.IsType<OkObjectResult>(modalities.Result);
            Assert.Equal(200, okResult.StatusCode);
        }
    }
}
