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
            return Convert.ToInt32(input);
        }
    }
}