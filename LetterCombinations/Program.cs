using System;
using System.Linq;

namespace LetterCombinations
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Ooooops!! CAN NOT detected the argument.");
                return;
            }

            var combinations = Letter.GetCombinations(args[0]);

            Console.WriteLine($"Inputed arguments: {args[0]}");
            Console.WriteLine($"Letter combinations (total: {combinations?.Count()}): {Environment.NewLine}{string.Join(", ", combinations)}");
        }
    }
}
