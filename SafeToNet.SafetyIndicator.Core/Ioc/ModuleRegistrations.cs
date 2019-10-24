using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
//using SafeToNet.Configuration.Models.Entities;
using SafeToNet.SafetyIndicator.Core.Repositories;
using SafeToNet.SafetyIndicator.Core.Services;


namespace SafeToNet.SafetyIndicator.Core.Ioc
{
    public static class ModuleRegistration
    {
        //private static IMongoClient CreateMongoDbClient()
        //{
        //    return new MongoClient(ApplicationConfiguration.Azure.CosmosDb.ConnectionString);
        //}

        //private static IMongoDatabase CreateMongoDatabase(this IMongoClient mongoClient)
        //{
        //    return mongoClient.GetDatabase(ApplicationConfiguration.Database.Name);
        //}

        //public static void RegisterServices(this IServiceCollection serviceCollection)
        //{
        //    serviceCollection.AddTransient<IInsightsService, InsightsService>();
        //}

        //public static void RegisterRepositories(this IServiceCollection serviceCollection)
        //{
        //    var client = CreateMongoDbClient();
        //    var database = client.CreateMongoDatabase();

        //    /* ApplicationConfiguration.Database.Collection.FirstOrDefault(l => 
        //    l.Equals(nameof(Models.Entities.Insights), StringComparison.InvariantCultureIgnoreCase));*/
        //    //  var strikeCollectionName = /*ApplicationConfiguration.Database.Collection.FirstOrDefault(l =>
        //    //       l.Equals($"{nameof(Models.Entities.Strike)}s", StringComparison.InvariantCultureIgnoreCase));*/

        //    var insightsCollection =
        //        database.GetCollection<Models.Entities.Insights>("insights");

        //    serviceCollection.AddSingleton<IInsightsRepository, InsightsRepository>(s =>
        //        new InsightsRepository(client, insightsCollection, ApplicationConfiguration.Database.Name,
        //            "insights"));

        //}
    }
}