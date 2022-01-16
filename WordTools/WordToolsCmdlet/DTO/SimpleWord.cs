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

        public int CompareTo(object obj)
        {
            return Text.CompareTo((obj as IWord)?.Text);
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
