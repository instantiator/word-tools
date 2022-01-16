﻿/// <summary>
/// See: https://github.com/eoincampbell/combinatorics/blob/deployment/src/Combinatorics/GenerateOption.cs
/// </summary>
namespace Combinatorics.Collections
{
    /// <summary>
    /// Indicates whether a permutation, combination or variation generates equivalent result sets.  
    /// </summary>
    public enum GenerateOption
    {
        /// <summary>
        /// Do not generate equivalent result sets.
        /// </summary>
        WithoutRepetition,

        /// <summary>
        /// Generate equivalent result sets.
        /// </summary>
        WithRepetition,
    }
}