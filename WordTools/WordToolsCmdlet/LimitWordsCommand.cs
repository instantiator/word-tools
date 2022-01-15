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
        public string RegularExpression { get; set; }

        [Parameter(ValueFromPipeline = true)]
        public Word Word { get; set; }

        protected override void ProcessRecord()
        {
            var word = Word.Text?.ToLower().Trim();
            var crossword = Crossword?.ToLower().Trim();

            if ((Length == null || MatchesLength(Word, Length.Value)) &&
                (Crossword == null || MatchesCrossword(Word, Crossword)) &&
                (RegularExpression == null || MatchesRegex(Word, RegularExpression)))
            {
                WriteObject(Word);
            }
        }

        public bool MatchesLength(Word word, int length)
        {
            return length == word?.Text?.Length;
        }

        public bool MatchesCrossword(Word word, string crossword)
        {
            if (string.IsNullOrWhiteSpace(crossword)) { return false; }
            if (word.Text.Length != crossword.Length) { return false; }
            for (var i = 0; i < word.Text.Length; i++)
            {
                if (word.Text[i] != crossword[i] && crossword[i] != '?') { return false; }
            }
            return true;
        }

        public bool MatchesRegex(Word word, string regex)
        {
            if (string.IsNullOrWhiteSpace(regex)) { return false; }
            Regex r = new Regex(regex);
            return r.IsMatch(word?.Text);
        }
    }
}
