using GuidanceCalendar.Ports.In.Application;
using GuidanceCalendar.Application.Port.In;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using GuidanceCalendar.Application.Port.Out;
using GuidanceCalendar.Ports.Out.Persistence;

namespace GuidanceCalendar.Application.Configure
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationConfiguration(this IServiceCollection services)
        {
            services.AddTransient<ITeacherPersistencePort, TeacherPersistencePort>();
            services.AddTransient<ICalendarPersistencePort, CalendarPersistencePort>();
            services.AddTransient<ITeacherService, TeacherService>();
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
