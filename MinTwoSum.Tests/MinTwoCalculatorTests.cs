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
        public void HandlesLargeArray_Performance()
        {
            int n = 100_000_000;
            var data = new int[n];
            var rand = new Random(42);
            for (int i = 0; i < n; i++) data[i] = rand.Next();

            var watch = System.Diagnostics.Stopwatch.StartNew();
            int result = MinTwoCalculator.SumTwoMinElements(data);
            watch.Stop();

            Assert.True(watch.ElapsedMilliseconds < 2000);
            Assert.IsType<int>(result);
        }
    }
}