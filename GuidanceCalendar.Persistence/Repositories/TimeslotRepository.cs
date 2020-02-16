using GuidanceCalendar.Domain;
using GuidanceCalendar.Domain.Interfaces.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuidanceCalendar.Persistence.Repositories
{
    public class TimeslotRepository : BaseRepository<Timeslot>, ITimeslotRepository
    {
        public TimeslotRepository(GuidanceCalendarContext dbContext) : base(dbContext)
        {
        }
    }
}
