using GuidanceCalendar.API.Adapter;
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
        public async Task<IActionResult> CreateTimeslot(
            [FromBody]Guid teacherId, 
            [FromBody]Guid calendarId, 
            [FromBody]DateTimeOffset startTime, 
            [FromBody]DateTimeOffset endTime)
        {
            var response = await _teacherService.CreateTimeslot(teacherId, calendarId, startTime, endTime);
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
