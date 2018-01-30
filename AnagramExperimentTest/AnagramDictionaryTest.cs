using System.IO;
using AnagramExperiment;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AnagramExperimentTest
{
    [TestClass]
    public class AnagramDictionaryTest
    {
        public AnagramDictionary TestDictionary;

        [TestInitialize]
        public void Initialize()
        {
            TestDictionary = new AnagramDictionary(@"..\..\Sample.txt");
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException), "File not found.")]
        public void ShouldThrowExceptionWhenFileNotFound()
        {
            var dummy = new AnagramDictionary(@"IncorrectPath.txt");
        }

        [TestMethod]
        public void ShouldReturnWordCountCorrect()
        {
            var count = TestDictionary.GetWordCount();

            Assert.AreEqual(83, count);
        }

        [TestMethod]
        public void ShouldReturnDictionaryCountCorrect()
        {
            var count = TestDictionary.GetDictionaryCount();

            Assert.AreEqual(82, count);
        }

        [TestMethod]
        public void ShouldReturnEmptyListIfNoResultFound()
        {
            var anagrams = TestDictionary.LookUpWord("sample");

            Assert.AreEqual(0, anagrams.Count);
        }

        [TestMethod]
        public void EmitsMustHaveOneAnagram()
        {
            var anagrams = TestDictionary.LookUpWord("emits");

            Assert.AreEqual(1, anagrams.Count);
        }
    }
}