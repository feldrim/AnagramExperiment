using System;
using System.Diagnostics;
using System.Linq;

namespace AnagramExperiment
{
    internal class Anagram
    {
        private static void Main(string[] args)
        {
            // Commented out for test reasons
            //if (args == null || !args.Any()) ShowHelpText();
            //var path = args[0];
            //var word = args[1];

            const string path = @"..\..\..\AnagramExperiment\Data\lemmad.txt";
            const string word = "emits";
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

            foreach (var anagram in anagrams)
                Console.WriteLine(anagram);

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        private static void ShowHelpText()
        {
            Console.WriteLine("Syntax:");
            Console.WriteLine("AnagramExperiment <path> <word>");
        }
    }
}