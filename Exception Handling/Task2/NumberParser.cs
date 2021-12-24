using System;
using System.Text.RegularExpressions;

namespace Task2
{
    public class NumberParser : INumberParser
    {
        private bool isNegative;
        private readonly string plusPattern = @"^\+";
        private readonly string minusPattern = @"^-";
        private readonly string formatPattern = @"^[\+-]?\d+$";

        public int Parse(string stringValue)
        {
            stringValue =  ValidateString(stringValue);

            long value = 0;
            var power = stringValue.Length - 1;

            foreach (var @char in stringValue)
            {
                int number = @char - '0';
                value += number * (int) Math.Pow(10, power);
                power--;
            }

            if (isNegative)
            {
                value = 0 - value;
            }

            var result = ValidateNumber(value);

            return result;
        }

        private string ValidateString(string source)
        {
            var formatRegex = new Regex(formatPattern);
            if (source == null)
            {
                throw new ArgumentNullException();
            }
            var dest = source.Trim();
            if (!formatRegex.IsMatch(dest))
            {
                throw new FormatException();
            }

            isNegative = false;
            var plusRegex = new Regex(plusPattern);
            var minusRegex = new Regex(minusPattern);
            if (plusRegex.IsMatch(dest))
            {
                dest = Regex.Replace(dest, plusPattern, "");
            }
            if (minusRegex.IsMatch(dest))
            {
                dest = Regex.Replace(dest, minusPattern, "");
                isNegative = true;
            }

            return dest;
        }

        private int ValidateNumber(long source)
        {
            if (source >= 2147483648 || source <= -2147483649)
            {
                throw new OverflowException();
            }

            return (int) source;
        }
    }
}