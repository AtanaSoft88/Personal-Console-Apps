using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TotoCombinations.NumGenerator;
using TotoCombinations.UI;

namespace Demo_Array_Indexes_New_Usage
{
    class Program
    {
        static void Main(string[] args)
        {
            UserTotoProfile totoProfile = new UserTotoProfile();
            int upperLimitNumber, luckyNum;
            totoProfile.UICreator(out upperLimitNumber, out luckyNum);

            HashSet<string> passwordSet = new HashSet<string>();
            HashSet<string> passwordSetCOpy = new HashSet<string>();
            Random rnd = new Random();
            NumberGenerator generator = new NumberGenerator();
            int countOfPasswords = 0;
            int totalIterationsPass = 0;
            string result = string.Empty;

            while (countOfPasswords < 8500)
            {
                totalIterationsPass++;
                result = generator.CreateRandomNumbers(10, upperLimitNumber);
                countOfPasswords++;
                passwordSetCOpy.Add($"Row No:{totalIterationsPass}, |<{result}>|");
                passwordSet.Add(result);
            }
            Console.WriteLine(string.Join("\r\n", passwordSetCOpy));
            Console.WriteLine();

            Console.WriteLine("The lucky numbers of next 100 combinations are....");
            Console.WriteLine();
            countOfPasswords = 0;
            string[] numArr = new string[passwordSet.Count];
            List<string> last100Combinations = new List<string>();
            while (countOfPasswords < 100)
            {
                int luckyIndex = rnd.Next(0, passwordSet.Count);

                numArr = new string[passwordSet.Count];
                numArr = passwordSet.ToArray();
                last100Combinations.Add(numArr[luckyIndex - 1]);
                countOfPasswords++;
                Console.WriteLine($"No:{countOfPasswords}Lucky row:{luckyIndex},with combination {numArr[luckyIndex - 1]} ");
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
            Console.WriteLine("That is how matrix 100x10 looks like :)");
            Console.WriteLine();
            NumberGenerator printerNumber = new NumberGenerator();
            printerNumber.PrintMatrix(totoMatrix);
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine($"Unsorted Occurrances of numbers from 1 to {upperLimitNumber - 1} !");
            Console.WriteLine("---------------------------------------------");
            int countOccur = 0;
            int count = 0;
            List<int> finalResult = new List<int>();
            foreach (var item in occurrances)
            {
                Console.Write($"({item.Key})->[{item.Value}]  ");
                countOccur++;
                if (countOccur % 6 == 0)
                {
                    Console.WriteLine();

                }
            }
            occurrances = occurrances.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, y => y.Value);
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("Sorted Occurrances of numbers ordered by Descending (Most occurrances first!)");
            Console.WriteLine("--------------------------------------------------------------------------");
            finalResult = new List<int>();
            count = 0;

            foreach (var item in occurrances)
            {
                Console.Write($"({item.Key})->[{item.Value}]  ");
                countOccur++;
                if (countOccur % 6 == 0)
                {
                    Console.WriteLine();

                }
                if (count < luckyNum)
                {
                    finalResult.Add(item.Key);
                    count++;
                }

            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"Случайна комбинация от {luckyNum} числа,създадена чрез {luckyNum} произволни цифри,съединявайки първите {luckyNum} най-повтарящи се цифри във произволни 100 от {totalIterationsPass} комбинации");
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-           -=-=-=-=-=-=-=-=-=-=-=-");
            Console.WriteLine("-=-=-=-=-=-=-=-=-                       -=-=-=-=-=-=-=-=-");
            Console.WriteLine("-=-=-=-=-=-=-                               -=-=-=-=-=-=-");
            Console.WriteLine("-=-=-=-=-                                       -=-=-=-=-");
            Console.WriteLine($"-=-=-=-   ----=== {string.Join("||", finalResult)} ===---- =-=-=-=-");
            Console.WriteLine("-=-=-=-=-                                       -=-=-=-=-");
            Console.WriteLine("-=-=-=-=-=-=-                               -=-=-=-=-=-=-");
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-                   -=-=-=-=-=-=-=-=-=-");
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-           -=-=-=-=-=-=-=-=-=-=-=-");
            Console.WriteLine();

            //Write All the Toto Numbers into file to keep the last records.
            string currentluckyNumbers = string.Join(",", finalResult);
            string outputPath = @"..\..\..\LuckyNumbers.txt";
            using FileStream fileStrm = File.Open(outputPath, FileMode.Append); // will append to end of file
            using StreamWriter writer = new StreamWriter(fileStrm);
            writer.WriteLine($"{currentluckyNumbers}");
        }    
                       
    }
}
