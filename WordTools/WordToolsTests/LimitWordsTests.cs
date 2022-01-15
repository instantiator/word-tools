using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordToolsCmdlet;

namespace WordToolsTests
{
    [TestClass]
    public class LimitWordsTests
    {
        [TestMethod]
        public void TestAnagramMatching()
        {
            Assert.IsTrue(LimitWordsCommand.MatchesAnagram("abcdefg", "gfedcba"));

            Assert.IsFalse(LimitWordsCommand.MatchesAnagram("abcdefg", "gfedxxx"));
            Assert.IsFalse(LimitWordsCommand.MatchesAnagram("abcdefg", "abc"));

            Assert.IsTrue(LimitWordsCommand.MatchesAnagram("abcdefg", "abcdef?"));
            Assert.IsTrue(LimitWordsCommand.MatchesAnagram("abcdefg", "gfedcb?"));
            Assert.IsTrue(LimitWordsCommand.MatchesAnagram("abcdefg", "g??????"));

            Assert.IsFalse(LimitWordsCommand.MatchesAnagram("abcdefg", "abcdex?"));
            Assert.IsFalse(LimitWordsCommand.MatchesAnagram("abcdefg", "gfedcx?"));
            Assert.IsFalse(LimitWordsCommand.MatchesAnagram("abcdefg", "abc?"));

            Assert.IsTrue(LimitWordsCommand.MatchesAnagram("clever", "rcleve"));
            Assert.IsTrue(LimitWordsCommand.MatchesAnagram("clever", "rclev?"));
            Assert.IsFalse(LimitWordsCommand.MatchesAnagram("clever", "zer"));
            Assert.IsFalse(LimitWordsCommand.MatchesAnagram("clever", "well"));
        }
    }
}
