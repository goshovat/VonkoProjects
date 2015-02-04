using System;

class A_nacci
{
    static void Main()
    {
        char element1 = char.Parse(Console.ReadLine());
        char element2 = char.Parse(Console.ReadLine());
        int lines = int.Parse(Console.ReadLine());

        char[] arr = new Char[] {' ','A', 'B', 'C', 'D', 'E', 'F','G','H','I','J','K',
        'L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'};

        char[] newArr = new Char[84];

        int temp1 = Array.IndexOf(arr, element1);
        int temp2 = Array.IndexOf(arr, element2);
        newArr[1] = element1;
        newArr[2] = element2;

        for (int i = 3; i <= 2 * lines-1; i++)
        {
            if ((temp1 + temp2) != 26)
            {
                newArr[i] = arr[(temp1 + temp2) % 26];
            }
            else
            {
                newArr[i] = arr[temp1 + temp2];
            }
                temp1 = temp2;
                temp2 = Array.IndexOf(arr, newArr[i]);
            
        }

        Console.WriteLine(newArr[1]);

        for (int row = 2, letter = 2; row <= lines; row++, letter += 2)
        {
            Console.Write(newArr[letter]);

            Console.Write(new String(' ', row - 2));

            Console.Write(newArr[letter + 1]);

            Console.WriteLine();
        }
    }
}

