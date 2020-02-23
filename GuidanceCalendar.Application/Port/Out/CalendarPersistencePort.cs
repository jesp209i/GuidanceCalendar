using GuidanceCalendar.Domain;
using GuidanceCalendar.Persistence.DAO;
using GuidanceCalendar.Persistence.Interfaces;
using GuidanceCalendar.Ports.Out;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GuidanceCalendar.Application.Port.Out
{
    public class CalendarPersistencePort : ICalendarPersistencePort
    {
        private readonly ICalendarRepository _calendarRepository;

        public CalendarPersistencePort(ICalendarRepository calendarRepository)
        {
            _calendarRepository = calendarRepository;
        }

        public async Task<Guid> AddCalendarAsync(Calendar calendar)
        {
            CalendarDao entity = new CalendarDao { Name = calendar.Name, Description = calendar.Description };
            await _calendarRepository.AddAsync(entity);
            return entity.Id;
        }

        public async Task<Calendar> GetByIdAsync(Guid id)
        {
            var calendarDao = await _calendarRepository.GetByIdAsync(id);
            return DaoToDomain(calendarDao);
        }

        public async Task<ICollection<Calendar>> ListCalendarsAsync()
        {
            var listCalendarsDao = await _calendarRepository.ListAsync();
            var calendars = new List<Calendar>();
            foreach (var daoCalendar in listCalendarsDao)
            {
                calendars.Add(Calendar.Create(daoCalendar.Id, daoCalendar.Name, daoCalendar.Description));
            }
            return calendars;
        }

        private Calendar DaoToDomain(CalendarDao calendarDao)
        {
            return Calendar.Create(calendarDao.Id, calendarDao.Name, calendarDao.Description);
        }
    }
}
