using System;

class FormattingNumbers
{
    static void Main(string[] args)
    {
        Console.WriteLine("Input integer:");
        int number1 = int.Parse(Console.ReadLine());
        if (number1 < 0 || number1 > 500)
            throw new ArgumentException("Integer out of range.");

        float number2 = float.Parse(Console.ReadLine());
        float number3 = float.Parse(Console.ReadLine());

        string number1Hex = Convert.ToString(number1, 16);
        string number1Binary = Convert.ToString(number1, 2).PadLeft(10, '0');
        Console.WriteLine("{0, -4}|{1}| {2:N2}|{3:N3} |",
            number1Hex, number1Binary, number2, number3);
    }
}
