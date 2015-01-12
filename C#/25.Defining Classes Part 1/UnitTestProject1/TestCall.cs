namespace MobilePhone.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestCall
    {
        public static GSM GSMInstance;

        [TestMethod]
        [TestInitialize]
        public void CreateGSMInstance()
        {
            GSMInstance = new GSM("Sony", "Xperia Z8");

            GSMInstance.MakeCall(new DateTime(2014, 12, 23, 10, 34, 00), 240, 0887555386);
            GSMInstance.MakeCall(new DateTime(2014, 12, 23, 11, 24, 10), 310, 0887555345);
            GSMInstance.MakeCall(new DateTime(2014, 11, 23, 19, 30, 30), 430, 0885342232);
        }

        [TestMethod]
        public void TestCallToString()
        {     
            if (GSMInstance.GetCallNumber(1).ToString() != string.Format(
                "{0}, {1} seconds, {2}", GSMInstance.GetCallNumber(1).Date,
                GSMInstance.GetCallNumber(1).Duration, GSMInstance.GetCallNumber(1).DialedNumber))
                throw new ApplicationException("Error with Call ToString() Method");
        }

        [TestMethod]
        public void TestBillCalculation()
        {
            double calculatedPrice = GSMInstance.CalculateCurrentBill(0.37);

            if (calculatedPrice != 6.04)
                throw new ApplicationException("Error with price GSM CalculateCurrentBill() Method");
        }

        [TestMethod]
        public void TestRemoveLongestCall()
        {
            GSMInstance.DeleteLongestCall();
            double calculatedPrice = GSMInstance.CalculateCurrentBill(0.37);

            if (calculatedPrice != 3.39)
                throw new ApplicationException("Error with price GSM CalculateCurrentBill() Method");
        }

        [TestMethod]
        public void TestCallHistoryClear()
        {
            GSMInstance.ClearHistory();

            if (GSMInstance.NumberCalls != 0)
                throw new ApplicationException("Error with price GSM ClearCallHistory() Method");
        }
    }
}
