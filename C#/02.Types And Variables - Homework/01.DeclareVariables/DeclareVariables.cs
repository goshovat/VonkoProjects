using System;

class DeclareVariables
{
    static void Main()
    {
        ushort a = 52130;
        sbyte b = -115;
        int c = 4825932;
        byte d = 97;
        short e = -10000;
        Console.WriteLine(
            "{0} is type:ushort; {1} is type:sbyte; {2} is type:ushort", a, b, c);
        Console.WriteLine("{0} is type:sbyte, {1} is type:short", d, e);
    }
}

