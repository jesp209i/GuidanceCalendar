using GuidanceCalendar.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuidanceCalendar.Persistence.Configure
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.HasKey(t => t.Id);

            builder.HasMany(t => t.Calendars)
                .WithOne();
            builder.HasMany(t => t.AvailableTimeslots)
                .WithOne(ts => ts.TimeslotOwner)
                .HasForeignKey("TeacherId");

        }
    }
}
