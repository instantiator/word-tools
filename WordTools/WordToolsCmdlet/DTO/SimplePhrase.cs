using System;
using System.Collections.Generic;
using System.Linq;

namespace WordToolsCmdlet.DTO
{
    public class SimplePhrase : IPhrase
    {
        public IEnumerable<IWord> Words { get; private set; } = new List<IWord>();

        public static SimplePhrase From(params string[] words)
        {
            return new SimplePhrase() { Words = words.Select(w => new SimpleWord(w)) };
        }

        public static SimplePhrase From(params IWord[] words)
        {
            return new SimplePhrase() { Words = words };
        }

        public static SimplePhrase From(IEnumerable<IWord> words)
        {
            return new SimplePhrase() { Words = words };
        }

        public static SimplePhrase From(IEnumerable<string> words)
        {
            return new SimplePhrase() { Words = words .Select(w => new SimpleWord(w)) };
        }

        public override string ToString()
        {
            return string.Join(", ", Words.Select(w => w.Text));
        }

    }
}
