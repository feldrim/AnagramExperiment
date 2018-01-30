using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AnagramExperiment
{
    public static class Anagram
    {
        public static void Main(string[] args)
        {
            CheckArguments(args);

            // ReSharper disable once PossibleNullReferenceException
            var path = args[0];
            var word = args[1];

            var stopwatch = new Stopwatch();

            Console.Write("Creating Anagram Dictionary...\t");
            stopwatch.Start();
            var dictionary = new AnagramDictionary(path);
            stopwatch.Stop();
            Console.WriteLine($"{stopwatch.ElapsedMilliseconds} ms");

            Console.Write($"Looking up anagrams of '{word}'...\t");
            stopwatch.Restart();
            var anagrams = dictionary.LookUpWord(word);
            stopwatch.Stop();
            Console.WriteLine($"{stopwatch.ElapsedMilliseconds} ms");

            if (anagrams.Any())
                foreach (var anagram in anagrams)
                    Console.WriteLine($"- {anagram}");
            else
                Console.WriteLine("No anagram found.");

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        private static void CheckArguments(IReadOnlyCollection<string> arguments)
        {
            // ReSharper disable once PossibleNullReferenceException
            if (arguments != null && arguments.Count == 2) return;

            Console.WriteLine("SYNTAX:");
            Console.WriteLine("AnagramExperiment <path> <word>");
            Environment.Exit(0);
        }
    }
}