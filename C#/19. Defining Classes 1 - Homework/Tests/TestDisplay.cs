namespace MobilePhone.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestDisplay
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestDisplayNegativeColors()
        {
            Display testDisplay = new Display(3.5, -500);
        }

        [TestMethod]
        public void TestDisplayToString()
        {
            Display testDisplay = new Display(3.5, 16000000);
            if (testDisplay.ToString() != string.Format("{0} inches, {1} colors",
                testDisplay.Size, testDisplay.Colors))
                throw new ApplicationException("Error in the Display.ToString() method");
        }

        [TestMethod]
        public void TestDisplayEmptyConstructor()
        {
            Display testDisplay = new Display();
            if (testDisplay.Size != 3 && testDisplay.Colors != 1)
                throw new ApplicationException("Error in the work of Display Empty Constructor");
        }
    }
}
