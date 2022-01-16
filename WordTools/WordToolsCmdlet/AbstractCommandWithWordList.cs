using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using WordToolsCmdlet.DTO;

namespace WordToolsCmdlet
{
    public abstract class AbstractCommandWithWordList : Cmdlet
    {
        [Parameter]
        public string WordListPath { get; set; }

        [Parameter]
        public string[] WordList { get; set; }

        protected Dictionary<string, IWord> wordlist;

        protected override void BeginProcessing()
        {
            InitWordList();
        }

        protected void InitWordList()
        {
            if (wordlist == null)
            {
                wordlist = new Dictionary<string, IWord>();

                if (!string.IsNullOrWhiteSpace(WordListPath))
                {
                    wordlist = wordlist.Concat(
                        File.ReadLines(WordListPath)
                            .Select(l => new SimpleWord(l.Trim().ToLower()) as IWord)
                            .ToDictionary(w => w.Text))
                        .ToDictionary(x => x.Key, x => x.Value);
                }

                if (WordList != null && WordList.Count() > 0)
                {
                    wordlist = wordlist.Concat(
                        WordList
                            .Select(w => new SimpleWord(w.Trim().ToLower()) as IWord)
                            .ToDictionary(w => w.Text))
                        .ToDictionary(x => x.Key, x => x.Value);
                }
            }
        }


    }
}
