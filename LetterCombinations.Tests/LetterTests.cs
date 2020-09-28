using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xunit;

namespace LetterCombinations.Tests
{
    public class LetterTests
    {
        [Fact]
        public void ExpandTest_PathNotFound()
        {
            var input = "Hello, World!";

            var privateExpand = typeof(Letter).GetMethod("Expand", BindingFlags.NonPublic | BindingFlags.Static);
            object[] parameters = { input };
            Assert.Throws<KeyNotFoundException>(() => ((IEnumerable<IEnumerable<char>>)privateExpand.Invoke(typeof(Letter), parameters)).Any());
        }

        [Theory]
        [InlineData("Hello, World!")]
        [InlineData("!@#$%^")]
        public void GetCombinations_PathNotFound(string input)
        {
            var result = Letter.GetCombinations(input);
            Assert.Empty(result.Single());
        }

        [Theory]
        [InlineData("0")]
        [InlineData("1")]
        public void SingleNumber_1(string input)
        {
            var result = Letter.GetCombinations(input);
            Assert.Equal(1, result.Count());
        }

        [Theory]
        [InlineData("2")]
        [InlineData("3")]
        [InlineData("4")]
        [InlineData("5")]
        [InlineData("6")]
        [InlineData("8")]
        public void SingleNumber_3(string input)
        {
            var result = Letter.GetCombinations(input);
            Assert.Equal(3, result.Count());
        }

        [Theory]
        [InlineData("7")]
        [InlineData("9")]
        public void SingleNumber_4(string input)
        {
            var result = Letter.GetCombinations(input);
            Assert.Equal(4, result.Count());
        }

        [Theory]
        [InlineData("2,3", 0, 2, 0)]
        [InlineData("7,9", 0, 0, 2)]
        [InlineData("23,79", 0, 2, 2)]
        [InlineData("12,23,89", 1, 4, 1)]
        [InlineData("5,81,70,99", 2, 2, 3)]
        [InlineData("0,1,2,3,4,5,6,7,8,9,10,12,17,19,99,00", 9, 7, 6)]
        public void MultiNumbers_1(string input, int map1, int map3, int map4)
        {
            var result = Letter.GetCombinations(input);
            Assert.Equal(Math.Pow(1, map1) * Math.Pow(3, map3) * Math.Pow(4, map4), result.Count());
        }
    }
}
