using System;

class HelloVonko
{
    static void Main()
    {
        Console.WriteLine("Write your name: "); //the best name is Vonko
        string name = Console.ReadLine();

        PrintName(name);

        Console.WriteLine("Some tests: ");
        //call the test methods
        Test1();
        Test2();
        Test3();
        Test4();
    }

    static void PrintName(string name)
    {
        Console.WriteLine("Hello, {0}", name);
    }

    //some test methods
    static void Test1()
    {
        Console.WriteLine("Test 1: ");
        PrintName("Pesho Stoyanov");
    }

    static void Test2()
    {
        Console.WriteLine("Test 2: ");
        PrintName("Gosho" + " " + "Ivanov");
    }

    static void Test3()
    {
        Console.WriteLine("Test 3: ");
        PrintName("Ivan" + "88");
    }

    static void Test4()
    {
        Console.WriteLine("Test 4: ");
        PrintName(" ");
    }
}

