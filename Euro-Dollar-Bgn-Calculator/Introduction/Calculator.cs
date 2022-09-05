using Euro_Dollar_Bgn_Calculator.Contracts;
using Euro_Dollar_Bgn_Calculator.Enum;
using System;


namespace Euro_Dollar_Bgn_Calculator.Introduction
{

    public class Calculator : ICalculator
    {   // Feel free to assign daily currency excange value rates here.
        public const decimal BGNtoUSD = 0.51571219M; // BGN -> USD
        public const decimal BGNtoEUR = 0.51129188M;  // BGN -> EUR
        public const decimal USDtoBGN = 1.9390661M;  // USD -> BGN
        public const decimal USDtoEUR = 0.9913833M;  // USD -> EUR        
        public const decimal EURtoBGN = 1.95583M;  // EUR -> BGN
        public const decimal EURtoUSD = 1.0086916M;  // EUR -> USD
        public decimal CalculateMoneyBGN(int preferedExcangeValuta, decimal resultCalculated, decimal moneyInput)
        {
            if (preferedExcangeValuta + 1 == (int)CurrencyEnum.USD)
            {
                resultCalculated = moneyInput * BGNtoUSD;
            }
            else if (preferedExcangeValuta + 1 == (int)CurrencyEnum.EUR)
            {
                resultCalculated = moneyInput * BGNtoEUR;
            }

            return resultCalculated;
        }

        public decimal CalculateMoneyEUR(int preferedExcangeValuta, decimal resultCalculated, decimal moneyInput)
        {
            if (preferedExcangeValuta == (int)CurrencyEnum.BGN)
            {
                resultCalculated = moneyInput * EURtoBGN;
            }
            else if (preferedExcangeValuta == (int)CurrencyEnum.USD)
            {
                resultCalculated = moneyInput * EURtoUSD;
            }


            return resultCalculated;
        }

        public decimal CalculateMoneyUSD(int preferedExcangeValuta, decimal resultCalculated, decimal moneyInput)
        {
            if (preferedExcangeValuta == (int)CurrencyEnum.BGN)
            {
                resultCalculated = moneyInput * USDtoBGN;
            }
            else if (preferedExcangeValuta + 1 == (int)CurrencyEnum.EUR)
            {
                resultCalculated = moneyInput * USDtoEUR;
            }

            return resultCalculated;
        }

        public void CheckMoneyCurrency(decimal moneyInput, int currencyIndex, bool[] isCurrencyBGN_USD_EUR)
        {
            if (currencyIndex == (int)CurrencyEnum.BGN) // 1 BGN
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Твоята налична сума е {moneyInput:f3} BGN");

                Console.WriteLine();
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Курс за деня:BGN-EUR [ {BGNtoEUR} ]");
                Console.WriteLine($"Курс за деня:BGN-USD [ {BGNtoUSD} ]");
                isCurrencyBGN_USD_EUR[0] = true;
            }
            else if (currencyIndex == (int)CurrencyEnum.USD) // 2 USD
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Твоята налична сума е {moneyInput:f3} USD");
                isCurrencyBGN_USD_EUR[1] = true;

                Console.WriteLine();
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Курс за деня:USD-BGN [ {USDtoBGN} ]");
                Console.WriteLine($"Курс за деня:USD-EUR [ {USDtoEUR} ]");
            }
            else  // 3 EUR
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Твоята налична сума е {moneyInput:f3} EURO");
                isCurrencyBGN_USD_EUR[2] = true;

                Console.WriteLine();
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Курс за деня:EUR-BGN [ {EURtoBGN} ]");
                Console.WriteLine($"Курс за деня:EUR-USD [ {EURtoUSD} ]");
            }
        }

        public string CurrencyChooser(int currencyIndex)
        {
            Console.WriteLine();
            Console.WriteLine(new string('^', 35));
            Console.WriteLine("В каква валута искате да смените парите си?");

            string initialCurrency = string.Empty;
            if (currencyIndex == 1) // BGN
            {
                Console.WriteLine("Натиснете 1) за USD");
                Console.WriteLine("Натиснете 2) за EUR");
                initialCurrency = "BGN";
            }
            else if (currencyIndex == 2) // USD
            {
                Console.WriteLine("Натиснете 1) за BGN");
                Console.WriteLine("Натиснете 2) за EUR");
                initialCurrency = "USD";
            }
            else if (currencyIndex == 3) // EUR
            {
                Console.WriteLine("Натиснете 1) за BGN");
                Console.WriteLine("Натиснете 2) за USD");
                initialCurrency = "EUR";
            }

            return initialCurrency;
        }

    }
}
