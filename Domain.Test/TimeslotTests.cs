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
            var startTime = DateTime.UtcNow;
            var endTime = DateTime.UtcNow.AddHours(4);
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
            var startTime = DateTime.UtcNow;
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
            var ts = new Timeslot(DateTime.UtcNow, DateTime.UtcNow.AddMinutes(30), testTeacher, testCalendar);
            Action act = () => actual.AddTimeslot(ts);
            act.Should().Throw<Exception>();
        }
        [Test]
        public void Teacher_Has_Two_Timeslots()
        {
            var actual = testTeacher;
            actual.AddTimeslot(testTimeslot);
            var goodtime = DateTime.UtcNow.AddDays(1);
            var ts = new Timeslot(goodtime, goodtime.AddMinutes(30), testTeacher, testCalendar);
            actual.AddTimeslot(ts);
            actual.AvailableTimeslots.Should().HaveCount(2, "Two timeslots on teacher");
        }
        [Test]
        public void Teacher_Has_Two_Timeslots_Second_Added_Before_First()
        {
            var actual = testTeacher;
            var time = DateTime.UtcNow;
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
        [Test]
        public void Timeslot_No_Overlapping_Bookings()
        {
            var actual = testTimeslot;
            var bookingtime = DateTime.UtcNow;
            var testStudent = new Student("Bobby Bingo");

            var testbooking = new Booking(testStudent,bookingtime, bookingtime.AddMinutes(30));
            actual.AddBooking(testbooking);
            var testBooking2 = new Booking(testStudent, bookingtime.AddMinutes(5), bookingtime.AddMinutes(35));
            Action act = () => actual.AddBooking(testBooking2);
            act.Should().Throw<Exception>();
        }
        [Test]
        public void Student_Max_Two_Open_Bookings()
        {
            var actual = testTimeslot;
            var bookingtime = DateTime.UtcNow;
            var testStudent = new Student("Bobby Bingo");
            var testStudent2 = new Student("Britta Nielsen");

            var testbooking = new Booking(testStudent, bookingtime.AddMinutes(2), bookingtime.AddMinutes(15));
            actual.AddBooking(testbooking);
            var testBooking2 = new Booking(testStudent, bookingtime.AddMinutes(16), bookingtime.AddMinutes(31));
            actual.AddBooking(testBooking2);
            var testBooking3 = new Booking(testStudent, bookingtime.AddMinutes(32), bookingtime.AddMinutes(48));
            var testBooking4 = new Booking(testStudent2, bookingtime.AddMinutes(32), bookingtime.AddMinutes(48));
            Action act = () => actual.AddBooking(testBooking3);
            act.Should().Throw<Exception>();
            actual.Bookings.Should().HaveCount(2);
            actual.AddBooking(testBooking4);
            actual.Bookings.Should().HaveCount(3);
        }
    }
}
