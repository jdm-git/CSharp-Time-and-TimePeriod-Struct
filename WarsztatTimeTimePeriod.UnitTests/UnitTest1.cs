using NUnit.Framework;
using System;
using WarsztatTimeTimePeriod;
namespace WarsztatTimeTimePeriod.UnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Time_ToStringBehavior()
        {
            var time = new Time(0);
            var time2 = new Time(23, 59, 59);

            var firstString = time.ToString();
            var secondString = time2.ToString();

            Assert.AreEqual("00:00:00", firstString);
            Assert.AreEqual("23:59:59", secondString);
        }
        [Test]
        public void TimePeriod_ToStringBehavior()
        {
            var timeperiod1 = new TimePeriod(0);
            var timeperiod2 = new TimePeriod(129,59,59);

            var firstString = timeperiod1.ToString();
            var secondString = timeperiod2.ToString();

            Assert.AreEqual("00:00:00", firstString);
            Assert.AreEqual("129:59:59", secondString);
        }
        [Test]
        public void Time_IEquatableImplementation()
        {
            var firstTime = new Time(12, 12, 12);
            var secondTime = new Time(12, 12, 12);
            var thirdTime = new Time(0);

            var result1 = firstTime == secondTime;
            var result2 = firstTime == thirdTime;

            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
        }
        [Test]
        public void TimePeriod_IEquatableImplementation()
        {
            var firstTime = new TimePeriod(12, 12, 12);
            var secondTime = new TimePeriod(12, 12, 12);
            var thirdTime = new TimePeriod(0);

            var result1 = firstTime == secondTime;
            var result2 = firstTime == thirdTime;

            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
        }
        [Test]
        public void Time_IComparableImplementation_GraterThan()
        {
            var firstTime = new Time(23);
            var secondTime = new Time(5);
            var thirdTime = new Time(23);

            var result1 = firstTime > secondTime;
            var result2 = firstTime > thirdTime;

            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
        }
        [Test]
        public void Time_IComparableImplementation_LesserThan()
        {
            var firstTime = new Time(1);
            var secondTime = new Time(2);
            var thirdTime = new Time(0);

            var result1 = firstTime < secondTime;
            var result2 = firstTime < thirdTime;

            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
        }
        [Test]
        public void TimePeriod_IcomparableImplementation_GraterThan()
        {
            var firstTime = new TimePeriod(23);
            var secondTime = new TimePeriod(5);
            var thirdTime = new TimePeriod(23);

            var result1 = firstTime > secondTime;
            var result2 = firstTime > thirdTime;

            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
        }
        [Test]
        public void TimePeriod_IcomparableImplementation_LesserThan()
        {
            var firstTime = new TimePeriod(23);
            var secondTime = new TimePeriod(5);
            var thirdTime = new TimePeriod(23);

            var result1 = firstTime < secondTime;
            var result2 = firstTime < thirdTime;

            Assert.IsFalse(result1);
            Assert.IsFalse(result2);
        }
        [Test]
        public void Time_Plus()
        {
            var time = new Time(12, 0, 0);
            var timePeriod = new TimePeriod(10);

            var expected = new Time(12, 0, 10);
            var result = time.Plus(timePeriod);

            Assert.AreEqual(expected, result);
        }
        [Test]
        public void staticTime_Plus()
        {
            var time = new Time(12, 0, 0);
            var timePeriod = new TimePeriod(10);

            var expected = new Time(12, 0, 10);
            var result = time + timePeriod;

            Assert.AreEqual(expected, result);
        }
        [Test]
        public void TimePeriod_Plus()
        {
            var timePeriod1 = new TimePeriod(12, 0, 0);
            var timePeriod2 = new TimePeriod(12, 0, 0);

            var expected = new TimePeriod(24, 0, 0);
            var result = timePeriod1.Plus(timePeriod2);

            Assert.AreEqual(expected, result);
        }
        [Test]
        public void staticTimePeriod_Plus()
        {
            var timePeriod1 = new TimePeriod(12, 0, 0);
            var timePeriod2 = new TimePeriod(12, 0, 0);

            var expected = new TimePeriod(24, 0, 0);
            var result = timePeriod1 + timePeriod2;

            Assert.AreEqual(expected, result);
        }
    }
}