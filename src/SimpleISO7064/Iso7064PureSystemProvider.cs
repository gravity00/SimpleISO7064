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
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// An ISO 7064 Pure System provider to validate or 
    /// compute check digits
    /// </summary>
    public sealed class Iso7064PureSystemProvider
    {
        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="modulus">The pure system modulus</param>
        /// <param name="radix">The pure system radiz</param>
        /// <param name="isDoubleCheckDigit">Is the computed check digit composed by two characters?</param>
        /// <param name="characterSet">The supported character set</param>
        public Iso7064PureSystemProvider(int modulus, int radix, bool isDoubleCheckDigit, string characterSet)
            :this(modulus, radix, isDoubleCheckDigit, characterSet.ToCharArray())
        {

        }

        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="modulus">The pure system modulus</param>
        /// <param name="radix">The pure system radiz</param>
        /// <param name="isDoubleCheckDigit">Is the computed check digit composed by two characters?</param>
        /// <param name="characterSet">The supported character set</param>
        public Iso7064PureSystemProvider(int modulus, int radix, bool isDoubleCheckDigit, params char[] characterSet)
        {
            Modulus = modulus;
            Radix = radix;
            IsDoubleCheckDigit = isDoubleCheckDigit;
            CharacterSet = characterSet;
        }

        /// <summary>
        /// The pure system modulus
        /// </summary>
        public int Modulus { get; }

        /// <summary>
        /// The pure system radiz
        /// </summary>
        public int Radix { get; }

        /// <summary>
        /// Is the computed check digit composed by two characters?
        /// </summary>
        public bool IsDoubleCheckDigit { get; }

        /// <summary>
        /// The supported character set
        /// </summary>
#if NET40
        public IEnumerable<char> CharacterSet { get; }
#else
        public IReadOnlyCollection<char> CharacterSet { get; }
#endif

        /// <summary>
        /// Checks if the given value contains a valid check digit.
        /// </summary>
        /// <param name="computedValue">The value to check</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public bool IsValid(string computedValue)
        {
            if (computedValue == null)
                throw new ArgumentNullException(nameof(computedValue));
            if (string.IsNullOrWhiteSpace(computedValue))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(computedValue));

            var numCheckDigits = IsDoubleCheckDigit ? 2 : 1;
            if (computedValue.Length <= numCheckDigits)
                throw new ArgumentException(
                    string.Concat("Value length should be greater than ", numCheckDigits), nameof(computedValue));

            computedValue = computedValue.ToUpperInvariant();
            return computedValue.Equals(Compute(computedValue.Substring(0, computedValue.Length - numCheckDigits)));
        }

        /// <summary>
        /// Computes the check digit from a given value.
        /// </summary>
        /// <param name="value">The value from which the check digit will be computed</param>
        /// <returns>The check digit</returns>
        public string ComputeCheckDigit(string value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Computes the check digit and appends it to the given value.
        /// </summary>
        /// <param name="valueToCompute">The value from which the check digit will be computed</param>
        /// <returns>The value and appended check digit</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public string Compute(string valueToCompute)
        {
            if (valueToCompute == null)
                throw new ArgumentNullException(nameof(valueToCompute));
            if (string.IsNullOrWhiteSpace(valueToCompute))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(valueToCompute));

            valueToCompute = valueToCompute.ToUpperInvariant();
            return string.Concat(valueToCompute, ComputeCheckDigit(valueToCompute));
        }
    }
}
