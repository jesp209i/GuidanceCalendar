using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace GuidanceCalendar.Application.Configure
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationConfiguration(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
