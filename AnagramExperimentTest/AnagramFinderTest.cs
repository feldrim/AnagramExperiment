using System;
using System.Collections.Generic;
using AnagramExperiment;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AnagramExperimentTest
{
    [TestClass]
    public class AnagramFinderTest
    {
        public AnagramDictionary TestDictionary;
        public AnagramFinder AnagramFinderTestInstance;

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
