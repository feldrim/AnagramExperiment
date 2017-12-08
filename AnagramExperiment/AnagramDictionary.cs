using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AnagramExperiment
{
    public class AnagramDictionary
    {
        private readonly Dictionary<string, List<string>> _anagrams;

        public AnagramDictionary(string path)
        {
            _anagrams = new Dictionary<string, List<string>>();

            using (var fileStream = new FileInfo(path).OpenText())
            {
                while (!fileStream.EndOfStream)
                    Add(fileStream.ReadLine());
            }

            // Added for demonstration of the overload Add method
            //Add(File.ReadAllLines(path));
        }

        public void Add(string word)
        {
            var sortedWord = SortByCharacters(word);

            if (_anagrams.ContainsKey(sortedWord))
            {
                if (!_anagrams[sortedWord].Contains(word))
                    _anagrams[sortedWord].Add(word);
            }

            else
            {
                _anagrams.Add(sortedWord, new List<string> {word});
            }
        }

        public void Add(string[] words)
        {
            foreach (var word in words)
                Add(word);
        }

        public List<string> LookUpWord(string word, bool includeItself = false)
        {
            var sortedWord = SortByCharacters(word.ToLowerInvariant());
            
            List<string> result;
            if (includeItself)
            {
                _anagrams.TryGetValue(sortedWord, out result);
            }
            else
            {
                _anagrams.TryGetValue(sortedWord, out result);
                result = result?.Where(anagram => !anagram.Equals(word)).ToList();
            }
            return result?? new List<string>();
        }

        private static string SortByCharacters(string word)
        {
            return string.Concat(word.ToLowerInvariant().OrderBy(c => c));
        }
    }
}
