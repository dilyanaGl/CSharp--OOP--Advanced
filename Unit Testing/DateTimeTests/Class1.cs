using DateTameAddDays;
using System;
using NUnit.Framework;

namespace DateTimeTests
{

    [TestFixture]
    public class Class1
    {

        IDateTime date;

        [Test]
        public void TestAddDaysCommand()
        {
            date = new CustomDateTime();
            var expectedDate = DateTime.Now.Date;
            Assert.That(date.Now(), Is.EqualTo(expectedDate));
        }

        [Test]
       public void TestAddDays()
        {
            var testDate = new DateTime(2011, 1, 1);
            var expectedDate = new DateTime(2011, 1, 2);
            testDate = testDate.AddDays(1);
            Assert.That(testDate, Is.EqualTo(expectedDate));

        }

   


      
    }
}
