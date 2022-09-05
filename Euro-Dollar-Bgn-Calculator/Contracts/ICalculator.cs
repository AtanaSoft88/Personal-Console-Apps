using System;
using System.Collections.Generic;
using System.Text;

namespace Euro_Dollar_Bgn_Calculator.Contracts
{
    public interface ICalculator
    {        
        public decimal CalculateMoneyBGN(int exchangeCurrency, decimal resultCalculated, decimal moneyInput);
        public decimal CalculateMoneyUSD(int exchangeCurrency, decimal resultCalculated, decimal moneyInput);
        public decimal CalculateMoneyEUR(int exchangeCurrency, decimal resultCalculated, decimal moneyInput);        
    }
}
