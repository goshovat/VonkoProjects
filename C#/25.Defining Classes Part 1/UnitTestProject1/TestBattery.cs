namespace MobilePhone.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestBattery
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestBatteryNegativeHours()
        {
            Battery testBattery = new Battery(-4, 5);
        }

        [TestMethod]
        public void TestBatteryToString()
        {
            Battery testBattery = new Battery(15, 5, BatteryType.LiPoly);
            if (testBattery.ToString() != string.Format("{0}, {1} hours idle, {2} hours talk",
                testBattery.BatteryType, testBattery.HoursIdle, testBattery.HoursTalk))
                throw new ApplicationException("Incorrect work of Battery ToString() method");
        }

        [TestMethod]
        public void TestBatteryEmptyConstructor()
        {
            Battery testBattery = new Battery();

            if (testBattery.HoursIdle != 10 || testBattery.HoursTalk != 5
                || testBattery.BatteryType != BatteryType.LiIOn)
                throw new ApplicationException("Incorrect work of Battery Empty Constructor");
        }
    }
}
