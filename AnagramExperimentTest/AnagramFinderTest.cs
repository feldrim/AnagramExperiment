using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AnagramExperimentTest
{
    [TestClass]
    public class AnagramFinderTest
    {
        public AnagramExperiment.AnagramDictionary TestDictionary;
        public AnagramExperiment.AnagramFinder AnagramFinderTestInstance;

        [TestInitialize]
        public void Initialize()
        {
            TestDictionary = new AnagramDictionary();
            TestDictionary.Add("eimst", new List<string> {"emits", "smite"});

            AnagramFinderTestInstance = new AnagramFinder();

        }

        [TestMethod]
        public void EmitsMustHaveTwoAnagramsIncludingItself()
        {
            var anagrams = AnagramFinderTestInstance.FindAnagram(TestDictionary, "emits");

            Assert.AreEqual(2, anagrams.Count());
        }
    }
}
