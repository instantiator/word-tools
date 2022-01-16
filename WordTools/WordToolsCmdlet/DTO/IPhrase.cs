using System;
using System.Collections.Generic;

namespace WordToolsCmdlet.DTO
{
    public interface IPhrase
    {
        IEnumerable<IWord> Words { get; }
    }
}
