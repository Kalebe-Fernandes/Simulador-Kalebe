using Microsoft.AspNetCore.Mvc;
using SimuladorCredito.Testes.UnitTestsController;
using SimuladorCredito.WebApi.Controllers;

namespace SimuladorCredito.Testes.UnitTests
{
    public class PersonTypeTests(UnitTestController unitTestController) : IClassFixture<UnitTestController>
    {
        private readonly PersonTypeController _controller = new(unitTestController.personTypeService);

        [Fact]
        public async Task GetAll_OkResult()
        {
            var personTypes = await _controller.GetAllAsync();
            var okResult = Assert.IsType<OkObjectResult>(personTypes.Result);
            Assert.Equal(200, okResult.StatusCode);
        }
    }
}
