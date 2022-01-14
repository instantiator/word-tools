using System.Collections.Generic;
using System.Management.Automation;

namespace WordToolsCmdlet
{
    [Cmdlet(VerbsCommunications.Read, "Dictionary")]
    [OutputType(typeof(Word))]
    public class ReadWordsCommand : Cmdlet
    {
        [Parameter(Mandatory = true)]
        public string Path { get; set; }

        protected override void ProcessRecord()
        {
            var dictionary = new[]
            {
                Word.JustText("aardvark"),
                Word.JustText("abacus"),
            };

            WriteObject(dictionary, true);
        }
    }
}