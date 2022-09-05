using System;
using System.Collections.Generic;
using System.Text;

namespace TotoCombinations.UI
{
    public class UserTotoProfile
    {
        public void UICreator(out int upperLimitNumber, out int luckyNum)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Моля изберете предпочитание за ТОТО [6x49] или [5x35]");

            upperLimitNumber = 0;
            luckyNum = 0;
            Console.WriteLine("Моля, въведете число 5 ( за тото 5х35) или 6 (за тото 6х49)");
            int TotoPrefference = 0;
            while (true)
            {
                bool isNumber = int.TryParse(Console.ReadLine(), out int resultNum);
                if (isNumber)
                {
                    TotoPrefference = resultNum;
                    if (TotoPrefference == 5 || TotoPrefference == 6)
                    {
                        break;
                    }
                    Console.WriteLine("Моля, въведете число 5 ( за тото 5х35) или 6 (за тото 6х49)");
                }
                else
                {
                    Console.WriteLine("Моля въведете число , а не Текст  >:(  !!!");
                }
            }

            if (TotoPrefference == 5)
            {
                upperLimitNumber = 36;
                luckyNum = 5;

            }
            else if (TotoPrefference == 6)
            {
                upperLimitNumber = 50;
                luckyNum = 6;
            }
        }

        
    }
}
