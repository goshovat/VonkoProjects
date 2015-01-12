using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fraction
{
    class Fraction
    {
        private int numerator;
        private int denominator;

        //define the constructor of the class
        public Fraction()
            : this(1, 1)
        {
        }

        public Fraction(int numerator, int denominator)
        {
            this.numerator = numerator;
            this.denominator = denominator;
        }

        //define the properties of the class
        public int Numerator
        {
            get { return this.numerator; }
        }

        public int Denominator
        {
            get { return this.denominator; }
        }

        public double Decimal
        {
            get
            {
                double result = 0d;
                result = double.Parse(
                        string.Format("{0:N2}", (double)this.numerator / (double)this.denominator)
                    );

                return result;
            }
        }

        //define methods of the instance
        public void AbbreviateFraction()
        {
            int newNumerator = Math.Abs(this.numerator);
            int newDenominator = Math.Abs(this.denominator);

            while (newNumerator > 0 && newDenominator > 0)
            {
                if (newNumerator > newDenominator)
                {
                    newNumerator -= newDenominator;
                }
                else
                {
                    newDenominator -= newNumerator;
                }
            }

            int greatestCommonDenominator = Math.Max(newNumerator, newDenominator);
            Console.WriteLine(greatestCommonDenominator);

            this.numerator /= greatestCommonDenominator;
            this.denominator /= greatestCommonDenominator;
        }

        public override string ToString()
        {
            return this.numerator + "/" + this.denominator;
        }

        //define the static method for parsing
        public static Fraction Parse(string input)
        {
            if (input == null)
                throw new ApplicationException("Error! Cannot parse a fraction, you have given a string with null value!");

            if (input == "")
                throw new ApplicationException("Error! Cannot parse a fraction, you have given a string with empty value!");

            if (input.Length < 3)
                throw new ApplicationException(string.Format("Error! Invalid input {0}, a fraction must be at least 3 signs.", input));

            bool negative = false;
            if (input[0] == '-')
                negative = true;

            int numerator = 0;
            int denominator = 1;

            ExtractFractionParts(ref numerator, ref denominator, input);

            if (negative)
                numerator *= -1;

            if (denominator == 0)
                throw new ApplicationException(string.Format("Error! Denomminator 0 in {0}", input));

            return new Fraction(numerator, denominator);
        }

        //these two static methods will be used by the parse method and are private for the class
        private static void ExtractFractionParts(ref int numerator, ref int denominator, string input)
        {
            StringBuilder numeratorStrBuild = new StringBuilder();
            StringBuilder denominatorStrBuild = new StringBuilder();

            int index = 0;
            while (index < input.Length && input[index] == '-')
                index++;

            while (index < input.Length && input[index] != '/')
            {
                if (IsValidNumber(input[index]))
                {
                    numeratorStrBuild.Append(input[index]);
                }
                else
                {
                    throw new ApplicationException(string.Format("Invalid sign at index {0} in the input {1}",
                        index, input));
                }
                index++;
            }
            index++;

            while (index < input.Length)
            {
                if (IsValidNumber(input[index]))
                {
                    denominatorStrBuild.Append(input[index]);
                }
                else
                {
                    throw new ApplicationException(string.Format("Invalid sign at index {0} in the input {1}",
                        index, input));
                }
                index++;
            }

            if (numeratorStrBuild.ToString() == "")
                throw new ApplicationException(string.Format("Error! No numerator in {0}", input));
            if (denominatorStrBuild.ToString() == "")
                throw new ApplicationException(string.Format("Error! No denominator in {0}", input));

            try
            {
                numerator = int.Parse(numeratorStrBuild.ToString());
            }
            catch (OverflowException overflowExc)
            {
                throw new ApplicationException("Error! The numerator cannot fit in int32.", overflowExc);
            }
            catch (FormatException formatExc)
            {
                throw new ApplicationException("Error! The numerator is not valid integer(int32).", formatExc);
            }    

            try
            {
                denominator = int.Parse(denominatorStrBuild.ToString());
            }
            catch (OverflowException overflowExc)
            {
                throw new ApplicationException("Error! The denominator cannot fit in int32.", overflowExc);
            }
            catch (FormatException formatExc)
            {
                throw new ApplicationException("Error! The denominator is not valid integer(int32).", formatExc);
            }
        }

        private static bool IsValidNumber(char sign)
        {
            if (sign != '0' && sign != '1' && sign != '2' && sign != '3'
                    && sign != '4' && sign != '5' && sign != '6' && sign != '7' && sign != '8' && sign != '9')
            {
                return false;
            }

            return true;
        }
    }
}
