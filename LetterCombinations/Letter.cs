using System.Collections.Generic;
using System.Linq;

namespace LetterCombinations
{
    public static class Letter
    {
        // Defined the number path map form 0 - 9.
        private static readonly Dictionary<char, string> LetterMap = new Dictionary<char, string>
        {
            ['0'] = "0",
            ['1'] = "1",
            ['2'] = "abc",
            ['3'] = "def",
            ['4'] = "ghi",
            ['5'] = "jkl",
            ['6'] = "mno",
            ['7'] = "pqrs",
            ['8'] = "tuv",
            ['9'] = "wxyz"
        };

        public static IEnumerable<string> GetCombinations(string numbers)
        {
            // Filter for integer number.
            var numberList = numbers.Where(num => int.TryParse($"{num}", out int integer));
            
            // combinations.count = 1^x * 3^y * 4^z
            // numbers.count = x + y + z
            // 1: '0', '1'
            // 3: '2', '3', '4', '5', '6', '8'
            // 4: '7', '9'
            return Expand(numberList).Select(result => new string (result.ToArray()));
        }

        private static IEnumerable<IEnumerable<char>> Expand(IEnumerable<char> numbers)
        {
            var numberList = numbers?.ToList();
            if (!numberList?.Any() == true)
            {
                yield return Enumerable.Empty<char>();
                yield break;
            }

            var characters = LetterMap[numberList[0]];
            foreach (var character in characters)
            {
                foreach (var letter in Expand(numberList.Skip(1).ToList()))
                {
                    yield return letter.Prepend(character);
                }
            }
        }
    }
}