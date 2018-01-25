using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AnagramExperiment
{
    public class AnagramDictionary
    {
        private readonly ConcurrentDictionary<string, List<string>> _anagrams;

        public AnagramDictionary(string path)
        {
            ValidatePath(path);

            _anagrams = new ConcurrentDictionary<string, List<string>>();

            FillDictionary(path);
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

        public List<string> LookUpWord(string word)
        {
            var sortedWord = SortByCharacters(word);

            _anagrams.TryGetValue(sortedWord, out var result);
            result = result?.Where(anagram => !anagram.Equals(word)).ToList();

            return result ?? new List<string>();
        }

        private static string SortByCharacters(string word)
        {
            var res = word.ToLowerInvariant().ToCharArray();
            Array.Sort(res);
            return new string(res);
        }

        private static void ValidatePath(string path)
        {
            if (!new FileInfo(path).Exists) throw new FileNotFoundException("File not found.");
        }

        private void FillDictionary(string path)
        {
            var parallelTaskCount = Environment.ProcessorCount;
            var taskFactory = new TaskFactory(TaskCreationOptions.LongRunning, TaskContinuationOptions.None);

            for (var i = 0; i < parallelTaskCount; i++)
                taskFactory.StartNew(() => { Parallel.ForEach(File.ReadLines(path), Add); });
        }
    }
}