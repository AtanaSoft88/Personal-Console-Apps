using System;
using System.Collections.Generic;
using System.Text;

namespace TotoProject.UI
{
    public class UserTotoProfile
    {
        public List<int> UICreator()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine(GlobalConstants.PreferredTotoType);            
            int upperLimitNumber=0;
            int lowerLimitNumber=0;            
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
                    Console.WriteLine(GlobalConstants.PreferredTotoType);
                }
                else
                {
                    Console.WriteLine(GlobalConstants.EnterNumberPlease);
                }
            }

            if (TotoPrefference == 5)
            {
                upperLimitNumber = 36;
                lowerLimitNumber = 5;

            }
            else if (TotoPrefference == 6)
            {
                upperLimitNumber = 50;
                lowerLimitNumber = 6;
            }            
            return new List<int>() { upperLimitNumber, lowerLimitNumber };
        }                
        public void TotoResultViewer(int luckyNum, int totalIterationsPass, List<int> finalResult)
        {
            var dt = DateTime.Now.ToString("d");
            Console.ResetColor();
            Console.WriteLine("\r\n");

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(GlobalConstants.FinalReportInfo, luckyNum, luckyNum, luckyNum, totalIterationsPass);

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-           -=-=-=-=-=-=-=-=-=-=-=-");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("-=-=-=-=-=-=-=-=-       T O T O        -=-=-=-=-=-=-=-=-");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"-=-=-=-=-=-=-           {dt}              -=-=-=-=-=-=-");
            Console.WriteLine("-=-=-=-=-                                       -=-=-=-=-");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"-=-=-=-  ----===  {string.Join("||",finalResult)}  ===---- =-=-=-=-");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("-=-=-=-=-                                       -=-=-=-=-");          
            Console.WriteLine("-=-=-=-=-=-=-                               -=-=-=-=-=-=-");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-                   -=-=-=-=-=-=-=-=-=-");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-           -=-=-=-=-=-=-=-=-=-=-=-");
            Console.WriteLine();            
        }


    }
}
