using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuidanceCalendar.Application.TimeslotService.Queries.GetBookingsInTimeslot;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GuidanceCalendar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeslotController : ControllerBase
    {
        private IMediator _mediator;

        public TimeslotController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{timeslotId}")]
        public async Task<IActionResult> GetBookingsInTimeslot([FromRoute]GetBookingsInTimeslotQuery request)
        {
            return Ok(await _mediator.Send(request));
        }
    }
}