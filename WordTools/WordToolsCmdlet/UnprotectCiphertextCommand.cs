using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using WordToolsCmdlet.DTO;
using WordToolsCmdlet.Helpers;

namespace WordToolsCmdlet
{
    [Cmdlet(VerbsSecurity.Unprotect, "Ciphertext")]
    [OutputType(typeof(DecipheredWord))]
    public class UnprotectCiphertextCommand : AbstractCommandWithWordList
    {
        [Parameter(Mandatory = true)]
        public Algorithms Algorithm { get; set; }

        [Parameter]
        public string Key { get; set; }

        [Parameter(ValueFromPipeline = true)]
        public IWord Ciphertext { get; set; }

        protected override void ProcessRecord()
        {
            string ciphertext = Ciphertext?.Text.ToLower().Trim();
            if (ciphertext != null)
            {
                switch (Algorithm)
                {
                    case Algorithms.caesar:
                        int key; bool keyOk = int.TryParse(Key, out key);
                        var deciphered = CipherHelper.FindCaesarMatch(wordlist, ciphertext, keyOk ? key : null);
                        WriteObject(deciphered, true);
                        break;
                }
            }
        }

    }
}