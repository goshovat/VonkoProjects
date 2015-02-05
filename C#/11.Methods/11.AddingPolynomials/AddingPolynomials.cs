using System;

class AddingPolynomials
{
    static void Main()
    {
        Console.WriteLine("Enter the first polinom in the format: 'ax2 + bx + c' and instead of a, b and c write real numbers: ");
        string polinom1 = "124x2 -400";

        Console.WriteLine("Enter the second polinom in the format: 'ax2 + bx + c' and instead of a, b and c write real numbers: ");
        string polinom2 = "99x2 + 10x - 10";

        string result = AddPolinoms(polinom1, polinom2);

        Console.WriteLine("The sum of the two polinoms is:\n\r{0}", result);
    }

    //the method that sums the polinoms
    static string AddPolinoms(string polinom1, string polinom2)
    {
        string result = "";

        int[] coefficentsFirstPolinom = new int[3];
        int[] coefficentsSecondPolinom = new int[3];
        int[] resultCoefficents = new int[3];

        //iterate the string of the first polinom to exract the coefficents

        coefficentsFirstPolinom = ExtractCoefficents(polinom1);
        coefficentsSecondPolinom = ExtractCoefficents(polinom2);

        for (int i = 0; i < 3; i++)
        {
            resultCoefficents[i] = coefficentsFirstPolinom[i] + coefficentsSecondPolinom[i];
        }

        //this loop will form the string of our final result
        for (int i = resultCoefficents.Length - 1; i >= 0; i--)
        {
            if (i != resultCoefficents.Length - 1 && resultCoefficents[i] > 0)
            {
                result += "+ ";
            }
            if (resultCoefficents[i] != 0)
            {
                if (i != 0 && i != 1)
                {
                    result += resultCoefficents[i] + "x" + i + " ";
                }
                else if (i == 1)
                {
                    result += resultCoefficents[i] + "x" + " ";
                }
                else
                {
                    result += resultCoefficents[i];
                }
            }
        }
        return result;
    }

    //this method will extract the coefficents from the polinom string
    static int[] ExtractCoefficents(string polinom)
    {
        int temp = 0;

        int[] coefficentsPolinom = new int[3];

        //cover the case if our polinom is only one symbol
        if (polinom.Length == 1)
        {
            if (polinom[0] == 'x')
            {
                coefficentsPolinom[1] = 1;
            }
            else if (int.TryParse(polinom[0].ToString(), out temp))
            {
                coefficentsPolinom[0] = int.Parse(polinom[0].ToString());
            }

            return coefficentsPolinom;
        }
        else if (polinom.Length == 0)
        {
            return coefficentsPolinom;
        }

        //extract coefficents when the polinom is more than 1 symbol
        for (int i = 0; i < polinom.Length; i++)
        {
            //find the coefficent of x2
            if (polinom[i] == 'x' && i < polinom.Length - 1 && polinom[i + 1] == '2')
            {
                if (i != 0)
                {
                    coefficentsPolinom[2] = ExtractCurrentNumber(i - 1, polinom);
                }
                else
                {
                    coefficentsPolinom[2] = 1;
                }
            }
            //find the coeffiecent of x
            else if (polinom[i] == 'x' && i < polinom.Length - 1)
            {
                if (polinom[i + 1] == '+' || polinom[i + 1] == '-' || polinom[i + 1] == ' ')
                {
                    if (i != 0)
                    {
                        coefficentsPolinom[1] = ExtractCurrentNumber(i - 1, polinom);
                    }
                    else
                    {
                        coefficentsPolinom[1] = 1;
                    }
                }
            }
            else if (polinom[i] == 'x' && i == polinom.Length - 1)
            {
                coefficentsPolinom[1] = ExtractCurrentNumber(i - 1, polinom);
            }

            //find the free coefficent
            else if (int.TryParse(polinom[i].ToString(), out temp))
            {
                if (i != 0 && polinom[i - 1] != 'x' &&
                    i != polinom.Length - 1 && polinom[i + 1] != 'x')
                {
                    coefficentsPolinom[0] = ExtractCurrentNumber(i, polinom);
                }
                else if (i == 0 && polinom[i + 1] != 'x')
                {
                    coefficentsPolinom[0] = ExtractCurrentNumber(i, polinom);
                }
                else if (i == polinom.Length - 1 && polinom[i - 1] != 'x')
                {
                    coefficentsPolinom[0] = ExtractCurrentNumber(i, polinom);
                }
            }
        }
        return coefficentsPolinom;
    }

    //this method will extract the coefficent starting from its last diit index(covering when coefficent is more than 1 digit)
    private static int ExtractCurrentNumber(int startIndex, string polinom)
    {
        int temp = 0;
        //find the last digit of the coefficent
        while (startIndex < polinom.Length - 1 && int.TryParse(polinom[startIndex + 1].ToString(), out temp))
        {
            startIndex++;
        }
        string currentNumber = polinom[startIndex].ToString();

        int j = startIndex - 1;
        while (j >= 0 && int.TryParse(polinom[j].ToString(), out temp))
        {
            currentNumber = polinom[j].ToString() + currentNumber;
            j--;
        }

        int number = int.Parse(currentNumber);

        //get the sign of the coefficent
        while (j >= 0)
        {
            if (polinom[j] == '-')
            {
                number *= -1;
                break;
            }
            else if (polinom[j] == '+')
            {
                break;
            }

            j--;
        }
        return number;
    }
}
