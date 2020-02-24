using GuidanceCalendar.API.Adapter;
using GuidanceCalendar.API.Viewmodels.Commands;
using GuidanceCalendar.Ports.In.Interfaces.Application;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GuidanceCalendar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;
        private readonly ViewmodelAdapter _viewmodelAdapter;

        public TeacherController(ITeacherService teacherService, ViewmodelAdapter viewmodelAdapter)
        {
            _teacherService = teacherService;
            _viewmodelAdapter = viewmodelAdapter;
        }
        [HttpPost("{teacherId}/timeslot")]
        public async Task<IActionResult> CreateTimeslot([FromBody] CreateTimeslotCommand request)
        {
            var response = await _teacherService.CreateTimeslot(request.TeacherId, request.CalendarId, request.StartTime, request.EndTime);
            return Created("", new { Id = response });
        }
        [HttpGet("{teacherId}/timeslot")]
        public async Task<IActionResult> GetAvailableTimeslots(Guid teacherId)
        {
            var timeslots = await _teacherService.GetAvailableTimeslotsByTeacherId(teacherId);
            var response = _viewmodelAdapter.ConvertToTimeslotsDTO(timeslots);
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetTeachers()
        {
            var teachers = await _teacherService.GetTeachers();
            var response = _viewmodelAdapter.ConvertToTeachersDTO(teachers);
            return Ok(response);
        }


        // This can safely be deleted!
        // Used to get a valid timestamp for manual testing purposes
        [HttpGet("time")]
        public async Task<IActionResult> Time()
        {
            return Ok(new { Time = DateTime.UtcNow });
        }
    }
}
