using System;
using System.Management.Automation;

namespace WordToolsCmdlet
{
    [Cmdlet(VerbsData.Limit, "Dictionary")]
    [OutputType(typeof(Word))]
    public class LimitDictionaryCommand : Cmdlet
    {
        [Parameter(Mandatory = true)]
        public string Rule { get; set; }

        [Parameter(ValueFromPipeline = true)]
        public Word Word { get; set; }

        protected override void ProcessRecord()
        {
            if (MatchesRule(Rule, Word))
            {
                WriteObject(Word);
            }
        }

        public bool MatchesRule(string rule, Word word)
        {
            int len = int.Parse(rule);
            return len == word?.Text?.Length;
        }
    }
}
