using System;
using Xunit;
using MinTwoSum;

namespace MinTwoSum.Tests
{
    public class MinTwoCalculatorTests
    {
        [Fact]
        public void SumTwoMinElements_WithTypicalArray_ReturnsSumOfTwoSmallest()
        {
            // Arrange
            int[] data = { 4, 0, 3, 19, 492, -10, 1 };

            // Act
            int result = MinTwoCalculator.SumTwoMinElements(data);

            // Assert
            Assert.Equal(-10, result);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(new int[0])]
        [InlineData(new[] { 5 })]
        public void SumTwoMinElements_WithInsufficientElements_ThrowsArgumentException(int[]? data)
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(
                () => MinTwoCalculator.SumTwoMinElements(data));
        }

        [Fact]
        public void SumTwoMinElements_WithExactlyTwoElements_ReturnsTheirSum()
        {
            // Arrange
            int[] data = { -3, 7 };

            // Act
            int result = MinTwoCalculator.SumTwoMinElements(data);

            // Assert
            Assert.Equal(4, result);
        }

        [Fact]
        public void SumTwoMinElements_WhenSumOverflows_ThrowsOverflowException()
        {
            // Arrange
            int[] data = { int.MaxValue, 1 };

            // Act & Assert
            Assert.Throws<OverflowException>(
                () => MinTwoCalculator.SumTwoMinElements(data));
        }

        [Fact]
        public void SumTwoMinElements_LargeArray_ReturnsCorrectSum()
        {
            // Arrange
            const int n = 100_000_000;
            var data = new int[n];
            for (int i = 0; i < n; i++)
                data[i] = 0;
            data[100] = -200;
            data[200] = -100;

            // Act
            int result = MinTwoCalculator.SumTwoMinElements(data);

            // Assert
            Assert.Equal(-300, result);
        }

        [Fact]
        public void SumTwoMinElements_LargeArray_ExecutesWithinPerformanceBudget()
        {
            // Arrange
            const int n = 100_000_000;
            var data = new int[n];
            var rand = new Random(42);
            for (int i = 0; i < n; i++)
                data[i] = rand.Next();
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();

            // Act
            MinTwoCalculator.SumTwoMinElements(data);
            stopwatch.Stop();

            // Assert
            Assert.True(stopwatch.ElapsedMilliseconds < 2000,
                $"Ожидалось выполнение менее чем за 2000 мс, а было {stopwatch.ElapsedMilliseconds} мс");
        }
    }
}
