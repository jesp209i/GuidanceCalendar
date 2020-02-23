using GuidanceCalendar.Domain;
using GuidanceCalendar.Ports.Out;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GuidanceCalendar.Application.UseCases.Teacher.Commands.CreateTimeslot
{
    public class CreateTimeslotHandler : IRequestHandler<CreateTimeslotCommand, CreateTimeslotResponse>
    {

        private readonly ITeacherPersistencePort _tpp;
        private readonly ICalendarPersistencePort _cpp;

        public CreateTimeslotHandler(ITeacherPersistencePort tpp,
                                     ICalendarPersistencePort cpp)
        {

            this._tpp = tpp;
            this._cpp = cpp;
        }
        public async Task<CreateTimeslotResponse> Handle(CreateTimeslotCommand request, CancellationToken cancellationToken)
        {
            var teacher = await _tpp.GetTeacherWithTimeslotsById(request.TeacherId);
            var calendar = await _cpp.GetByIdAsync(request.CalendarId);
            var timeslot = new Timeslot(request.StartTime, request.EndTime, teacher, calendar);
            teacher.AddTimeslot(timeslot);
            await _tpp.Update(teacher);
            return new CreateTimeslotResponse { Id = timeslot.Id };
            
        }
    }
}
