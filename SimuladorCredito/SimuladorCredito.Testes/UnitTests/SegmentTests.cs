using Microsoft.AspNetCore.Mvc;
using SimuladorCredito.Testes.UnitTestsController;
using SimuladorCredito.WebApi.Controllers;

namespace SimuladorCredito.Testes.UnitTests
{
    public class SegmentTests(UnitTestController unitTestController) : IClassFixture<UnitTestController>
    {
        private readonly SegmentController _segmentController = new(unitTestController.segmentService);

        [Fact]
        public async Task GetAll_OkResult()
        {
            var segments = await _segmentController.GetAllAsync();
            var okResult = Assert.IsType<OkObjectResult>(segments.Result);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async Task GetSegmentByPersonTypeAsync_OkResult()
        {
            var personTypeName = "Pessoa Jurídica";
            var minimumIncome = 4001m;
            var segment = await _segmentController.GetSegmentByPersonTypeAsync(personTypeName, minimumIncome);

            var okResult = Assert.IsType<OkObjectResult>(segment.Result);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async Task GetSegmentByPersonTypeAsync_NotFoundResult()
        {
            var personTypeName = "Pessoa";
            var minimumIncome = 4001m;
            var segment = await _segmentController.GetSegmentByPersonTypeAsync(personTypeName, minimumIncome);

            var okResult = Assert.IsType<NotFoundResult>(segment.Result);
            Assert.Equal(404, okResult.StatusCode);
        }
    }
}
