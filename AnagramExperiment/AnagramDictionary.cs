﻿using System;
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
                {
                    Add(fileStream.ReadLine());
                }
            }
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
                _anagrams.Add(sortedWord, new List<string> { word });
        }

        public List<string> LookUpWord(string word, bool includeItself = false)
        {
            var sortedWord = SortByCharacters(word);

            if (_anagrams.ContainsKey(sortedWord))
            {
                return includeItself ? _anagrams[sortedWord] : _anagrams[sortedWord].Where(anagram => !anagram.Equals(word)).ToList();
            }
            throw new Exception("Word not found.");
        }

        private static string SortByCharacters(string word)
        {
            return string.Concat(word.ToLowerInvariant().ToCharArray().OrderBy(c => c));
        }
    }
}