namespace _08LettersChangeNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            List<string> result = new List<string>();

            string boxFirst = string.Empty;
            string boxLast = string.Empty;
            string boxNumber = string.Empty;

            int indexInAlphabet = 0;

            char upperFirst;
            char upperLast;
            char lowerFirst;
            char lowerLast;
            double number = 0;
            double sum = 0;

            foreach (var i in input)
            {
                result.Add(i);
            }

            foreach (var str in result)
            {
                boxNumber = str.Substring(1, str.Length - 2);
                boxFirst = str.Remove(1);
                boxLast = str.Substring(str.Length - 1);

                if (boxNumber.Any(a => char.IsDigit(a)))
                {
                    number = int.Parse(boxNumber);
                }

                if (boxFirst.Any(a => char.IsUpper(a)))
                {
                    upperFirst = char.Parse(boxFirst);
                    indexInAlphabet = GetIndexInAlphabet(upperFirst);
                    number /= indexInAlphabet;
                }
                if (boxFirst.Any(a => char.IsLower(a)))
                {
                    lowerFirst = char.Parse(boxFirst);
                    indexInAlphabet = GetIndexInAlphabet(lowerFirst);
                    number *= indexInAlphabet;
                }
                if (boxLast.Any(a => char.IsUpper(a)))
                {
                    upperLast = char.Parse(boxLast);
                    indexInAlphabet = GetIndexInAlphabet(upperLast);
                    number -= indexInAlphabet;
                }
                if (boxLast.Any(a => char.IsLower(a)))
                {
                    lowerLast = char.Parse(boxLast);
                    indexInAlphabet = GetIndexInAlphabet(lowerLast);
                    number += indexInAlphabet;
                }

                sum += number;
            }

            Console.WriteLine($"{sum:f2}");
        }

        private static int GetIndexInAlphabet(char value)
        {
            char letter = char.ToUpper(value);

            return (int)letter - (int)'A' + 1;
        }
    }
}