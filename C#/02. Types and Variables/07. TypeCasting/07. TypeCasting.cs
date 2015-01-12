using System;

class TypeCasting
{
    static void Main()
    {
        string hello = "Hello";
        string world = "World";
        object helloWorld = hello + " " + world;
        string helloW = (string)helloWorld;
        Console.WriteLine(helloW);
    }
}

