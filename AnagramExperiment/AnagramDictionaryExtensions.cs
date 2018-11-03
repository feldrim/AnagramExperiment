using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnagramExperiment
{
   public static class AnagramDictionaryExtensions
   {
      public static AnagramDictionary WithFile(this AnagramDictionary anagramDictionary, string path)
      {
         ValidatePath(path);
         var taskFactory = new TaskFactory(TaskCreationOptions.LongRunning, TaskContinuationOptions.None);
         var readTask = taskFactory.StartNew(() =>
            Parallel.ForEach(File.ReadLines(path, Encoding.UTF8).AsParallel(),
               anagramDictionary.AddToWordList));
         Task.WaitAll(readTask);
         anagramDictionary.CompleteWordList();

         var fillTask = taskFactory.StartNew(() =>
            Parallel.ForEach(anagramDictionary.GetWordList(), anagramDictionary.AddToDictionary));
         Task.WaitAll(fillTask);

         return anagramDictionary;
      }

      private static void ValidatePath(string path)
      {
         var exist = new FileInfo(path).Exists ? true : throw new FileNotFoundException("File not found.");
      }
   }
}