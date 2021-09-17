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
            if (input == "") return 0;
            string[] numbers = input.Split(',','\n');
            int sum = 0;
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