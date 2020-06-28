using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace NumberToText
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Number: ");
            string input = Console.ReadLine();
            bool isAmount;

            isAmount = double.TryParse(input, out double amount);
            var regex = @"^\d+(?:\.\d{0,2})?$";

            var match = Regex.Match(input, regex);

            if (!match.Success || !isAmount || amount <= 0)            
                Console.WriteLine("Input is not a valid currency.");            
            else
            {
                var amountArray = input.Split('.');

                int dollar = Convert.ToInt32(input.Split('.')[0]);
                string output = dollar.NumberToText() + " dollars ";

                if (amountArray.Length > 1)
                {
                    int cents = Convert.ToInt32(input.Split('.')[1]);
                    output += " and " + cents.NumberToText() + " cents";
                }

                Console.WriteLine(output);
            }
            Console.Read();
        }
    }
}
