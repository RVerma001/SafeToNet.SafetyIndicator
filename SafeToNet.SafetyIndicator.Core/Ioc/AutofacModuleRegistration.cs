using Autofac;
using SafeToNet.Commons.IoC;
using SafeToNet.Configuration.Models.Entities;
using SafeToNet.SafetyIndicator.Core.Repositories;
using SafeToNet.SafetyIndicator.Core.Services;
using System;
using System.Linq;

namespace SafeToNet.SafetyIndicator.Core.Ioc
{
    public static class AutofacModuleRegistration
    {
        public static void RegisterRepositories(this ContainerBuilder builder)
        {
            var client = Commons.IoC.ModuleRegistrationExtensions.CreateMongoDbClient();
            var database = client.CreateMongoDatabase();

            var accessCollectionName = ApplicationConfiguration.Database.Collection.FirstOrDefault(a =>
                a.Contains(nameof(SafetyIndicator), StringComparison.InvariantCultureIgnoreCase));

            var accessCollection = database.GetCollection<Models.Entities.SafetyIndicator>(accessCollectionName);

            var accessRepository = new SafetyIndicatorRepository(client, accessCollection,
                ApplicationConfiguration.Database.Name, accessCollectionName);

            builder.RegisterInstance<ISafetyIndicatorRepository>(accessRepository);

            builder.RegisterType<SafetyIndicatorRepository>()
                .As<ISafetyIndicatorRepository>()
                .SingleInstance();

        }

        public static void RegisterServices(this ContainerBuilder builder)
        {
            builder.RegisterType<SafetyIndicatorService>()
                .As<ISafetyIndicatorService>()
                .InstancePerDependency();
        }
    }
}