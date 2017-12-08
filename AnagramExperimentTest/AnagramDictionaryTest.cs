using System;
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
        public void ShouldReturnEmptyListIfNoResultFound()
        {
            var result = TestDictionary.LookUpWord("sample", true);

            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void EmitsMustHaveTwoAnagramsIncludingItself()
        {
            var anagrams = TestDictionary.LookUpWord("emits", true);

            Assert.AreEqual(2, anagrams.Count);
        }

        [TestMethod]
        public void EmitsMustHaveOneAnagram()
        {
            var anagrams = TestDictionary.LookUpWord("emits");

            Assert.AreEqual(1, anagrams.Count);
        }
    }
}
