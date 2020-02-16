using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuidanceCalendar.Application.CalendarService.Commands.CreateCalendar;
using GuidanceCalendar.Application.CalendarService.Queries.AvaliableCalendars;
using GuidanceCalendar.Application.CalendarService.Queries.GetCalendar;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GuidanceCalendar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarController : ControllerBase
    {
        private IMediator _mediator;
        public CalendarController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> AvailableCalendars()
        {
            return Ok(await _mediator.Send(new AvaliableCalendarsRequest()));
        }
        [HttpPost]
        public async Task<IActionResult> CreateCalendar(CreateCalendarCommand request)
        {
            var response = await _mediator.Send(request);
            return Created("", new { Id = response.Id});
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCalendar(Guid id)
        {
            //return Ok(new { Id = id });
            return Ok(await _mediator.Send(new GetCalendarQuery { Id = id }));
        }
    }
}