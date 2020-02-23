using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuidanceCalendar.Application.Port.In
{
    public abstract class ApplicationService
    {
        protected readonly IMediator _mediator;

        public ApplicationService(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
