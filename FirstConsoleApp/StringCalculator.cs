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
            return numbers.Sum();
        }

        private static int[] GetNegativeNumbers(int[] numbers)
        {
            return Array.FindAll(numbers, n => n < 0);
        }

        private int[] GetNumbers(string input)
        {
            string[] numbers;
            bool isSeparatorSpecifiedinInput = input.StartsWith("//");
            if (isSeparatorSpecifiedinInput)
            {
                string separator = GetSeparator(input);
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

        private string GetSeparator(string input) 
        {
            return input.Substring(2,1);
        }
        
    }
    
    
}