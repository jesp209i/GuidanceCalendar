using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuidanceCalendar.Persistence
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddDatabaseContext(this IServiceCollection services)
        {
            services.AddDbContext<CalendarContext>(options => options.UseInMemoryDatabase("GuidanceCalendar"));
            return services;
        }
    }
}
