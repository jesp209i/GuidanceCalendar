using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuidanceCalendar.Application.StudentService.Commands.CreateBooking;
using GuidanceCalendar.Application.StudentService.Queries.GetBookingHistory;
using GuidanceCalendar.Application.StudentService.Queries.GetStudents;
using GuidanceCalendar.Application.StudentService.Queries.UpcommingBookings;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GuidanceCalendar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediator;
        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("{studentId}")]
        public async Task<IActionResult> CreateBooking([FromBody]CreateBookingCommand request)
        {
            return Ok(await _mediator.Send(request));
        }
        [HttpGet("{studentId}")]
        public async Task<IActionResult> UpcommingBookings([FromRoute]UpcommingBookingsQuery request)
        {
            return Ok(await _mediator.Send(request));
        }
        [HttpGet("{studentId}/history")]
        public async Task<IActionResult> UpcommingBookings([FromRoute]GetBookingHistoryQuery request)
        {
            return Ok(await _mediator.Send(request));
        }
        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            return Ok(await _mediator.Send(new GetStudentsQuery()));
        }
    }
}