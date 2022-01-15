using System;
using System.Linq;
using System.Management.Automation;
using System.Text.RegularExpressions;

namespace WordToolsCmdlet
{
    [Cmdlet(VerbsData.Limit, "Words")]
    [OutputType(typeof(Word))]
    public class LimitWordsCommand : Cmdlet
    {
        [Parameter]
        public int? Length { get; set; }

        [Parameter]
        public string Crossword { get; set; }

        [Parameter]
        public string Regex { get; set; }

        [Parameter]
        public string Contains { get; set; }

        [Parameter]
        public string Anagram { get; set; }

        [Parameter(ValueFromPipeline = true)]
        public Word Word { get; set; }

        protected override void ProcessRecord()
        {
            var word = Word.Text?.ToLower().Trim();
            var crossword = Crossword?.ToLower().Trim();
            var contains = Contains?.ToLower().Trim();
            var anagram = Anagram?.ToLower().Trim();

            if ((Word != null && Word.Text != null) &&
                (Length == null || MatchesLength(word, Length.Value)) &&
                (Crossword == null || MatchesCrossword(word, crossword)) &&
                (Regex == null || MatchesRegex(word, Regex)) &&
                (Contains == null || DoesContain(word, contains)) &&
                (Anagram == null || MatchesAnagram(word, anagram)))
            {
                WriteObject(Word);
            }
        }

        public bool MatchesLength(string word, int length)
        {
            return length == word?.Length;
        }

        public bool MatchesCrossword(string word, string crossword)
        {
            if (string.IsNullOrWhiteSpace(crossword)) { return false; }
            if (word.Length != crossword.Length) { return false; }
            for (var i = 0; i < word.Length; i++)
            {
                if (word[i] != crossword[i] && crossword[i] != '?') { return false; }
            }
            return true;
        }

        public bool MatchesRegex(string word, string regex)
        {
            if (string.IsNullOrWhiteSpace(regex)) { return false; }
            var r = new Regex(regex);
            return r.IsMatch(word);
        }

        public bool MatchesAnagram(string word, string anagram)
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

        public bool DoesContain(string word, string str)
        {
            if (string.IsNullOrWhiteSpace(str)) { return false; }
            return word.Contains(str);
        }
    }
}
