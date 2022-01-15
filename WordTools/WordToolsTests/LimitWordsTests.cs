using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordToolsCmdlet;

namespace WordToolsTests
{
    [TestClass]
    public class LimitWordsTests
    {
        private LimitWordsCommand command;

        [TestInitialize]
        public void Init()
        {
            command = new LimitWordsCommand();
        }

        [TestMethod]
        public void TestAnagramMatching()
        {
            Assert.IsTrue(command.MatchesAnagram("abcdefg", "gfedcba"));

            Assert.IsFalse(command.MatchesAnagram("abcdefg", "gfedxxx"));
            Assert.IsFalse(command.MatchesAnagram("abcdefg", "abc"));

            Assert.IsTrue(command.MatchesAnagram("abcdefg", "abcdef?"));
            Assert.IsTrue(command.MatchesAnagram("abcdefg", "gfedcb?"));
            Assert.IsTrue(command.MatchesAnagram("abcdefg", "g??????"));

            Assert.IsFalse(command.MatchesAnagram("abcdefg", "abcdex?"));
            Assert.IsFalse(command.MatchesAnagram("abcdefg", "gfedcx?"));
            Assert.IsFalse(command.MatchesAnagram("abcdefg", "abc?"));

            Assert.IsTrue(command.MatchesAnagram("clever", "rcleve"));
            Assert.IsTrue(command.MatchesAnagram("clever", "rclev?"));
            Assert.IsFalse(command.MatchesAnagram("clever", "zer"));
            Assert.IsFalse(command.MatchesAnagram("clever", "well"));
        }
    }
}
