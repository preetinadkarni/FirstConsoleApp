using System.Net.Sockets;
using System;
using System.Linq;

namespace FirstConsoleApp
{
    public class StringCalculator
    {
        public StringCalculator()
        {
        }

        public int Add(string input)
        {
            string[] numbers;
            int sum = 0;
            
            if (input == "") return 0;
            if (input.StartsWith("//"))
            {
                string separator = input.Substring(2,1);
                int startIndex = input.IndexOf('\n') + 1;
                string numbersList = input.Substring( startIndex);
                numbers = numbersList.Split(separator);
            }
            else
            {
                char[] separators = {',', '\n'};
                numbers = input.Split(separators);
            }

            foreach (var item in numbers)
            {
                bool isNumber = int.TryParse(item, out int result);
                if (!isNumber)
                {
                    return 0;
                }

                sum += result;
            }
            
            return sum;
        }
    }
}