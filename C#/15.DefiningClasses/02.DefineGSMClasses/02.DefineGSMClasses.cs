//this is the main method for all classes about the GSM

using System;
using System.Collections.Generic;
using System.Globalization;

namespace GSM
{
    class DefineGSMClasses
    {
        static void Main()
        {
            //print info for nokia 95
            GSM.PrintInfoN95();

            Console.WriteLine("Print initial info for the telephones, created in the test class: ");
            GSMTest.PrintInfoAllGSMs();

            GSMTest.MakeChangesGSMs();

            Console.WriteLine("After three of them are sold:");
            GSMTest.PrintInfoAllGSMs();

            //here we call the main static method in the calss tht tests the CallHistory
            GSMCallHistoryTest.CallHistoryTest();
        }
    }
}
