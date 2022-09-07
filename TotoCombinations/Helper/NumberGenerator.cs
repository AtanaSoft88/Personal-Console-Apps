using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TotoProject.Helper
{
    public class NumberGenerator
    {
        public string CreateRandomNumbers(int length, int upperLimit)
        {
            Random random = new Random();
            HashSet<int> result = new HashSet<int>();
            char[] chars = new char[length];
            while (result.Count != 10)
            {
                int num = random.Next(1, upperLimit);

                result.Add(num);
            }
            return string.Join(",", result);
        }

        public void PrintMatrix(int[,] Matrix)
        {
            for (int row = 0; row < 100; row++)
            {
                for (int col = 0; col < 10; col++)
                {
                    Console.Write(Matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        public void TotoNumberRecorder(string luckyNumbers)
        {
            string outputPath = @"..\..\..\LuckyNumbers.txt";
            using FileStream fileStrm = File.Open(outputPath, FileMode.Append); // will append to end of file
            using StreamWriter writer = new StreamWriter(fileStrm);
            writer.WriteLine($"{luckyNumbers} - Date: {DateTime.Now}");
        }
    }
}
