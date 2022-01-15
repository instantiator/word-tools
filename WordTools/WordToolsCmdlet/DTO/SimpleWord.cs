using System;
namespace WordToolsCmdlet.DTO
{
    public class SimpleWord : IWord
    {
        public SimpleWord(string text)
        {
            this.Text = text;
        }

        public string Text { get; private set; }
    }
}
