using System.Net.Sockets;
using System;
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

        private static int[] GetNegativeNumbers(int[] numbers)
        {
            return Array.FindAll(numbers, n => n < 0);
        }

        private static int[] RemoveNumbersGreaterThanThousand(int[] numbers)
        {
            return Array.FindAll(numbers, n => n < 1000);
        }

        private int[] GetNumbers(string input)
        {
            string[] numbers;
            bool isSeparatorSpecifiedInInput = input.StartsWith("//");
            if (isSeparatorSpecifiedInInput)
            {
                string separator = GetDelimiter(input);
                string numbersList = GetNumbersFromInput(input);
                numbers = numbersList.Split(separator);
            }
            else
            {
                char[] defaultSeparators = {',', '\n'};
                numbers = input.Split(defaultSeparators);
            }

            return Array.ConvertAll(numbers,int.Parse);
        }

        private string GetNumbersFromInput(string input)
        {
            int startIndex = input.IndexOf('\n') + 1;
            string numbersList = input.Substring(startIndex);
            return numbersList;
        }

        private string GetDelimiter(string input) 
        {
            if (input.IndexOf('[') > 0)
            {
                int startIndex = input.IndexOf('[') + 1;
                int endIndex = input.IndexOf(']');
                string inputDelimiters = input.Substring(startIndex,  endIndex - startIndex);
                return inputDelimiters;
            }

            return input.Substring(2, 1);
        }
        
    }
    
    
}