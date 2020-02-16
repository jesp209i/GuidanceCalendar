using GuidanceCalendar.Domain.Common;
using System;
using System.Collections.Generic;

namespace GuidanceCalendar.Domain
{
    public class Calendar : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public ICollection<Timeslot> AvailableTimeslots { get; private set; }
        public Calendar(string name, string description = "")
        {
            AvailableTimeslots = new List<Timeslot>();
            Name = name;
            Description = description;
        }
        public Calendar()
        {

        }
    }
}
