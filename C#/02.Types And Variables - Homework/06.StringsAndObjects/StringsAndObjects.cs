using System;

class StringsAndObjects
{
    static void Main()
    {
        string hello = "Hello";
        string world = "World";
        object helloWorldObj = hello + " " + world;
        string helloWorld = (string)helloWorldObj;
        Console.WriteLine(helloWorld);
    }
}