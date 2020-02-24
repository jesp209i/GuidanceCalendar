using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuidanceCalendar.API.Viewmodels.Commands
{
    public class CreateCalendarCommand
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
