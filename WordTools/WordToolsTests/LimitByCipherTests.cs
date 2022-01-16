using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordToolsCmdlet;
using WordToolsCmdlet.DTO;
using WordToolsCmdlet.Helpers;

namespace WordToolsTests
{
    [TestClass]
    public class LimitByCipherTests
    {
        [TestMethod]
        public void TestCaesarMatching()
        {
            var wordlist = new Dictionary<string, IWord>() { { "abcdef", new SimpleWord("abcdef") } };

            Assert.IsNotNull(CipherHelper.FindCaesarMatch(wordlist,"bcdefg",null).Select(dc => dc.Options as CaesarAlgorithmOptions).Single(opt => opt.Rotation == 25));
            Assert.IsNotNull(CipherHelper.FindCaesarMatch(wordlist, "cdefgh", null).Select(dc => dc.Options as CaesarAlgorithmOptions).Single(opt => opt.Rotation == 24));
            Assert.IsNotNull(CipherHelper.FindCaesarMatch(wordlist, "cdefgh", 24).Select(dc => dc.Options as CaesarAlgorithmOptions).Single(opt => opt.Rotation == 24));

            Assert.AreEqual(0, CipherHelper.FindCaesarMatch(wordlist, "abcdex", null).Count());
            Assert.AreEqual(0, CipherHelper.FindCaesarMatch(wordlist, "abcdex", null).Count());
        }
    }
}
