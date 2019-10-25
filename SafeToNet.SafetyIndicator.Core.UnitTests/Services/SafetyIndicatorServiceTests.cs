using Moq;
using SafeToNet.SafetyIndicator.Core.Models.Entities;
using SafeToNet.SafetyIndicator.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace SafeToNet.SafetyIndicator.Core.UnitTests.Services
{
    public class SafetyIndicatorServiceTests
    {
        private MockIoc Mock { get; set; }
        private List<InsightGraph> InsightGraphData { get; set; }

        public SafetyIndicatorServiceTests()
        {
            Mock = new MockIoc();
            InsightGraphData = StaticData.InsightGraphs;
        }

        [Fact]
        public void CreateInsights_CheckResponseCompleted()
        {
            // Arrange
            var data = StaticData.InsightsRequests;

            Mock.Service.Setup(x => x.CreateInsights(data));
          
            // Act
            var result = Mock.Service.Object.CreateInsights(data);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(TaskStatus.RanToCompletion, result.Status);
        }

        [Fact]
        public void GetLastDayByDeviceId_CountResponse()
        {
            // Arrange
            Mock.Service.Setup(x => x.GetLastOneDayAndDeviceIdBy(StaticData.DeviceID))
                .ReturnsAsync(InsightGraphData);

            // Act
            var result = Mock.Service.Object.GetLastOneDayAndDeviceIdBy(StaticData.DeviceID).Result;
            var insightsCount = result.Count();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(5, insightsCount);
        }

        [Fact]
        public void GetLastDayByDeviceId_CheckResponseType()
        {
            // Arrange
            Mock.Service.Setup(x => x.GetLastOneDayAndDeviceIdBy(StaticData.DeviceID))
                .ReturnsAsync(InsightGraphData);

            // Act
            var result = Mock.Service.Object.GetLastOneDayAndDeviceIdBy(StaticData.DeviceID).Result;

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IEnumerable<InsightGraph>>(result);
        }

        [Fact]
        public void GetLastDayByDeviceId_CheckFirstItemValues()
        {
            // Arrange
            Mock.Service.Setup(x => x.GetLastOneDayAndDeviceIdBy(StaticData.DeviceID))
                .ReturnsAsync(InsightGraphData);

            // Act
            var result = Mock.Service.Object.GetLastOneDayAndDeviceIdBy(StaticData.DeviceID).Result.ToList();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(new DateTime(2019, 09, 01, 15, 0, 0), result[0].DateGenerated);
            Assert.Equal(50.0M, result[0].Value);
        }

        [Fact]
        public void GetParentAlertInsights_CountResponse()
        {
            // Arrange
            Mock.Service.Setup(x => x.GetParentAlertInsights(StaticData.DeviceID, 10, 5))
                .ReturnsAsync(InsightGraphData);

            // Act
            var result = Mock.Service.Object.GetParentAlertInsights(StaticData.DeviceID, 10, 5).Result.ToList();
            var count = result.Count();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(5, count);
        }

        [Fact]
        public void GetParentAlertInsights_CheckResponseType()
        {
            // Arrange
            Mock.Service.Setup(x => x.GetParentAlertInsights(StaticData.DeviceID, 10, 5))
                .ReturnsAsync(InsightGraphData);

            // Act
            var result = Mock.Service.Object.GetParentAlertInsights(StaticData.DeviceID, 10, 5).Result.ToList();
            
            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IEnumerable<InsightGraph>>(result);
        }

        [Fact]
        public void GetParentAlertInsights_CheckFirstItemValues()
        {
            // Arrange
            Mock.Service.Setup(x => x.GetParentAlertInsights(StaticData.DeviceID, 10, 5))
                .ReturnsAsync(InsightGraphData);

            // Act
            var result = Mock.Service.Object.GetParentAlertInsights(StaticData.DeviceID, 10, 5).Result.ToList();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(new DateTime(2019, 09, 01, 15, 0, 0), result[0].DateGenerated);
            Assert.Equal(50.0M, result[0].Value);
        }
    }
}