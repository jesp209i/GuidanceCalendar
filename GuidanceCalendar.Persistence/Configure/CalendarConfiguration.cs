using GuidanceCalendar.Persistence.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuidanceCalendar.Persistence.Configure
{
    public class CalendarConfiguration : IEntityTypeConfiguration<CalendarDao>
    {
        public void Configure(EntityTypeBuilder<CalendarDao> builder)
        {
            builder.ToTable("Calendar");
            builder.HasKey(c => c.Id);

            builder.HasMany(c => c.AvailableTimeslots)
                .WithOne(ts => ts.Calendar)
                .HasForeignKey("CalendarId")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
