using Autofac;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using SafeToNet.SafetyIndicator.Api.Controllers;
using SafeToNet.SafetyIndicator.Core.Ioc;
using SafeToNet.SafetyIndicator.Core.Repositories;
using SafeToNet.SafetyIndicator.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SafeToNet.SafetyIndicator.TestHelper
{
    //public static class MockIoc
    //{
    //    public static readonly IServiceCollection ServiceCollection;

    //    public static void Register(this ContainerBuilder builder)
    //    {
    //        ServiceCollection = new ServiceCollection();
    //        RegisterDependencies();
    //        RegisterRepositories();
    //    }

    //    private static void RegisterDependencies()
    //    {
    //        // MS Ioc implementation
    //        // ServiceCollection.RegisterServices();
    //    }

    //    private static void RegisterRepositories()
    //    {
    //        var repository = new Mock<ISafetyIndicatorRepository>();
    //        var loggerService = new Mock<ILogger<SafetyIndicatorController>>();
    //        var insightService = new Mock<ISafetyIndicatorService>();

    //        repository
    //            .Setup(s => s.Insert(It.IsAny<IEnumerable<Core.Models.Entities.SafetyIndicator>>())).Returns(Task.CompletedTask);

    //        ServiceCollection.AddSingleton(repository.Object);
    //        ServiceCollection.AddSingleton(loggerService.Object);
    //        ServiceCollection.AddSingleton(insightService.Object);
    //        ServiceCollection.AddTransient<SafetyIndicatorController>();
    //    }
    //}
}
