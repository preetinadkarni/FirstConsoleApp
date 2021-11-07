using System.Net.Sockets;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FirstConsoleApp
{
    public class StringCalculator
    {
        public StringCalculator() { }

        public int Add(string input)
        {
            if (!input.Any(Char.IsDigit)) return 0;

            int[] numbers = GetNumbers(input);
            int sum = 0;

            int[] negativeNumbers = GetNegativeNumbers(numbers);
            
            if(negativeNumbers.Length > 0 )
            {
                throw new ArgumentException("Negatives not allowed: " + string.Join(", ", negativeNumbers));
            }

            numbers = RemoveNumbersGreaterThanThousand(numbers);
            return numbers.Sum();
        }

        private int[] GetNegativeNumbers(int[] numbers)
        {
            return Array.FindAll(numbers, n => n < 0);
        }

        private int[] RemoveNumbersGreaterThanThousand(int[] numbers)
        {
            return Array.FindAll(numbers, n => n < 1000);
        }

        private int[] GetNumbers(string input)
        {
            string[] numbers;
            bool isSeparatorSpecifiedInInput = input.StartsWith("//");
            if (isSeparatorSpecifiedInInput)
            {
                string[] separators = GetDelimiter(input);
                string numbersList = GetNumbersFromInput(input);
                numbers = numbersList.Split(separators, StringSplitOptions.None);
            }
            else
            {
                string[] defaultSeparators = {",", "\n"};
                numbers = input.Split(defaultSeparators,  StringSplitOptions.None);
            }

            return Array.ConvertAll(numbers,int.Parse);
        }

        private string GetNumbersFromInput(string input)
        {
            int startIndex = input.IndexOf('\n') + 1;
            string numbersList = input.Substring(startIndex);
            return numbersList;
        }

        private string[] GetDelimiter(string input)
        {
            List<string> delimiters = new List<string>();
            bool hasMultipleDelimiters = input.IndexOf('[') > 0;
            if (hasMultipleDelimiters)
            {
                string allDelimitersInInput = GetAllDelimitersInInputAsString(input);
                delimiters = GetMultipleDelimitersInAnArray(allDelimitersInInput);

            }
            else
                delimiters.Add(input.Substring(2, 1));

            return delimiters.ToArray();
        }
        private string GetAllDelimitersInInputAsString(string input)
        {
            int startIndex = input.IndexOf('[');
            int endIndex = input.LastIndexOf(']') + 1 ;
            return input.Substring(startIndex,endIndex - startIndex );
        }

        private List<string> GetMultipleDelimitersInAnArray(string allDelimiters)
        {
             List<string> delimiters;
             delimiters = new List<string>(allDelimiters.Split('[',']'));
             delimiters.Remove("");
             return delimiters;
        }
        
    }
}