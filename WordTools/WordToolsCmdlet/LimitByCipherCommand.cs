using System;
using System.Management.Automation;
using WordToolsCmdlet.DTO;

namespace WordToolsCmdlet
{
    [Cmdlet(VerbsData.Limit, "ByCipher")]
    [OutputType(typeof(DecipheredWord))]
    public class LimitByCipherCommand : Cmdlet
    {
        [Parameter(Mandatory = true)]
        public string CipherText { get; set; }

        [Parameter(Mandatory = true)]
        public Algorithms Algorithm { get; set; }

        [Parameter]
        public string Key { get; set; }

        [Parameter(ValueFromPipeline = true)]
        public IWord Word { get; set; }

        protected override void ProcessRecord()
        {
            string word = Word.Text.ToLower().Trim();
            string ciphertext = CipherText?.ToLower().Trim();

            switch (Algorithm)
            {
                case Algorithms.caesar:
                    int key;
                    bool keyOk = int.TryParse(Key, out key);
                    int? rotation = MatchesWithCaesar(word, ciphertext, keyOk ? key : null);
                    if (rotation != null)
                    {
                        WriteObject(new DecipheredWord(word, new CaesarAlgorithmOptions(rotation.Value)));
                    }
                    break;
            }
        }

        public static int? MatchesWithCaesar(string word, string ciphertext, int? key)
        {
            if (word.Length != ciphertext?.Length) { return null; }

            if (key != null)
            {
                if (word.Equals(RotateWord(ciphertext, key.Value)))
                {
                    return key;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                for (int rotation = 1; rotation <= 26; rotation++)
                {
                    if (word.Equals(RotateWord(ciphertext, rotation)))
                    {
                        return rotation;
                    }
                }
                return null;
            }
        }

        public static string RotateWord(string word, int rotation)
        {
            string output = string.Empty;
            foreach (char c in word)
            {
                output += RotateChar(c, rotation);
            }
            return output;
        }

        public static char RotateChar(char c, int rotation)
        {
            if (!char.IsLetter(c)) { return c; }
            char d = char.IsUpper(c) ? 'A' : 'a';
            return (char)((((c + rotation) - d) % 26) + d);
        }
    }
}