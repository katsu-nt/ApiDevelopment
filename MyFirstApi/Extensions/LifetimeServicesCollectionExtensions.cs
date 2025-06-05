using System;
using MyFirstApi.Services;

namespace MyFirstApi.Extensions;

public static class LifetimeServicesCollectionExtensions
{
    public static IServiceCollection AddLifetimeServices(this IServiceCollection services)
    {
        services.AddScoped<IPostService, PostsService>();
        return services;
    } 
}
