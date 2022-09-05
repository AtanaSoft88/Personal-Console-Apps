
using Euro_Dollar_Bgn_Calculator.Introduction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Euro_Dollar_Bgn_Calculator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Calculator currencyCalc = new Calculator();
            List<object> objects = CalculatorIntro.Introductor();
            decimal moneyInput = (decimal)objects[0];
            int currencyIndex = (int)objects[1];
            bool[] isCurrencyBGN_USD_EUR = (bool[])objects[2];

            currencyCalc.CheckMoneyCurrency(moneyInput, currencyIndex, isCurrencyBGN_USD_EUR);

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;

            decimal resultCalculated = 0;
            string initialCurrency = currencyCalc.CurrencyChooser(currencyIndex);

            int preferredCurrencyIndex = int.Parse(Console.ReadLine());
            int countRetry = 0;
            while (preferredCurrencyIndex > 2)
            {
                if (countRetry > 2)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Последна възможност за избор.");
                    Console.WriteLine("Избери или 1 или 2 иначе приключвам програмата!");
                    preferredCurrencyIndex = int.Parse(Console.ReadLine());
                    if (preferredCurrencyIndex > 2)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("Беше предупреден!");
                        Console.WriteLine("Програмата приключи! Довиждане!");
                        return;
                    }
                    countRetry--;
                    continue;
                }
                countRetry++;

                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Невалиден избор на валута!");
                Console.WriteLine("Въведете един от възможните избори за валута!");

                preferredCurrencyIndex = int.Parse(Console.ReadLine());

            }
            string currentCurrency = string.Empty;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            if (currencyIndex == 1)
            {
                currentCurrency = preferredCurrencyIndex == 1 ? "USD" : preferredCurrencyIndex == 2 ? "EUR" : "";

            }
            else if (currencyIndex == 2) // us
            {
                currentCurrency = preferredCurrencyIndex == 1 ? "BGN" : preferredCurrencyIndex == 2 ? "EUR" : "";

            }
            else if (currencyIndex == 3) // eu
            {
                currentCurrency = preferredCurrencyIndex == 1 ? "BGN" : preferredCurrencyIndex == 2 ? "USD" : "";
            }
            Console.WriteLine("\r\n\r\n");            
            Console.WriteLine($"Избрана валута за трансфер : {currentCurrency}");            

            decimal calcMoneyTransferred = 0;
            for (int i = 0; i < isCurrencyBGN_USD_EUR.Length; i++)
            {
                if (isCurrencyBGN_USD_EUR[i] == true && initialCurrency == "BGN")  //BGN initial money to transfer
                {

                    calcMoneyTransferred = currencyCalc.CalculateMoneyBGN(preferredCurrencyIndex, resultCalculated, moneyInput);

                }
                else if (isCurrencyBGN_USD_EUR[i] == true && initialCurrency == "USD") // USD initial money to transfer
                {
                    calcMoneyTransferred = currencyCalc.CalculateMoneyUSD(preferredCurrencyIndex, resultCalculated, moneyInput);
                }
                else if (isCurrencyBGN_USD_EUR[i] == true && initialCurrency == "EUR") // EUR initial money to transfer
                {
                    calcMoneyTransferred = currencyCalc.CalculateMoneyEUR(preferredCurrencyIndex, resultCalculated, moneyInput);
                }
            }

            Console.WriteLine(new String('*', 50));
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"Трансферирана крайна сума след обръщение: {calcMoneyTransferred:f3} {currentCurrency}");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(new String('*', 50));

        }
        
    }
}
