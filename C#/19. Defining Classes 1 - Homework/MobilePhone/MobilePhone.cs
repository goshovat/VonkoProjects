
namespace MobilePhone
{
    using System;

    public static class MobilePhone
    {
        public static void Main()
        {
            GSM gsmInstance = new GSM("Sony", "Xperia Z8");
            gsmInstance.MakeCall(new DateTime(2014, 12, 23, 10, 34, 00), 240, 0887555386);
            gsmInstance.MakeCall(new DateTime(2014, 12, 23, 11, 24, 10), 310, 0887555345);

            gsmInstance.CalculateCurrentBill(0.37);
        }
    }
}
