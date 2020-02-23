using GuidanceCalendar.Persistence.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuidanceCalendar.Persistence.Configure
{
    public class BookingConfiguration : IEntityTypeConfiguration<BookingDao>
    {
        public void Configure(EntityTypeBuilder<BookingDao> builder)
        {
            builder.ToTable("Booking");
            builder.HasKey(b => b.Id);
            builder.HasOne(b => b.BookedBy)
                .WithMany(s => s.Bookings);
        }
    }
}
