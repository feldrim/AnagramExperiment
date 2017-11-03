namespace AnagramExperiment
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var path = args[0];
            var word = args[1];

            var dictionary = new AnagramDictionary(path);
            dictionary.LookUpWord(word);
        }
    }
}