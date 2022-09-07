using System;
using System.Collections.Generic;
using System.Linq;
using TotoProject.Helper;
using TotoProject.UI;

namespace TotoProject
{
    public class StartUp
    {             
        static void Main(string[] args)
        {
            UserTotoProfile totoProfile = new UserTotoProfile();
            List<int> totoBounderies = totoProfile.UICreator();
            int chosenTotoUpperBound = totoBounderies[0];
            int chosenTotoLowerBound = totoBounderies[1];
            HashSet<string> rowNumberSet = new HashSet<string>();
            HashSet<string> rowNumberSetCopy = new HashSet<string>();
            Random rnd = new Random();
            NumberGenerator generator = new NumberGenerator();
            int countNums = 0;
            int totalIterations = 0;
            string result = string.Empty;

            while (countNums < 8500)
            {
                totalIterations++;
                result = generator.CreateRandomNumbers(10, chosenTotoUpperBound);
                countNums++;
                rowNumberSetCopy.Add($"Row No:{totalIterations}, |<{result}>|");
                rowNumberSet.Add(result);
            }
            Console.WriteLine(string.Join("\r\n", rowNumberSetCopy));

            Console.WriteLine(GlobalConstants.TheHundredCombinations);

            countNums = 0;
            string[] numArr = new string[rowNumberSet.Count];
            List<string> last100Combinations = new List<string>();
            while (countNums < 100)
            {
                int luckyIndex = rnd.Next(0, rowNumberSet.Count);

                numArr = new string[rowNumberSet.Count];
                numArr = rowNumberSet.ToArray();                
                last100Combinations.Add(numArr[(luckyIndex - 1) < 0? 0: luckyIndex - 1]);
                countNums++;
                Console.WriteLine(GlobalConstants.PrintRowWithCombinations, countNums, luckyIndex, numArr[luckyIndex - 1]);
            }
            Console.WriteLine();
            Console.WriteLine();
            int[,] totoMatrix = new int[100, 10];
            int incr = 0;
            Dictionary<int, int> occurrances = new Dictionary<int, int>();
            for (int i = 1; i <= 49; i++)
            {
                occurrances.Add(i, 0);
            }
            for (int i = 0; i < last100Combinations.Count; i++)
            {
                for (int row = incr; row < 100; row++)
                {
                    int[] rowNumbers = last100Combinations[i].Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                    for (int col = 0; col < 10; col++)
                    {
                        totoMatrix[row, col] = rowNumbers[col];
                        if (!occurrances.ContainsKey(totoMatrix[row, col]))
                        {
                            occurrances.Add(totoMatrix[row, col], 0);
                        }
                        occurrances[totoMatrix[row, col]]++;
                    }
                    incr++;
                    break;
                }
            }
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(GlobalConstants.Matrix10x100);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
            NumberGenerator printNumbers = new NumberGenerator();
            printNumbers.PrintMatrix(totoMatrix);
            Console.WriteLine();

            Console.WriteLine(GlobalConstants.SmallTiers);
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(GlobalConstants.UnsortedOccurrances, chosenTotoUpperBound - 1);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(GlobalConstants.SmallTiers);

            int countOccur = 0;
            int count = 0;
            List<int> finalResult = new List<int>();
            foreach (var item in occurrances)
            {
                Console.Write($"({item.Key}) -> [{item.Value}]times, ");
                countOccur++;
                if (countOccur % 6 == 0)
                {
                    Console.WriteLine();
                }
            }
            occurrances = occurrances.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, y => y.Value);
            Console.WriteLine();
            Console.WriteLine(GlobalConstants.LongTiers);
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(GlobalConstants.SortedOccurrances);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(GlobalConstants.LongTiers);
            finalResult.Clear();
            count = 0;

            int maxColoredNums = chosenTotoLowerBound == 5 ? 5 : 6;
            bool isToto5of35 = maxColoredNums == 5 ? true : false;

            foreach (var item in occurrances)
            {
                if (isToto5of35 && maxColoredNums > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"({item.Key})->[{item.Value}]times, ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    maxColoredNums--;
                }
                else if (!isToto5of35 && maxColoredNums > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"({item.Key})->[{item.Value}]times, ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    maxColoredNums--;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write($"({item.Key})->[{item.Value}]times, ");
                }
                countOccur++;
                if (countOccur % 6 == 0)
                {
                    Console.WriteLine();
                }
                if (count < chosenTotoLowerBound)
                {
                    finalResult.Add(item.Key);
                    count++;
                }

            }
            totoProfile.TotoResultViewer(chosenTotoLowerBound, totalIterations, finalResult);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(GlobalConstants.LongTiers);
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(GlobalConstants.NeedARecord);
            Console.WriteLine(GlobalConstants.Answer);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(GlobalConstants.LongTiers);
            if (Console.ReadKey().Key==ConsoleKey.Y)
            {
                //Write All the Toto Numbers into file to keep the last records.
                string luckyNumbers = string.Join(",", finalResult);
                generator.TotoNumberRecorder(luckyNumbers);
                Console.Clear();
                Console.WriteLine(GlobalConstants.LuckyNumberRecorded);
                return;
            }            
            Console.WriteLine(GlobalConstants.NumbersLost);
        }
    }
}
