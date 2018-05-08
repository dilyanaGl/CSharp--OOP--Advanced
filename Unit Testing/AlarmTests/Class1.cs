using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Sensor;


namespace AlarmTests
{
    [TestFixture]
    public class Class1
    {

        [Test]
        public void TestCheckAlarm()
        {
            var alarm = new Alarm();
           Assert.That(alarm.AlarmOn, Is.EqualTo(false));
        }

        [Test]
        public void TestPopNextPressurePsiValue()
        {
            var sensor = new Mock<ISensor>();

            sensor.Setup(s => s.PopNextPressurePsiValue()).Returns(19D);

            Alarm alarm = new Alarm();
            
            alarm.Check();

            Assert.That(alarm.AlarmOn, Is.EqualTo(false));

        }

        [Test]
        public void TestHighPressure()
        {
            var sensor = new Mock<ISensor>();
            sensor.Setup(s => s.PopNextPressurePsiValue()).Returns(25D);

            Alarm alarm = new Alarm();

            alarm.Check();

            Assert.That(alarm.AlarmOn, Is.EqualTo(true));
        }


       

    }
}
