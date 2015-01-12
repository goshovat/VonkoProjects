using System;

namespace GSM
{
    public static class GSMTest
    {
        static GSM[] gsmList;

        //static constructor of the class
        static GSMTest() 
        {
            CreatePhones();
        }

        private static void CreatePhones()
        {
            gsmList = new GSM[4];

            Owner vonko = new Owner();

            GSM.Battery vonkoOldBattery = new GSM.Battery(BatteryType.LiIon, "Iphone4-Bat", 28, 5);
            GSM.Battery vonkoNextBattery = new GSM.Battery(BatteryType.NiCd, "Viper-S1", 34, 8);

            GSM.Display vonkoOldDisplay = new GSM.Display(7, 241241);
            GSM.Display vonkoNextDisplay = new GSM.Display(9, 241421);

            GSM unknownPhone = new GSM();
            GSM vonkoPhone = new GSM("HTC", "One");
            GSM vonkoOldPhone = new GSM("Iphone", "4", 400d, vonko, vonkoOldDisplay, vonkoOldBattery);
            GSM vonkoNextPhone = new GSM("All View", "Viper-S1", 350, vonkoNextDisplay, vonkoNextBattery);

            //put the new objects in the array
            gsmList[0] = unknownPhone;
            gsmList[1] = vonkoPhone;
            gsmList[2] = vonkoOldPhone;
            gsmList[3] = vonkoNextPhone;
        }

        //the static method that will print info for the GSMs in the list
        public static void PrintInfoAllGSMs()
        {
            foreach (GSM gsm in gsmList)
            {
                Console.WriteLine(gsm.ToString());
            }
        }

        //a static test method that will make some changes in the GSMs. 
        //this method is to be called only once
        public static void MakeChangesGSMs() 
        {
            GSM.Battery unknownBattery = new GSM.Battery(BatteryType.Unknown);
            GSM.Battery vonkoBattery = new GSM.Battery(BatteryType.LiIon);

            GSM.Display unknownDisplay = new GSM.Display(0d);
            GSM.Display vonkoDisplay = new GSM.Display(11);

            GSMTest.gsmList[0].Owner = new Owner("Pesho ot mahalata");
            GSMTest.gsmList[0].Displai = unknownDisplay;
            GSMTest.gsmList[0].Batery = unknownBattery;

            GSMTest.gsmList[1].Displai = vonkoDisplay;
            GSMTest.gsmList[1].Batery = vonkoBattery;     

            GSMTest.gsmList[2].Batery.BatteryModel = "TurkeyBattery";
            GSMTest.gsmList[2].Price = 250d;
        }
    }
}
