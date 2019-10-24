using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.Serializers;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using OpenTracing.Contrib.NetCore.CoreFx;
using SafeToNet.Commons.IoC;
using SafeToNet.Commons.Validations;
using SafeToNet.Configuration.Models.Entities;
using SafeToNet.HeaderPropogation;
using SafeToNet.SafetyIndicator.Core.Ioc;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SafeToNet.SafetyIndicator.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; private set; }

        public ILifetimeScope AutofacContainer { get; private set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = BindConfiguration(configuration);
        }
        
        private static IConfiguration BindConfiguration(IConfiguration configuration)
        {
            configuration.GetSection("API").Bind(ApplicationConfiguration.Api);
            configuration.GetSection("Azure").Bind(ApplicationConfiguration.Azure);
            configuration.GetSection("Database").Bind(ApplicationConfiguration.Database);
            configuration.GetSection("JwtIssuerOptions").Bind(ApplicationConfiguration.JwtIssuerOptions);
            configuration.GetSection("AuthSettings").Bind(ApplicationConfiguration.AuthSettings);

            return configuration;
        }
        
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();

            services.AddHealthChecks();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest).AddControllersAsServices()
                .AddJsonOptions(
                options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.Formatting = Formatting.Indented;
                    options.SerializerSettings.ContractResolver =
                        new DefaultContractResolver();
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Include;
                })
                 .AddMvcOptions(options =>
                     options.Filters.Add<ModelValidationAttribute>());

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = ApplicationConfiguration.Api.Name,
                    Version = ApplicationConfiguration.Api.Version
                });

                c.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description =
                        "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });
                c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                {
                    {"Bearer", Enumerable.Empty<string>()}
                });
            });

            services.AddHeaderPropagation(options =>
            {
                options.HeaderNames.Add("Authorization");
                options.HeaderNames.Add("x-request-id");
                options.HeaderNames.Add("x-b3-traceid");
                options.HeaderNames.Add("x-b3-spanid");
                options.HeaderNames.Add("x-b3-parentspanid");
                options.HeaderNames.Add("x-b3-sampled");
                options.HeaderNames.Add("x-b3-flags");
                options.HeaderNames.Add("x-ot-span-context");
            });
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest).AddControllersAsServices()
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.None;
                    options.SerializerSettings.Formatting = Formatting.Indented;
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                });

            ConventionRegistry.Remove("__defaults__");
            var conventionPack = new ConventionPack
            {
                new StringObjectIdIdGeneratorConvention(), new CamelCaseElementNameConvention()
            };


            BsonSerializer.RegisterSerializer(new GuidSerializer().WithRepresentation(BsonType.String));

            services.Configure<HttpHandlerDiagnosticOptions>(options =>
            {
                options.IgnorePatterns.Add(x => !x.RequestUri.IsLoopback);
            });

            services.AddLogging();
            services.AddHttpClient();
            services.Configure<HttpHandlerDiagnosticOptions>(options =>
            {
                options.IgnorePatterns.Add(x => !x.RequestUri.IsLoopback);
            });

            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterServices();
            containerBuilder.RegisterRepositories();

            containerBuilder.Populate(services);

            var container = containerBuilder.Build();

            return new AutofacServiceProvider(container);
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterRepositories();
            builder.RegisterServices();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseHealthChecks("/probes/health");
            app.UseHealthChecks("/probes/readiness");
            app.UseHealthChecks("/probes/liveness");

            if (Environment.GetEnvironmentVariable("HOSTING_STATION") == "local")
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                    $"{ApplicationConfiguration.Api.Name} {ApplicationConfiguration.Api.Version}");
            });

            app.UseSwagger();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}