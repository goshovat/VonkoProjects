using System;
using System.Collections.Generic;
using System.Globalization;

namespace GSM
{
    public class GSMCallHistoryTest
    {
        public static void CallHistoryTest()
        {
            //create the new phone
            GSM goshkoIphone = CreateGoshkoPhone();

            //add a few calls
            AddCalls(goshkoIphone);

            //print info about the phone calls
            Console.WriteLine("Info about Goshko's calls, before deleting the longest call:\n");
            PrintInfoCalls(goshkoIphone);

            //remove the longest call
            RemoveLongestCall(goshkoIphone);

            Console.WriteLine("Info about Goshko's calls, after deleting the longest call:\n");
            PrintInfoCalls(goshkoIphone);
        }

        private static void AddCalls(GSM goshkoIphone)
        {
            string dateTimeFormat = "d.MM.yyyy H:mm:ss";
            DateTime startTimeFirstCall = DateTime.ParseExact("18.09.2014 10:04:23", dateTimeFormat, CultureInfo.InvariantCulture);
            DateTime durationFirstCall = DateTime.ParseExact("01.01.0001 3:14:32", dateTimeFormat, CultureInfo.InvariantCulture);
            PhoneCall firstCall = new PhoneCall(startTimeFirstCall, durationFirstCall);
            goshkoIphone.AddCall(firstCall);

            DateTime startTimeSecondCall = DateTime.ParseExact("17.09.2014 12:57:33", dateTimeFormat, CultureInfo.InvariantCulture);
            DateTime durationFSecondCall = DateTime.ParseExact("01.01.0001 00:10:13", dateTimeFormat, CultureInfo.InvariantCulture);
            PhoneCall secondCall = new PhoneCall(startTimeSecondCall, durationFSecondCall);
            goshkoIphone.AddCall(secondCall);

            DateTime startTimeThirdCall = DateTime.ParseExact("16.09.2014 04:35:43", dateTimeFormat, CultureInfo.InstalledUICulture);
            DateTime durationThirdCall = DateTime.ParseExact("01.01.0001 00:57:59", dateTimeFormat, CultureInfo.InstalledUICulture);
            PhoneCall thirdCall = new PhoneCall(startTimeThirdCall, durationThirdCall);
            goshkoIphone.AddCall(thirdCall);
        }

        private static GSM CreateGoshkoPhone()
        {
            GSM.Display goshkoDisplay = new GSM.Display(10, 52442141);
            GSM.Battery goshkoBattery = new GSM.Battery(BatteryType.NiCd, "Iphone-5SBat", 42d, 13d);
            GSM goshkoIphone = new GSM("Apple", "Iphone -5S", 765, goshkoDisplay, goshkoBattery);
            return goshkoIphone;
        }

        //this method will print info about all calls in the particular phone
        private static void PrintInfoCalls(GSM goshkoIphone)
        {
            foreach (PhoneCall call in goshkoIphone.ArchiveList)
            {
                Console.WriteLine("The start time of the call is: {0}", call.StartTime);
                string duration = string.Format("{0:HH:mm:ss}", call.Duration);
                Console.WriteLine("The duration of the phone call is: {0}", duration);
                Console.WriteLine();
            }

            double goshkoBill = goshkoIphone.CheckBill(0.37);

            Console.WriteLine("The price of all the calls is: {0}\n", goshkoBill);
        }

        //this method will remove the longest call from a phone
        private static void RemoveLongestCall(GSM goshkoIphone)
        {
            if (goshkoIphone.ArchiveList.Count > 0)
            {
                PhoneCall longestCall = goshkoIphone.ArchiveList[0];

                foreach (PhoneCall call in goshkoIphone.ArchiveList)
                {
                    if (CallGreaterThanLongestCall(call, longestCall))
                    {
                        longestCall = call;
                    }
                }

                goshkoIphone.EraseCall(longestCall);
            }
        }

        //this method will compare two phone calls on length
        private static bool CallGreaterThanLongestCall(PhoneCall call, PhoneCall longestCall)
        {
            DateTime callDuration = call.Duration;
            DateTime longestCallDuration = longestCall.Duration;

            if (DateTime.Compare(callDuration, longestCallDuration) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
