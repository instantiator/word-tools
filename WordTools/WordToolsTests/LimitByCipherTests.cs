using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordToolsCmdlet;

namespace WordToolsTests
{
    [TestClass]
    public class LimitByCipherTests
    {
        [TestMethod]
        public void TestCaesarMatching()
        {
            Assert.AreEqual(25, LimitByCipherCommand.MatchesWithCaesar("abcdef","bcdefg",null));
            Assert.AreEqual(24, LimitByCipherCommand.MatchesWithCaesar("abcdef", "cdefgh", null));
            Assert.AreEqual(24, LimitByCipherCommand.MatchesWithCaesar("abcdef", "cdefgh", 24));

            Assert.IsNull(LimitByCipherCommand.MatchesWithCaesar("abcdef", "abcdex", null));
            Assert.IsNull(LimitByCipherCommand.MatchesWithCaesar("abcdef", "abcdex", null));


        }
    }
}
