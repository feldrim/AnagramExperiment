using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace AnagramExperiment
{
   public class AnagramDictionary
   {
      private readonly ConcurrentDictionary<string, HashSet<string>> _anagramDictionary;
      private readonly BlockingCollection<string> _inMemoryWordList;

      private AnagramDictionary()
      {
         _anagramDictionary = new ConcurrentDictionary<string, HashSet<string>>();
         _inMemoryWordList = new BlockingCollection<string>();
      }

      public static AnagramDictionary Create() => new AnagramDictionary();

      public void AddToDictionary(string word)
      {
         var sortedWord = SortByCharacters(word);

         if (_anagramDictionary.ContainsKey(sortedWord))
            _anagramDictionary[sortedWord].Add(word);
         else
            _anagramDictionary[sortedWord] = new HashSet<string> { word };
      }

      protected internal void AddToWordList(string word)
      {
         _inMemoryWordList.Add(word);
      }

      protected internal void CompleteWordList()
      {
         _inMemoryWordList.CompleteAdding();
      }

      protected internal IEnumerable<string> GetWordList()
      {
         return new ReadOnlyCollection<string>(_inMemoryWordList.ToList());
      }

      public HashSet<string> LookUpWord(string word)
      {
         var sortedWord = SortByCharacters(word);

         _anagramDictionary.TryGetValue(sortedWord, out var result);
         result?.Remove(word);

         return result ?? new HashSet<string>();
      }

      public int GetDictionaryCount() => _anagramDictionary.Count;

      public int GetWordCount() => _inMemoryWordList.Count;

      private static string SortByCharacters(string word)
      {
         var res = word.ToLowerInvariant().ToCharArray();
         Array.Sort(res);
         return new string(res);
      }
   }
}