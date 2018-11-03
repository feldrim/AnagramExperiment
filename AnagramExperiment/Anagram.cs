using System;
using System.Collections.Generic;
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

           using (var profiler = new Profiler("Anagram experiment"))
           {
              var dictionary = AnagramDictionary.Create(path);
              profiler.Print("Creating anagram dictionary");
              
              var anagrams = dictionary.LookUpWord(word);
              profiler.Print($"Looking up anagrams of {word}");

              Console.WriteLine("Anagrams:");
              if (anagrams.Any())
                 foreach (var anagram in anagrams)
                    Console.WriteLine($"- {anagram}");
              else
                 Console.WriteLine("No anagram found.");
              profiler.Print("Printing anagrams");

           }

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