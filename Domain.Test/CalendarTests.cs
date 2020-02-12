using GuidanceCalendar.Domain;
using FluentAssertions;
using NUnit.Framework;

namespace Domain.Test
{
    public class CalendarTests
    {
        private Hold hold1;
        private Hold hold2;
        private Hold hold3;
        private Calendar testCalendar;
        [SetUp]
        public void Setup()
        {
            hold1 = new Hold("Hold 1");
            hold2 = new Hold("Hold 2");
            hold3 = new Hold("Hold 3");
            testCalendar = new Calendar("Test Calendar");
        }

        [Test]
        public void Calendar_Contains_No_Hold()
        {
            var actual = testCalendar;

            actual.Holds.Should().HaveCount(0, "No Hold should have been added yet");
        }
        [Test]
        public void Calendar_Contains_One_Hold()
        {
            var actual = testCalendar;
            actual.AddHold(hold1);
            actual.Holds.Should().HaveCount(1, "One Hold should have been added");
        }
        [Test]
        public void Calendar_Contains_Two_Hold()
        {
            var actual = testCalendar;
            actual.AddHold(hold1);
            actual.AddHold(hold2);
            actual.Holds.Should().HaveCount(2, "Two Hold should have been added");
        }
    }
}