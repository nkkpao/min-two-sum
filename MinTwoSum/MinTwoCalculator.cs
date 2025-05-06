using System;

namespace MinTwoSum
{
    public static class MinTwoCalculator
    {
        public static int SumTwoMinElements(int[] numbers)
        {
            if (numbers == null || numbers.Length < 2)
                throw new ArgumentException("Массив должен содержать как минимум два элемента.");

            int min1 = numbers[0];
            int min2 = numbers[1];
            if (min2 < min1)
                (min1, min2) = (min2, min1);

            for (int i = 2; i < numbers.Length; i++)
            {
                int x = numbers[i];
                if (x < min1)
                {
                    min2 = min1;
                    min1 = x;
                }
                else if (x < min2)
                {
                    min2 = x;
                }
            }

            return min1 + min2;
        }
    }
}