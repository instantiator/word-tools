using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordToolsCmdlet;
using WordToolsCmdlet.Helpers;

namespace WordToolsTests
{
    [TestClass]
    public class LimitWordsTests
    {
        [TestMethod]
        public void TestAnagramMatching()
        {
            Assert.IsTrue(WordHelper.MatchesAnagram("abcdefg", "gfedcba"));

            Assert.IsFalse(WordHelper.MatchesAnagram("abcdefg", "gfedxxx"));
            Assert.IsFalse(WordHelper.MatchesAnagram("abcdefg", "abc"));

            Assert.IsTrue(WordHelper.MatchesAnagram("abcdefg", "abcdef?"));
            Assert.IsTrue(WordHelper.MatchesAnagram("abcdefg", "gfedcb?"));
            Assert.IsTrue(WordHelper.MatchesAnagram("abcdefg", "g??????"));

            Assert.IsFalse(WordHelper.MatchesAnagram("abcdefg", "abcdex?"));
            Assert.IsFalse(WordHelper.MatchesAnagram("abcdefg", "gfedcx?"));
            Assert.IsFalse(WordHelper.MatchesAnagram("abcdefg", "abc?"));

            Assert.IsTrue(WordHelper.MatchesAnagram("clever", "rcleve"));
            Assert.IsTrue(WordHelper.MatchesAnagram("clever", "rclev?"));
            Assert.IsFalse(WordHelper.MatchesAnagram("clever", "zer"));
            Assert.IsFalse(WordHelper.MatchesAnagram("clever", "well"));
        }
    }
}
