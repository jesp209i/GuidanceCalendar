using System;
using System.Collections.Generic;
using System.Text;

namespace GuidanceCalendar.Domain.Common
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }
    }
}
