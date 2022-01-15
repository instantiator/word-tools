using System;
namespace WordToolsCmdlet.DTO
{
    public class DecipheredWord : SimpleWord
    {
        public DecipheredWord(string text, IAlgorithmOptions options) : base(text)
        {
            this.Options = options;
        }

        public IAlgorithmOptions Options { get; private set; }
    }
}
