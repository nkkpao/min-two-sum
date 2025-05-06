using System;

namespace MinTwoSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sample = { 4, 0, 3, 19, 492, -10, 1 };
            int result = MinTwoCalculator.SumTwoMinElements(sample);
            Console.WriteLine($"Сумма двух минимальных чисел: {result}");
        }
    }
}