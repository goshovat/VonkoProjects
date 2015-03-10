using System;
using System.Collections.Generic;
using System.Linq;

class SpecialValue
{
    static void Main()
    {
        int rowsCount = int.Parse(Console.ReadLine());
        List<int[]> rows = new List<int[]>();

        for (int i = 0; i < rowsCount; i++)
        {
            int[] numbers = Console.ReadLine().Split(',')
                .Select(n => int.Parse(n)).ToArray();

            rows.Add(numbers);
        }
      
        int maxSpecialValue = 0;

        for (int i = 0; i < rows[0].Length; i++)
        {
            Dictionary<int, List<int>> visitedCells = 
                new Dictionary<int, List<int>>();
            int path = 0;
            int currentRow = 0;
            int currentValue = rows[0][i];
            visitedCells.Add(0, new List<int>(i));
            path++;

            while (currentValue >= 0 && 
                (!visitedCells.ContainsKey(currentRow) ||
                visitedCells[currentRow].IndexOf(currentValue) == -1))
            {
                currentRow++;
                if (currentRow == rowsCount)
                    currentRow = 0;

                int newValue = rows[currentRow][currentValue];

                if (!visitedCells.ContainsKey(currentRow))
                    visitedCells.Add(currentRow, new List<int>(currentValue));
                else
                    visitedCells[currentRow].Add(currentValue);

                currentValue = newValue;
                path++;
            }

            int specialValue = path + Math.Abs(currentValue);

            if (specialValue > maxSpecialValue)
                maxSpecialValue = specialValue;
        }

        Console.WriteLine(maxSpecialValue);
    }
}
