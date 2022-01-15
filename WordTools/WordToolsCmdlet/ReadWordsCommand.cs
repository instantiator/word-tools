using System.Collections.Generic;
using System.IO;
using System.Management.Automation;
using WordToolsCmdlet.DTO;

namespace WordToolsCmdlet
{
    [Cmdlet(VerbsCommunications.Read, "Words")]
    [OutputType(typeof(IWord))]
    public class ReadWordsCommand : Cmdlet
    {
        [Parameter(Mandatory = true)]
        public string Path { get; set; }

        protected override void ProcessRecord()
        {
            foreach (string line in File.ReadLines(Path))
            {
                WriteObject(new SimpleWord(line.Trim()));
            }
        }
    }
}