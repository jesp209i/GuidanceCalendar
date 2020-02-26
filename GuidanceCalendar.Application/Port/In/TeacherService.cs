using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GuidanceCalendar.Application.UseCases.Teacher.Commands.CreateTimeslot;
using GuidanceCalendar.Application.UseCases.Teacher.Queries.GetAvailableTimeslots;
using GuidanceCalendar.Application.UseCases.Teacher.Queries.GetTeachers;
using GuidanceCalendar.Domain;
using GuidanceCalendar.Ports.In.Application;
using MediatR;

namespace GuidanceCalendar.Application.Port.In
{
    public class TeacherService : ApplicationService, ITeacherService
    {
        public TeacherService(IMediator mediator) : base(mediator)
        {
        }

        public async Task<Guid> CreateTimeslot(Guid teacherId, Guid calendarId, DateTimeOffset startTime, DateTimeOffset endTime)
        {
            var response = await _mediator.Send(new CreateTimeslotCommand { TeacherId = teacherId, CalendarId = calendarId, StartTime = startTime, EndTime = endTime });
            return response.Id;
        }

        public async Task<ICollection<Timeslot>> GetAvailableTimeslotsByTeacherId(Guid teacherId)
        {
            
            return await _mediator.Send(new GetAvailableTimeslotsQuery { TeacherId = teacherId });
        }

        public async Task<ICollection<Teacher>> GetTeachers()
        {
            return await _mediator.Send(new GetTeachersQuery());
        }
    }
}
