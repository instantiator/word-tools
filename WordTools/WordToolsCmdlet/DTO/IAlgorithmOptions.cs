using System;
namespace WordToolsCmdlet.DTO
{
    public interface IAlgorithmOptions
    {
        Algorithms Algorithm { get; }
        string Describe { get; }
    }
}
