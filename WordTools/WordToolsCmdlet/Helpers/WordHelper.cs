using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordToolsCmdlet.Helpers
{
    public class WordHelper
    {
        public static bool MatchesLength(string word, int length)
        {
            return length == word?.Length;
        }

        public static bool MatchesCrossword(string word, string crossword)
        {
            if (string.IsNullOrWhiteSpace(crossword)) { return false; }
            if (word.Length != crossword.Length) { return false; }
            for (var i = 0; i < word.Length; i++)
            {
                if (word[i] != crossword[i] && crossword[i] != '?') { return false; }
            }
            return true;
        }

        public static bool MatchesRegex(string word, string regex)
        {
            if (string.IsNullOrWhiteSpace(regex)) { return false; }
            var r = new Regex(regex);
            return r.IsMatch(word);
        }

        public static bool MatchesAnagram(string word, string anagram)
        {
            if (string.IsNullOrWhiteSpace(anagram)) { return false; }
            if (word.Length != anagram.Length) { return false; }

            var wordChars = word.ToList();
            var anagChars = anagram.ToList();

            int matched = anagChars.Count(c => c == '?');
            foreach (var c in wordChars)
            {
                if (anagChars.Contains(c))
                {
                    anagChars.RemoveAt(anagChars.IndexOf(c));
                    matched++;
                }
            }
            return matched == word.Length;
        }

        public static bool Contains(string word, string str)
        {
            if (string.IsNullOrWhiteSpace(str)) { return false; }
            return word.Contains(str);
        }

        public static bool IsPalindrome(string word)
        {
            return word.SequenceEqual(word.Reverse());
        }
    }
}
