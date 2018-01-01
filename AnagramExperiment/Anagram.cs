using System;
using System.Diagnostics;
using System.Linq;
using BenchmarkDotNet.Running;

namespace AnagramExperiment
{
    public static class Anagram
    {
        public static void Main(string[] args)
        {
            //if (args == null || !args.Any()) ShowHelpText();

            //// ReSharper disable once PossibleNullReferenceException
            //var path = args[0];
            //var word = args[1];

            //var path = @"..\..\..\AnagramExperimentTest\Sample.txt";
            //var word = "sample";

            //var stopwatch = new Stopwatch();

            //Console.Write("Creating Anagram Dictionary...\t");
            //stopwatch.Start();
            //var dictionary = new AnagramExperiment.AnagramDictionary(path);
            //stopwatch.Stop();
            //Console.WriteLine($"{stopwatch.ElapsedMilliseconds} ms");

            //Console.Write($"Looking up anagrams of '{word}'...\t");
            //stopwatch.Restart();
            //var anagrams = dictionary.LookUpWord(word);
            //stopwatch.Stop();
            //Console.WriteLine($"{stopwatch.ElapsedMilliseconds} ms");

            //foreach (var anagram in anagrams)
            //    Console.WriteLine(anagram);

            //Console.WriteLine("Press any key to exit.");
            //Console.ReadKey();

            BenchmarkRunner.Run<Benchmarker>();
        }

        private static void ShowHelpText()
        {
            Console.WriteLine("Syntax:");
            Console.WriteLine("AnagramExperiment <path> <word>");
            Environment.Exit(0);
        }
    }
}