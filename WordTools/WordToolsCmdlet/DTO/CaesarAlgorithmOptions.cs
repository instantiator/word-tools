using System;
namespace WordToolsCmdlet.DTO
{
    public class CaesarAlgorithmOptions : IAlgorithmOptions
    {
        public CaesarAlgorithmOptions(int rotation)
        {
            Rotation = rotation;
        }

        public Algorithms Algorithm => Algorithms.caesar;

        public int Rotation { get; set; }

        public string Describe => $"caesar({Rotation})";

        public override string ToString() => Describe;
    }
}
