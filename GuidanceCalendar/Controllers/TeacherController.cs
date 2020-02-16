using GuidanceCalendar.Application.TeacherService.Commands.CreateTimeslot;
using GuidanceCalendar.Application.TeacherService.Queries.GetAvailableTimeslots;
using GuidanceCalendar.Application.TeacherService.Queries.GetTeachers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuidanceCalendar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private IMediator _mediator;
        public TeacherController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("{teacherId}/timeslot")]
        public async Task<IActionResult> CreateTimeslot([FromBody]CreateTimeslotCommand request)
        {
            var response = await _mediator.Send(request);
            return Created("", new { Id = response.Id });
        }
        [HttpGet("{teacherId}/timeslot")]
        public async Task<IActionResult> GetAvailableTimeslots(Guid teacherId)
        {
            return Ok(await _mediator.Send(new GetAvailableTimeslotsQuery { TeacherId = teacherId }));
        }
        [HttpGet]
        public async Task<IActionResult> GetTeachers()
        {
            return Ok(await _mediator.Send(new GetTeachersQuery()));
        }
        [HttpGet("time")]
        public async Task<IActionResult> Time()
        {
            return Ok(new { Time = DateTime.UtcNow });
        }
    }
}
