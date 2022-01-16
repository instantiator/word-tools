using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using WordToolsCmdlet.DTO;

namespace WordToolsCmdlet
{
    [Cmdlet(VerbsData.Import, "Words")]
    [OutputType(typeof(IWord))]
    public class ImportWordsCommand : AbstractCommandWithWordList
    {
        [Parameter(ValueFromPipeline = true)]
        public IWord Word { get; set; }

        protected override void ProcessRecord()
        {
            WriteObject(Word);
        }

        protected override void EndProcessing()
        {
            WriteObject(wordlist.Values, true);
        }
    }
}