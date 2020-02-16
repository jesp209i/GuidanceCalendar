using GuidanceCalendar.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GuidanceCalendar.Domain
{
    public class Teacher : Entity
    {
        public string Name { get; private set; }
        public ICollection<Timeslot> AvailableTimeslots { get; private set; }
        public ICollection<Calendar> Calendars { get; private set; }
        public Teacher(string name)
        {
            Name = name;
            AvailableTimeslots = new List<Timeslot>();
            Calendars = new List<Calendar>();
        }
        public void AddTimeslot(Timeslot timeslot)
        {
            OverlapGuard(timeslot);
            AvailableTimeslots.Add(timeslot);
        }
        private void OverlapGuard(Timeslot timeslot)
        {
            foreach(var ts in AvailableTimeslots)
            {
                ts.OverlapGuard(timeslot);
            }
        }
        public Teacher()
        {

        }
    }
}