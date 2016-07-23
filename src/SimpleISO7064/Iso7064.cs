#region License
// The MIT License (MIT)
// 
// Copyright (c) 2016 João Simões
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
#endregion
namespace SimpleISO7064
{
    /// <summary>
    /// An ISO 7064 Pure System provider to validate or 
    /// compute check digits
    /// </summary>
    public interface IIso7064PureSystemProvider
    {
        /// <summary>
        /// The pure system modulus
        /// </summary>
        int Modulus { get; }

        /// <summary>
        /// The pure system radiz
        /// </summary>
        int Radix { get; }

        /// <summary>
        /// The supported character set
        /// </summary>
        char[] CharacterSet { get; }

        /// <summary>
        /// Is the computed check digit composed by two characters?
        /// </summary>
        bool IsDoubleCheckDigit { get; }

        /// <summary>
        /// Checks if the given value contains a valid check digit.
        /// </summary>
        /// <param name="computedValue">The value to check</param>
        /// <returns></returns>
        bool IsValid(string computedValue);

        /// <summary>
        /// Computes the check digit from a given value.
        /// </summary>
        /// <param name="value">The value from which the check digit will be computed</param>
        /// <returns>The check digit</returns>
        string ComputeCheckDigit(string value);

        /// <summary>
        /// Computes the check digit and appends it to the given value.
        /// </summary>
        /// <param name="value">The value from which the check digit will be computed</param>
        /// <returns>The value and appended check digit</returns>
        string Compute(string value);
    }
}
