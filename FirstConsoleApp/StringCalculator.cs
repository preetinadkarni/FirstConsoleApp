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

            int[] numbers = GetNumbersArray(input);
            int sum = 0;

            foreach (var item in numbers)
            {
                sum += item;
            }
            return sum;
        }

        private int[] GetNumbersArray(string input)
        {
            string[] numbers;
            bool isSeparatorSpecifiedinInput = input.StartsWith("//");
            if (isSeparatorSpecifiedinInput)
            {
                string separator = GetSeparator(input);
                var numbersList = GetNumbersList(input);
                numbers = numbersList.Split(separator);
            }
            else
            {
                char[] defaultSeparators = {',', '\n'};
                numbers = input.Split(defaultSeparators);
            }

            return Array.ConvertAll(numbers,int.Parse);
        }

        private string GetNumbersList(string input)
        {
            int startIndex = input.IndexOf('\n') + 1;
            string numbersList = input.Substring(startIndex);
            return numbersList;
        }

        private string GetSeparator(string input)
        {
            return input.Substring(2,1);
        }
        
    }
    
    
}