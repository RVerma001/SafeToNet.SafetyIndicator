using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SafeToNet.SafetyIndicator.Core.UnitTests.Services
{
    //public class SafetyIndicatorServiceTests
    //{

    //    private readonly IServiceProvider _serviceProvider;

    //    public SafetyIndicatorServiceTests()
    //    {
    //        var serviceCollection = new MockIoc().ServiceCollection;
    //        _serviceProvider = serviceCollection.BuildServiceProvider();
    //    }

    //    [Fact]
    //    public void CreateStrike_Returns_StrikeResponse()
    //    {
    //        var strike = StaticData.Strike;
    //        var serviceCollection = new MockIoc().ServiceCollection;
    //        var repository = new Mock<IStrikeRepository>();

    //        repository.Setup(r => r.Insert(It.IsAny<IEnumerable<Models.Entities.Strike>>()));
    //        serviceCollection.AddSingleton(repository.Object);

    //        var serviceProvider = serviceCollection.BuildServiceProvider();

    //        var strikeService = serviceProvider.GetService<IStrikeService>();

    //        strikeService.CreateStrike(StaticData.StrikeRequests);

    //        repository.Verify(r => r.Insert(It.IsAny<IEnumerable<Models.Entities.Strike>>()));
    //    }

    //    [Fact]
    //    public void CreateStrike_Null_StrikeRequest_ThrowsNullReferenceException()
    //    {
    //        var strikeService = _serviceProvider.GetService<IStrikeService>();

    //        Assert.ThrowsAsync<ArgumentException>(() => strikeService.CreateStrike(null));
    //    }
    //     * private readonly IServiceProvider _serviceProvider;

    //    public StrikeServiceTests()
    //    {
    //        var serviceCollection = new MockIoc().ServiceCollection;
    //        _serviceProvider = serviceCollection.BuildServiceProvider();
    //    }

    //    [Fact]
    //    public void CreateStrike_Returns_StrikeResponse()
    //    {
    //        var strike = StaticData.Strike;
    //        var serviceCollection = new MockIoc().ServiceCollection;
    //        var repository = new Mock<IStrikeRepository>();

    //        repository.Setup(r => r.Insert(It.IsAny<IEnumerable<Models.Entities.Strike>>()));
    //        serviceCollection.AddSingleton(repository.Object);

    //        var serviceProvider = serviceCollection.BuildServiceProvider();

    //        var strikeService = serviceProvider.GetService<IStrikeService>();

    //        strikeService.CreateStrike(StaticData.StrikeRequests);

    //        repository.Verify(r => r.Insert(It.IsAny<IEnumerable<Models.Entities.Strike>>()));
    //    }

    //    [Fact]
    //    public void CreateStrike_Null_StrikeRequest_ThrowsNullReferenceException()
    //    {
    //        var strikeService = _serviceProvider.GetService<IStrikeService>();

    //        Assert.ThrowsAsync<ArgumentException>(() => strikeService.CreateStrike(null));
    //    }
    //    private readonly IServiceProvider _serviceProvider;

    //    public StrikeServiceTests()
    //    {
    //        var serviceCollection = new MockIoc().ServiceCollection;
    //        _serviceProvider = serviceCollection.BuildServiceProvider();
    //    }

    //    [Fact]
    //    public void CreateStrike_Returns_StrikeResponse()
    //    {
    //        var strike = StaticData.Strike;
    //        var serviceCollection = new MockIoc().ServiceCollection;
    //        var repository = new Mock<IStrikeRepository>();

    //        repository.Setup(r => r.Insert(It.IsAny<IEnumerable<Models.Entities.Strike>>()));
    //        serviceCollection.AddSingleton(repository.Object);

    //        var serviceProvider = serviceCollection.BuildServiceProvider();

    //        var strikeService = serviceProvider.GetService<IStrikeService>();

    //        strikeService.CreateStrike(StaticData.StrikeRequests);

    //        repository.Verify(r => r.Insert(It.IsAny<IEnumerable<Models.Entities.Strike>>()));
    //    }

    //    [Fact]
    //    public void CreateStrike_Null_StrikeRequest_ThrowsNullReferenceException()
    //    {
    //        var strikeService = _serviceProvider.GetService<IStrikeService>();

    //        Assert.ThrowsAsync<ArgumentException>(() => strikeService.CreateStrike(null));
    //    }

    //}

}
