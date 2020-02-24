using System;
using System.Threading.Tasks;
using GuidanceCalendar.API.Viewmodels.Commands;
using GuidanceCalendar.Ports.In.Interfaces.Application;
using Microsoft.AspNetCore.Mvc;

namespace GuidanceCalendar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarController : ControllerBase
    {
        private readonly  ICalendarService _calendarService;
        public CalendarController(ICalendarService calendarService)
        {
            _calendarService = calendarService;
        }
        [HttpGet]
        public async Task<IActionResult> AvailableCalendars()
        {
            throw new NotImplementedException();
            //return Ok(await _calendarService.Send(new AvaliableCalendarsRequest()));
        }
        [HttpPost]
        public async Task<IActionResult> CreateCalendar([FromBody]CreateCalendarCommand request)
        {
            //var response = await _calendarService.CreateCalendar(name, description);
            //return Created("", new { Id = response });
            return Ok(request);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCalendar(Guid id)
        {
            throw new NotImplementedException();
            //return Ok(new { Id = id });
            //return Ok(await _calendarService.Send(new GetCalendarQuery { Id = id }));
        }
    }
}