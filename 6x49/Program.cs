
using _6x49;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _6x49
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 1;
            int b = 50;
            Random rnd = new Random();

            int[,] matrix6x6 = Options.GetMatrix(a, b, rnd);
            Options.MatrixInfoExtractor(rnd, matrix6x6);

        }

        
    }
}
