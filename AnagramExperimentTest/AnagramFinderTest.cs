using AnagramExperiment;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AnagramExperimentTest
{
    [TestClass]
    public class AnagramFinderTest
    {
        public AnagramDictionary TestDictionary;

        [TestInitialize]
        public void Initialize()
        {
            TestDictionary = new AnagramDictionary();
            TestDictionary.Add("emits");
            TestDictionary.Add("smite");
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
            var anagrams = TestDictionary.LookUpWord("emits", false);

            Assert.AreEqual(1, anagrams.Count);
        }
    }
}
