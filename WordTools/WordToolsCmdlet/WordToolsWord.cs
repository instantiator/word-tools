using System;
namespace WordToolsCmdlet
{
    public class Word
    {
        public string Text { get; set; }

        public static Word JustText(string text)
        {
            return new Word()
            {
                Text = text
            };
        }
    }
}
