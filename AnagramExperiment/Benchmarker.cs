using BenchmarkDotNet.Attributes;

namespace AnagramExperiment
{
    public class Benchmarker
    {
        string path = @"..\..\..\AnagramExperimentTest\Sample.txt";
        string word = "sample";

        [Benchmark]
        public void SequentialDictionary()
        {
            var dictionary = new AnagramDictionary(path);
            dictionary.LookUpWord(word);
        }

        [Benchmark]
        public void ParallelDictionary()
        {
            var dictionary = new AnagramDictionaryParallel(path);
            dictionary.LookUpWord(word);
        }
    }
}
