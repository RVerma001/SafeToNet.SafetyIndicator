using Microsoft.AspNetCore.Mvc;
using SafeToNet.SafetyIndicator.Api.Controllers;
using SafeToNet.SafetyIndicator.TestHelper;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Autofac;
using Xunit;

namespace SafeToNet.SafetyIndicator.Core.UnitTests.Controllers
{
    //class SafetyIndicatorControllerTests
    //{
    //    private readonly IServiceProvider _serviceProvider;

    //    public SafetyIndicatorControllerTest()
    //    {
    //        var serviceCollection = new MockIoc().ServiceCollection;
    //        _serviceProvider = serviceCollection.BuildServiceProvider();
    //    }

    //    [Fact]
    //    public void CreateInsights_ValidResponse()
    //    {
    //        //Arrange
    //        SafetyIndicatorController controller = _serviceProvider.GetService<SafetyIndicatorController>();

    //        //Act
    //        var result = controller.CreateInsights(StaticData.InsightsRequests)?.Result as OkResult;

    //        //Assert
    //        Assert.NotNull(result);
    //        Assert.Equal(200, result.StatusCode);
    //    }

    //    [Fact]
    //    public void CreateInsights_InvalidResponse()
    //    {
    //        //Arrange
    //        SafetyIndicatorController controller = _serviceProvider.GetService<SafetyIndicatorController>();

    //        //Act
    //        var result = controller.CreateInsights(StaticData.NullInsights)?.Result as BadRequestResult;

    //        //Assert
    //        Assert.NotNull(result);
    //        Assert.Equal(400, result.StatusCode);
    //    }

    //    [Fact]
    //    public void GetInsightsBetweenTimes_ValidResponse()
    //    {
    //        //Arrange
    //        SafetyIndicatorController controller = _serviceProvider.GetService<SafetyIndicatorController>();

    //        //Act
    //        var result = controller.GetInsightsBetweenTimes(StaticData.DeviceID)?.Result as OkObjectResult;

    //        //Assert
    //        Assert.NotNull(result);
    //        Assert.Equal(200, result.StatusCode);
    //    }

    //    [Fact]
    //    public void GetInsightsBetweenTimes_InvalidResponse()
    //    {
    //        //Arrange
    //        SafetyIndicatorController controller = _serviceProvider.GetService<SafetyIndicatorController>();

    //        //Act
    //        var result = controller.GetInsightsBetweenTimes(Guid.Empty)?.Result as BadRequestResult;

    //        //Assert
    //        Assert.NotNull(result);
    //        Assert.Equal(400, result.StatusCode);
    //    }
    //}

}