using GuidanceCalendar.Persistence.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuidanceCalendar.Persistence.Configure
{
    public class StudentConfiguration : IEntityTypeConfiguration<StudentDao>
    {
        public void Configure(EntityTypeBuilder<StudentDao> builder)
        {
            builder.ToTable("Student");
            builder.HasKey(s => s.Id);
            builder.HasMany(s => s.Bookings)
                .WithOne(b => b.BookedBy)
                .HasForeignKey("StudentId");
        }
    }
}
