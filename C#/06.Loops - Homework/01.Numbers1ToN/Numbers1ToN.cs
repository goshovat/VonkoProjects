﻿using System;

class Numbers1ToN
{
    static void Main()
    {
        Console.WriteLine("Enter an integer:");
        int n = int.Parse(Console.ReadLine());

        for (int i = 1; i <= n; i++)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine();
    }
}
