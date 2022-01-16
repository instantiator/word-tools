using System;
namespace WordToolsCmdlet.DTO
{
    public interface IWord : IComparable
    {
        public string Text { get; }
    }
}
