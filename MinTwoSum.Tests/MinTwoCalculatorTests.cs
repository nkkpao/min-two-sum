using System;
using Xunit;
using MinTwoSum;

namespace MinTwoSum.Tests
{
    public class MinTwoCalculatorTests
    {
        [Fact]
        public void ReturnsCorrectSum_ForValidInput()
        {
            int[] data = { 4, 0, 3, 19, 492, -10, 1 };
            int result = MinTwoCalculator.SumTwoMinElements(data);
            Assert.Equal(-10, result);
        }

        [Fact]
        public void ThrowsException_ForInsufficientElements()
        {
            int[] data = { 5 };
            Assert.Throws<ArgumentException>(() => MinTwoCalculator.SumTwoMinElements(data));
        }

        [Fact]
        public void ThrowsException_ForEmptyArray()
        {
            int[] data = Array.Empty<int>();
            Assert.Throws<ArgumentException>(() => MinTwoCalculator.SumTwoMinElements(data));
        }

        [Fact]
        public void ThrowsException_ForNullInput()
        {
            int[]? data = null;
            Assert.Throws<ArgumentException>(() => MinTwoCalculator.SumTwoMinElements(data));
        }

        [Fact]
        public void ReturnsCorrectSum_ForExactlyTwoElements()
        {
            int[] data = { -3, 7 };
            int result = MinTwoCalculator.SumTwoMinElements(data);
            Assert.Equal(4, result);
        }

        [Fact]
        public void HandlesLargeArray_Correctness()
        {
            const int n = 100_000_000;
            var data = new int[n];
            for (int i = 0; i < n; i++)
                data[i] = 0;
            data[100] = -200;
            data[200] = -100;

            int result = MinTwoCalculator.SumTwoMinElements(data);
            Assert.Equal(-300, result);
        }

        [Fact]
        public void HandlesLargeArray_Performance()
        {
            const int n = 100_000_000;
            var data = new int[n];
            var rand = new Random(42);
            for (int i = 0; i < n; i++)
                data[i] = rand.Next();

            var watch = System.Diagnostics.Stopwatch.StartNew();
            int result = MinTwoCalculator.SumTwoMinElements(data);
            watch.Stop();

            Assert.True(watch.ElapsedMilliseconds < 2000);
            Assert.IsType<int>(result);
        }
    }
}