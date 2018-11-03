using System;
using System.Diagnostics;

namespace AnagramExperiment
{
   /// <inheritdoc />
   public class Profiler : IDisposable
   {
      private bool _disposed;
      private long _elapsed;
      private Stopwatch _stopWatch;

      public Profiler() : this("Untitled")
      {
      }

      public Profiler(string title)
      {
         Console.WriteLine(title);
         _stopWatch = new Stopwatch();
         _stopWatch.Start();
         _elapsed = 0;
      }

      public void Dispose()
      {
         Dispose(true);
         GC.SuppressFinalize(this);
      }

      public void Print(string comment)
      {
         if (_disposed) throw new ObjectDisposedException(GetType().Name);
         _elapsed += _stopWatch.ElapsedMilliseconds;
         Console.WriteLine("  {0,-30} {1,10} ms", Crop(comment, 30), _stopWatch.ElapsedMilliseconds);
         _stopWatch.Restart();
      }

      protected virtual void Dispose(bool disposing)
      {
         if (_disposed) return;

         _stopWatch.Stop();
         _elapsed += _stopWatch.ElapsedMilliseconds;

         Console.WriteLine("{0,-30}   {1,10} ms", "Total", _elapsed);
         _stopWatch = null;

         _disposed = true;
      }

      private static string Crop(string input, int length)
      {
         if (input.Length > length)
            return input.Substring(0, length - 3) + "...";
         return input;
      }
   }
}