using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuidanceCalendar.Domain;
using GuidanceCalendar.Persistence.DAO;
using GuidanceCalendar.Persistence.Interfaces;
using GuidanceCalendar.Ports.Out.Persistence;

namespace GuidanceCalendar.Application.Port.Out
{
    public class TeacherPersistencePort : ITeacherPersistencePort
    {
        private readonly ITeacherRepository teacherRepository;

        public TeacherPersistencePort(ITeacherRepository teacherRepository)
        {
            this.teacherRepository = teacherRepository;
        }
        public async Task<Teacher> GetTeacherWithTimeslotsById(Guid teacherId)
        {
            var daoTeacher = await teacherRepository.GetTeacherWithTimeslotsById(teacherId);

            return DaoToDomain(daoTeacher);
        }

        public async Task<ICollection<Teacher>> ListTeachersAsync()
        {
            var daoTeacher = await teacherRepository.ListAsync();
            var list = new List<Teacher>();
            foreach (var t_dao in daoTeacher)
            {
                list.Add(DaoToDomain(t_dao));
            }
            return list;
        }

        public Task Update(Teacher updateTeacher)
        {
            throw new NotImplementedException();
        }

        private Teacher DaoToDomain(TeacherDao teacherDao)
        {
            var teacher = Teacher.Create(teacherDao.Id, teacherDao.Name);
            foreach (var tsDao in teacherDao.AvailableTimeslots)
            {
                var timeslot = Timeslot.Create(tsDao.Id, tsDao.StartTime, tsDao.EndTime, teacher);
                teacher.AvailableTimeslots.Add(timeslot);
            }
            return teacher;
        }
    }
}
