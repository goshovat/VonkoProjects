namespace MobilePhone.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class GSMTest
    {
        public static GSM[] testGSMs;

        [TestMethod]
        [TestInitialize]
        public void CreateFewGSMInstances()
        {
            testGSMs = new GSM[3];
            testGSMs[0] = new GSM("Samsung", "Galaxy S4", 300,
                new Person("Vonko", "Mihov"), new Battery(23, 5, BatteryType.LiIOn),
                new Display(4.8, 16000000));
            testGSMs[1] = new GSM("Apple", "Iphone 6", 1500);
            testGSMs[2] = new GSM("HTC", "OneX");
        }

        [TestMethod]
        public void CheckGSMToString()
        {
            if (testGSMs[0].ToString() != string.Format(
                "{0} {1}\nBattery: {2}\nDisplay: {3}\nPrice: {4}\nOwner: {5}",
                testGSMs[0].Manufacturer, testGSMs[0].Model, testGSMs[0].Battery,
                testGSMs[0].Display, testGSMs[0].Price, testGSMs[0].Owner))
                throw new ApplicationException("Error with GSM ToString() method");
        }

        [TestMethod]
        public void CheckGSMInstancesProperties()
        {
            if (testGSMs[0].Display.Size != 4.8 || testGSMs[1].Model != "Iphone 6"
                || testGSMs[2].Owner != null)
                throw new ApplicationException("Error with GSM properties");
        }

        [TestMethod]
        public void TestIphone4S()
        {
            if (GSM.iPhone4S.ToString() != string.Format(
                "{0} {1}\nBattery: {2}\nDisplay: {3}\nPrice: {4}\nOwner: {5}",
                GSM.iPhone4S.Manufacturer, GSM.iPhone4S.Model, GSM.iPhone4S.Battery,
                GSM.iPhone4S.Display, GSM.iPhone4S.Price, GSM.iPhone4S.Owner))
                throw new ApplicationException("Error with Iphone4S ToString() or properties method");
        }
    }
}
