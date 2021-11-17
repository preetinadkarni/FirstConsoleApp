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
            CheckInputHasNegativeNumbers(numbers);
            
            return numbers.Sum();
        }

        private void CheckInputHasNegativeNumbers(int[] numbers)
        {
            int[] negativeNumbers = GetNegativeNumbers(numbers);

            if (negativeNumbers.Length > 0)
            {
                throw new ArgumentException("Negatives not allowed: " + string.Join(", ", negativeNumbers));
            }
        }
        private int[] GetNegativeNumbers(int[] numbers)
        {
            return Array.FindAll(numbers, n => n < 0);
        }

        private int[] GetNumbersLessThanThousand(int[] numbers)
        {
            return Array.FindAll(numbers, n => n < 1000);
        }

        private int[] GetNumbers(string input)
        {
            string[] sNumbers;
            bool isDelimiterSpecifiedInInput = input.StartsWith("//");
            if (isDelimiterSpecifiedInInput)
            {
                string[] delimiters = GetDelimiters(input);
                string numbersList = GetNumbersFromInput(input);
                sNumbers = numbersList.Split(delimiters, StringSplitOptions.None);
            }
            else
            {
                string[] defaultDelimiters = {",", "\n"};
                sNumbers = input.Split(defaultDelimiters,  StringSplitOptions.None);
            }

            int[] iNumbers = Array.ConvertAll(sNumbers, int.Parse);
            iNumbers = GetNumbersLessThanThousand(iNumbers);
            return iNumbers;
        }

        private string GetNumbersFromInput(string input)
        {
            int startIndex = input.IndexOf('\n') + 1;
            string numbersList = input.Substring(startIndex);
            return numbersList;
        }

        private string[] GetDelimiters(string input)
        {
            List<string> delimiters = new List<string>();
            bool hasMultipleDelimiters = input.IndexOf('[') > 0;
            if (hasMultipleDelimiters)
            {
                delimiters = GetMultipleDelimitersInAnArray(input);

            }
            else
                delimiters.Add(input.Substring(2, 1));

            return delimiters.ToArray();
        }

        private List<string> GetMultipleDelimitersInAnArray(string input)
        {
            int startIndex = input.IndexOf('[');
            int endIndex = input.LastIndexOf(']') + 1 ;
            string allDelimitersInInput = input.Substring(startIndex,endIndex - startIndex );
            
            List<string> delimiters = new List<string>(allDelimitersInInput.Split('[',']'));
            delimiters.Remove("");
            return delimiters;
        }
        
    }
}