using System;
using System.Collections.Generic;
using System.Text;

namespace Euro_Dollar_Bgn_Calculator.Introduction
{
    public static class CalculatorIntro
    {
        public static List<object> Introductor() 
        {
            var obj = new List<object>();
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Каква е наличната Ви сума, която искате да обмените??");
            decimal resultMoney = 0;
            while (true)
            {
                bool isValidInput = decimal.TryParse(Console.ReadLine(), out decimal resultDecimal);
                if (!isValidInput)
                {
                    Console.WriteLine("Въведи числена сума!");
                }
                else
                {
                    resultMoney = resultDecimal;
                    break;
                }
            }            
            Console.WriteLine("Сумата Ви съответства на една от следните валути...");
            Console.WriteLine("Натиснете 1) -->> BGN");
            Console.WriteLine("Натиснете 2) -->> USD");
            Console.WriteLine("Натиснете 3) -->> EUR");
            int currencyIndex = int.Parse(Console.ReadLine());
            if (currencyIndex < 1 || currencyIndex > 3)
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Няма такава валута!");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Програмата приключи!");
                Environment.Exit(666);
            }
            Console.WriteLine();
            Console.Clear();
            Console.WriteLine(new string('^', 35));

            bool[] isCurrencyBGN_USD_EUR = new bool[3]
            {
                false,
                false,
                false
            };
            obj.Add(resultMoney);
            obj.Add(currencyIndex);
            obj.Add(isCurrencyBGN_USD_EUR);
            return obj;
        }        
    }
}
