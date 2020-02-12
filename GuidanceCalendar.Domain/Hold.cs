using GuidanceCalendar.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuidanceCalendar.Domain
{
    public class Hold : Entity
    {
        public string Name { get; private set; }
        public Calendar Calendar { get; private set; }
        public Hold(string name)
        {
            Name = name;
        }
    }
}
