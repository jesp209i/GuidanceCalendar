using GuidanceCalendar.Domain;
using FluentAssertions;
using NUnit.Framework;
using System;

namespace Domain.Test
{
    public class TimeslotTests
    {
        private Calendar testCalendar;
        private Timeslot testTimeslot;
        private Teacher testTeacher;
        [SetUp]
        public void Setup()
        {
            var startTime = new DateTimeOffset().UtcDateTime;
            var endTime = new DateTimeOffset().UtcDateTime.AddHours(4);
            testCalendar = new Calendar("Test Calendar");
            testTeacher = new Teacher("Prøveknud");
            testTimeslot = new Timeslot(startTime, endTime, testTeacher, testCalendar);
        }

        [Test]
        public void Teacher_Contains_No_Timeslot()
        {
            var actual = testTeacher;
            actual.AvailableTimeslots.Should().HaveCount(0, "No available timeslots");
        }
        [Test]
        public void Timeslot_Endtime_Before_Starttime_Throws_Exception()
        {
            var startTime = new DateTimeOffset().UtcDateTime;
            Action act = () => new Timeslot(startTime, startTime.AddHours(-1), testTeacher, testCalendar);
            act.Should().Throw<ArgumentException>();
        }
        [Test]
        public void Teacher_Contains_One_Timeslot()
        {
            var actual = testTeacher;
            actual.AvailableTimeslots.Should().HaveCount(0, "No available timeslots");
            actual.AddTimeslot(testTimeslot);
            actual.AvailableTimeslots.Should().HaveCount(1, "Teacher should contain one timeslot");
        }
        [Test]
        public void Teacher_Doesnt_Accept_overlapping_Timeslots()
        {
            var actual = testTeacher;
            actual.AvailableTimeslots.Should().HaveCount(0, "No available timeslots");
            actual.AddTimeslot(testTimeslot);
            var ts = new Timeslot(new DateTimeOffset().UtcDateTime, new DateTimeOffset().UtcDateTime.AddMinutes(30), testTeacher, testCalendar);
            Action act = () => actual.AddTimeslot(ts);
            act.Should().Throw<Exception>();
        }
        [Test]
        public void Teacher_Has_Two_Timeslots()
        {
            var actual = testTeacher;
            actual.AddTimeslot(testTimeslot);
            var ts = new Timeslot(new DateTimeOffset().UtcDateTime.AddDays(1), new DateTimeOffset().UtcDateTime.AddDays(1).AddMinutes(30), testTeacher, testCalendar);
            actual.AddTimeslot(ts);
            actual.AvailableTimeslots.Should().HaveCount(2, "Two timeslots on teacher");
        }
        [Test]
        public void Teacher_Has_Two_Timeslots_Second_Added_Before_First()
        {
            var actual = testTeacher;
            var time = new DateTimeOffset().UtcDateTime;
            var ts = new Timeslot(time.AddDays(2), time.AddHours(50), testTeacher, testCalendar);
            actual.AddTimeslot(ts);
            var ts2 = new Timeslot(time.AddDays(1), time.AddHours(26), testTeacher, testCalendar);
            actual.AddTimeslot(ts2);
            actual.AvailableTimeslots.Should().HaveCount(2, "Two timeslots on teacher");
        }
        [Test]
        public void Timeslot_Is_Attatched_To_One_Calendar()
        {
            var actual = testTimeslot;
            var notTestCalendar = new Calendar("not test calendar");
            actual.Calendar.Should().Be(testCalendar);
            actual.Calendar.Should().NotBe(notTestCalendar);
        }
    }
}
