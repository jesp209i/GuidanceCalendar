using GuidanceCalendar.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuidanceCalendar.Persistence.Configure
{
    public class TimeslotConfiguration : IEntityTypeConfiguration<Timeslot>
    {
        public void Configure(EntityTypeBuilder<Timeslot> builder)
        {
            builder.HasKey(ts => ts.Id);
            builder.HasOne(ts => ts.TimeslotOwner)
                .WithMany(t => t.AvailableTimeslots)
                .HasForeignKey("TeacherId");
            builder.HasOne(ts => ts.Calendar)
                .WithMany(c => c.AvailableTimeslots);
        }
    }
}
