using System;

class Program
{
    static void Main()
    {
        decimal N = decimal.Parse(Console.ReadLine());
        decimal M = decimal.Parse(Console.ReadLine());
        decimal P = decimal.Parse(Console.ReadLine());
        int Mdivrem = (int)(M % 180);

        decimal expresion =

((N * N + (1 / (M * P)) + 1337) / (N - ((decimal)128.523123123 * P))) + (decimal)(Math.Sin(Mdivrem));
        Console.WriteLine("{0:N6}", expresion);

    }
}
