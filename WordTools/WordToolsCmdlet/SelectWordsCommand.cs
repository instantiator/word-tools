using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Text.RegularExpressions;
using WordToolsCmdlet.DTO;
using WordToolsCmdlet.Helpers;

namespace WordToolsCmdlet
{
    [Cmdlet(VerbsCommon.Select, "Words")]
    [OutputType(typeof(IWord))]
    public class SelectWordsCommand : AbstractCommandWithWordList
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

        [Parameter]
        public bool Palindrome { get; set; }

        [Parameter(ValueFromPipeline = true)]
        public IWord Word { get; set; }

        protected override void ProcessRecord()
        {
            var word = Word?.Text.ToLower().Trim();
            var crossword = Crossword?.ToLower().Trim();
            var contains = Contains?.ToLower().Trim();
            var anagram = Anagram?.ToLower().Trim();

            if ((Word != null && Word.Text != null) &&
                (Length == null || WordHelper.MatchesLength(word, Length.Value)) &&
                (Crossword == null || WordHelper.MatchesCrossword(word, crossword)) &&
                (Regex == null || WordHelper.MatchesRegex(word, Regex)) &&
                (Contains == null || WordHelper.Contains(word, contains)) &&
                (Anagram == null || WordHelper.MatchesAnagram(word, anagram)) &&
                (!Palindrome || WordHelper.IsPalindrome(word)) &&
                (wordlist == null || wordlist.Count() == 0 || wordlist.ContainsKey(word)))
            {
                WriteObject(Word);
            }
        }
    }
}
