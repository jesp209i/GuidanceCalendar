using System;
using System.Threading.Tasks;
using GuidanceCalendar.API.Mapper;
using GuidanceCalendar.API.Viewmodels.Commands;
using GuidanceCalendar.Ports.In.Application;
using Microsoft.AspNetCore.Mvc;

namespace GuidanceCalendar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarController : ControllerBase
    {
        private readonly  ICalendarService _calendarService;
        private readonly ViewmodelMapper _viewmodelMapper;

        public CalendarController(ICalendarService calendarService, ViewmodelMapper viewmodelMapper)
        {
            _calendarService = calendarService;
            _viewmodelMapper = viewmodelMapper;
        }
        [HttpGet]
        public async Task<IActionResult> AvailableCalendars()
        {
            var calendars = await _calendarService.GetAvailableCalendars();
            return Ok(_viewmodelMapper.ConvertToCalendarListDTO(calendars));
        }
        [HttpPost]
        public async Task<IActionResult> CreateCalendar([FromBody]CreateCalendarCommand request)
        {
            var response = await _calendarService.CreateCalendar(request.Name, request.Description);
            return Created("", new { Id = response });
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCalendar(Guid id)
        {
            return Ok(await _calendarService.GetCalendar(id));
        }
    }
}