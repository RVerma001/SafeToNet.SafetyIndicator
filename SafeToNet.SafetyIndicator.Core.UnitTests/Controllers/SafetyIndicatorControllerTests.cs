using Microsoft.AspNetCore.Mvc;
using SafeToNet.SafetyIndicator.TestHelper;
using System.Threading.Tasks;
using Xunit;

namespace SafeToNet.SafetyIndicator.Core.UnitTests.Controllers
{
    public class SafetyIndicatorControllerTests
    {
        private MockIoc Mock { get; set; }

        public SafetyIndicatorControllerTests()
        {
            Mock = new MockIoc();
        }

        [Fact]
        public void Get_TestStatusCode_Ok()
        {
            // Arrange
            var controller = Mock.Controller;
          
            // Act
            var result = controller.Get();
            var okResult = result as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public void Get_CheckResponseText()
        {
            // Arrange
            const string expected = "Get SafetyIndicator";
            var controller = Mock.Controller;

            // Act
            var result = controller.Get();
            var okResult = result as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expected, okResult.Value);
        }

        [Fact]
        public void CreateInsights_Null_BadRequest()
        {
            // Arrange
            var data = StaticData.NullInsights;
            var controller = Mock.Controller;

            // Act
            var result = controller.CreateInsights(data);
            var badResult = result.Result as BadRequestResult;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestResult>(badResult);
        }

        [Fact]
        public void CreateInsights_Null_OkRequest()
        {
            // Arrange
            var data = StaticData.InsightsRequests;
            var controller = Mock.Controller;

            // Act
            var result = controller.CreateInsights(data);
            var okResult = result.Result as OkResult;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<OkResult>(okResult);
        }

        [Fact]
        public void GetInsightsBetweenTimes_Null_BadRequest()
        {
            // Arrange
            System.Guid data = System.Guid.Empty;
            var controller = Mock.Controller;

            // Act
            var result = controller.GetInsightsBetweenTimes(data);
            var badResult = result.Result as BadRequestResult;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestResult>(badResult);
        }

        [Fact]
        public async void GetInsightsBetweenTimes_Null_OkRequest()
        {
            // Arrange
            var data = StaticData.DeviceID;
            var controller = Mock.Controller;

            // Act
            var createResult = controller.CreateInsights(StaticData.InsightsRequests);

            await createResult;

            var result = controller.GetInsightsBetweenTimes(data);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(TaskStatus.RanToCompletion, result.Status);
        }
    }
}