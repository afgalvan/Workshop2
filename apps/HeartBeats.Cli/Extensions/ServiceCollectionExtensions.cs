using System.Reflection;
using Application.People.Create;
using Application.People.Delete;
using Application.People.Find;
using Application.People.GetAll;
using Domain.People;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HeartBeats.Cli.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddHostedServices(this IServiceCollection services)
        {
            services.AddHostedService<App>();
        }

        public static void AddApplicationServices(
            this IServiceCollection services, IConfiguration configuration)
        {
            // services.AddSingleton(new JsonPersonRepository(configuration["File"]));
            services.AddScoped<IMediator, Mediator>();
            services.AddScoped<IPersonRepository, JsonPersonRepository>();
            services.AddScoped<PersonCreator>();
            services.AddScoped<PeopleGiver>();
            services.AddScoped<PersonFinder>();
            services.AddScoped<PersonDeleter>();
            services.AddMediatR(Assembly.Load("Application"));
        }
    }
}
