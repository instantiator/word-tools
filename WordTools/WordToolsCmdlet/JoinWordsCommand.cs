using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Combinatorics.Collections;
using WordToolsCmdlet.DTO;

namespace WordToolsCmdlet
{
    [Cmdlet(VerbsCommon.Join, "Words")]
    [OutputType(typeof(IPhrase))]
    public class JoinWordsCommand : Cmdlet
    {
        protected List<IWord> words;

        [Parameter(ValueFromPipeline = true)]
        public IWord Word { get; set; }

        protected override void BeginProcessing()
        {
            words = new List<IWord>();
        }

        protected override void ProcessRecord()
        {
            if (Word != null && !string.IsNullOrWhiteSpace(Word.Text))
            {
                words.Add(Word);
            }
        }

        protected override void EndProcessing()
        {
            var phrases = new List<IPhrase>();
            var permutations = Permutations(words).Select(p => SimplePhrase.From(p));
            WriteObject(permutations, true);
        }

        public static IEnumerable<IEnumerable<T>> Permutations<T>(IEnumerable<T> items)
        {
            var permutations = new Permutations<T>(items);
            return permutations.ToList();
        }
    }
}
