using GuidanceCalendar.Domain;
using GuidanceCalendar.Domain.Interfaces.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GuidanceCalendar.Application.TeacherService.Commands.CreateTimeslot
{
    public class CreateTimeslotHandler : IRequestHandler<CreateTimeslotCommand, CreateTimeslotResponse>
    {

        private readonly ITeacherRepository teacherRepository;
        private readonly ICalendarRepository calendarRepository;

        public CreateTimeslotHandler(ITeacherRepository teacherRepository,
                                     ICalendarRepository calendarRepository)
        {

            this.teacherRepository = teacherRepository;
            this.calendarRepository = calendarRepository;
        }
        public async Task<CreateTimeslotResponse> Handle(CreateTimeslotCommand request, CancellationToken cancellationToken)
        {
            var teacher = await teacherRepository.GetByIdAsync(request.TeacherId);
            var calendar = await calendarRepository.GetByIdAsync(request.CalendarId);
            var timeslot = new Timeslot(request.StartTime, request.EndTime, teacher, calendar);
            teacher.AddTimeslot(timeslot);
            await teacherRepository.Update(teacher);
            return new CreateTimeslotResponse { Id = timeslot.Id };
            
        }
    }
}
