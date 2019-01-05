using System;
using System.Collections.Generic;
using System.Text;

namespace FischToolsLib.Utilies
{
    public static class Calculations
    {
        public static int Factorial(int input)
        {
            var result = 1;
            while (input != 1)
            {
                result = result * input;
                input = input - 1;
            }
            return result;
        }
    }
}
