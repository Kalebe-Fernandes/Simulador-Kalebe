using Microsoft.AspNetCore.Mvc;
using SimuladorCredito.Testes.UnitTestsController;
using SimuladorCredito.WebApi.Controllers;

namespace SimuladorCredito.Testes.UnitTests
{
    public class ProductTests(UnitTestController unitTestController) : IClassFixture<UnitTestController>
    {
        private readonly ProductController _controller = new(unitTestController.productService);

        [Fact]
        public async Task GetAll_OkResult()
        {
            var products = await _controller.GetAllAsync();
            var okResult = Assert.IsType<OkObjectResult>(products.Result);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async Task GetProdutoByNamePersonType_OKResult()
        {
            var personTypeName = "Pessoa Física";
            var data = await _controller.GetByPersonTypeAsync(personTypeName);
            var okResult = Assert.IsType<OkObjectResult>(data.Result);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async Task GetProdutoByNamePersonType_Return_NotFound()
        {
            var personTypeName = "Pessoa";
            var data = await _controller.GetByPersonTypeAsync(personTypeName);

            var notFoundResult = Assert.IsType<NotFoundObjectResult>(data.Result);
            Assert.Equal(404, notFoundResult.StatusCode);
        }
    }
}
