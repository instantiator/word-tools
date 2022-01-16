using System;
using System.Collections.Generic;
using System.Linq;
using WordToolsCmdlet.DTO;

namespace WordToolsCmdlet.Helpers
{
    public class CipherHelper
    {
        public static IEnumerable<DecipheredWord> FindCaesarMatch(Dictionary<string, IWord> wordlist, string ciphertext, int? key)
        {
            var matches = new List<DecipheredWord>();
            int low = key ?? 0;
            int high = key ?? 25;

            for (int rotation = low; rotation <= high; rotation++)
            {
                var word = RotateWord(ciphertext, rotation);
                if (wordlist.ContainsKey(word))
                {
                    matches.Add(new DecipheredWord(word, new CaesarAlgorithmOptions(rotation)));
                }
            }
            return matches;
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
