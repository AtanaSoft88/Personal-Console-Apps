using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _6x49
{
    public static class Options
    {
        public static int[,] GetMatrix(int a, int b, Random rnd)
        {
            int[,] matrix6x6 = new int[6, 6];
            HashSet<int> checkForRepeatedNums = new HashSet<int>();
            List<int> numbers = new List<int>();
            int rowIncr = 0;
            for (int i = 0; i < 6; i++)
            {
                int count = -1;
                while (true)
                {
                    int currentRandNum = rnd.Next(a, b);

                    checkForRepeatedNums.Add(currentRandNum);
                    if (currentRandNum >= 1 && currentRandNum <= 49)
                    {
                        count++;
                        if (count is 6)
                        {
                            break;
                        }
                        numbers.Add(currentRandNum);
                    }

                }
                int rowIncrMax = rowIncr + 1;
                List<string> numbersCopyAsString = new List<string>();
                for (int j = 0; j < numbers.Count; j++)
                {
                    if (numbers[j]< 10)
                    {
                        numbersCopyAsString.Add($"0{numbers[j]}");
                    }
                    else
                    {
                        numbersCopyAsString.Add(numbers[j].ToString());
                    }
                }
                Console.WriteLine(string.Join(",", numbersCopyAsString));                

                for (int row = rowIncr; row < rowIncrMax; row++)
                {
                    List<int> input = numbers;
                    for (int col = 0; col < matrix6x6.GetLength(1); col++)
                    {
                        matrix6x6[row, col] = input[col];
                    }
                }
                rowIncr++;
                numbers.Clear();
                numbersCopyAsString.Clear();
            }

            return matrix6x6;
        }
        public static void MatrixInfoExtractor(Random rnd, int[,] matrix6x6)
        {
            List<int> firstDiagonal = new List<int>();
            List<int> secondDiagonal = new List<int>();
            List<int> firstColumn = new List<int>();
            List<int> lastColumn = new List<int>();
            int secondDiagonalIndex = 5;
            for (int row = 0; row < 6; row++)
            {

                for (int col = 0; col < 6; col++)
                {
                    if (row == col)
                    {
                        firstDiagonal.Add(matrix6x6[row, col]);
                    }
                    if (col == 0)
                    {
                        firstColumn.Add(matrix6x6[row, col]);
                    }
                    if (col == 5)
                    {
                        lastColumn.Add(matrix6x6[row, col]);
                    }
                    if (col == secondDiagonalIndex)
                    {
                        secondDiagonalIndex--;
                        secondDiagonal.Add(matrix6x6[row, col]);
                    }

                }
            }
            while (firstDiagonal.Count != 6 || secondDiagonal.Count != 6)
            {
                if (secondDiagonal.Count < 6)
                {
                    Console.WriteLine($"Added a nmber");
                    secondDiagonal.Add(firstColumn.ToArray()[firstColumn.Count - 1]);
                }
                if (firstDiagonal.Count < 6)
                {
                    Console.WriteLine($"Added a nmber");
                    firstDiagonal.Add(lastColumn.ToArray()[lastColumn.Count - 1]);
                }
            }
            List<int> suqare = new List<int>()
            {   firstDiagonal.First(),
                secondDiagonal.First(),
                firstColumn.Last(),
                lastColumn.Last()
            };
            Console.WriteLine($"{new string('*', 50)}\r\nDo you want more info about Matrix numbers?");
            Console.WriteLine("Press 1 - for YES\r\nPress 2 - for NO");
            int chosenNum = int.Parse(Console.ReadLine());
            if (chosenNum == 1)
            {
                Console.WriteLine("=================================");
                Console.WriteLine($"The four angle of the square 6x6 Matrix are: {string.Join(", ", suqare)}");
                Console.WriteLine("=================================");
                Console.WriteLine("First Diagonal numbers");
                Console.WriteLine(string.Join("||", firstDiagonal));
                Console.WriteLine("=================================");
                Console.WriteLine("Second Diagonal numbers");
                Console.WriteLine(string.Join("||", secondDiagonal));
                Console.WriteLine("=================================");
                Console.WriteLine("First Col numbers");
                Console.WriteLine(string.Join("|", firstColumn));
                Console.WriteLine("=================================");
                Console.WriteLine("Last Col numbers");
                Console.WriteLine(string.Join("|", lastColumn));
            }

        }
    }
}
