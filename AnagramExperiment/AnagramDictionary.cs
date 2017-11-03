using System;
using System.Collections.Generic;
using System.Linq;

namespace AnagramExperiment
{
    public class AnagramDictionary
    {
        protected internal readonly Dictionary<string, List<string>> Anagrams;

        public AnagramDictionary()
        {
            Anagrams = new Dictionary<string, List<string>>();
        }

        public void Add(string word)
        {
            var sortedWord = SortByCharacters(word);

            if (Anagrams.ContainsKey(sortedWord))
                Anagrams[sortedWord].Add(word);
            else
                Anagrams.Add(sortedWord, new List<string> { word });
        }

        public List<string> LookUpWord(string word, bool includeItself = false)
        {
            var sortedWord = SortByCharacters(word);

            if (Anagrams.ContainsKey(sortedWord))
            {
                return includeItself ? Anagrams[sortedWord] : Anagrams[sortedWord].Where(anagram => !anagram.Equals(word)).ToList();
            }
            throw new Exception("Word not found.");
        }

        private static string SortByCharacters(string word)
        {
            return string.Concat(word.ToLowerInvariant().ToCharArray().OrderBy(c => c));
        }
    }
}