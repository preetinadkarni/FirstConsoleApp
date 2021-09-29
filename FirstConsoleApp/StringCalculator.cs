using System.Net.Sockets;
using System;

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
                string numbersList = input.Substring(4, 3);
                Console.Write(numbersList);

                numbers = numbersList.Split(';');
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