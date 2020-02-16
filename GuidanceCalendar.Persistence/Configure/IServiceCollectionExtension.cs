using GuidanceCalendar.Domain.Interfaces.Persistence;
using GuidanceCalendar.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuidanceCalendar.Persistence
{
    public static class IServiceCollectionExtension
    {

        public static IServiceCollection AddDatabaseContext(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<GuidanceCalendarContext>(options => 
                //options.UseInMemoryDatabase("GuidanceCalendar"));
                options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
            services.AddScoped<ICalendarRepository, CalendarRepository>();
            services.AddScoped<ITimeslotRepository, TimeslotRepository>();
            services.AddScoped<IBookingRepository, BookingRepository >();
            services.AddScoped<ITeacherRepository, TeacherRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();

            return services;
        }
    }
}
