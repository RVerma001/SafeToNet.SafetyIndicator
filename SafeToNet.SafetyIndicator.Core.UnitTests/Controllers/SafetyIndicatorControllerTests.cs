using Microsoft.AspNetCore.Mvc;
using SafeToNet.SafetyIndicator.TestHelper;
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
    }
}