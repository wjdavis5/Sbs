using System;

namespace TestApp
{
    class Program
    {
        public const string TotallyRandomTextValue = "TotallyRandomTextValue";

        static void Main(string[] args)
        {
            var b = new Board(TotallyRandomTextValue, TotallyRandomTextValue);
            foreach (var number in b.RowNumbers)
            {
                Console.Write($"     |   {number}   |");
            }
            Console.WriteLine();
            Console.WriteLine($"---------------------------------------------------------------------------------------------");
        }
    }
}
