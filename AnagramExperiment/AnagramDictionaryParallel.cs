using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AnagramExperiment
{
    public class AnagramDictionaryParallel
    {
        private readonly ConcurrentDictionary<string, List<string>> _anagrams;

        public AnagramDictionaryParallel(string path)
        {
            ValidatePath(path);
            
            _anagrams = new ConcurrentDictionary<string, List<string>>();

            Parallel.ForEach(File.ReadLines(path), Add);
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
                _anagrams.TryAdd(sortedWord, new List<string> {word});
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
        
        private static void ValidatePath(string path)
        {
            if (!new FileInfo(path).Exists) throw new FileNotFoundException("File not found.");
        }
    }
}
