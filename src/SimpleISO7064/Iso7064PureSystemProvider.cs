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
    using System.Runtime.CompilerServices;

    /// <summary>
    /// An ISO 7064 Pure System provider to validate or 
    /// compute check digits
    /// </summary>
    public sealed class Iso7064PureSystemProvider
    {
        private readonly int _numCheckDigits;

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

            _numCheckDigits = IsDoubleCheckDigit ? 2 : 1;
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
        /// <param name="value">The value to check</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public bool IsValid(string value)
        {
            ValidateInput(value);
            value = value.ToUpperInvariant();

            return value.Equals(Compute(value.Substring(0, value.Length - _numCheckDigits)));
        }

        /// <summary>
        /// Computes the check digit from a given value.
        /// </summary>
        /// <param name="value">The value from which the check digit will be computed</param>
        /// <returns>The check digit</returns>
        public string ComputeCheckDigit(string value)
        {
            ValidateInput(value);
            value = value.ToUpperInvariant();

            int tmpCalculation = 0;

            foreach (char valueDigit in value)
            {
                int digit = Convert.ToInt32(valueDigit);

                tmpCalculation = ((tmpCalculation + digit)*Radix)%Modulus;
            }

            if (IsDoubleCheckDigit)
            {
                tmpCalculation = (tmpCalculation*Radix)%Modulus;
            }

            int checksum = (Modulus - tmpCalculation + 1)%Modulus;

            if (IsDoubleCheckDigit)
            {
                int secondPosition = checksum%Radix;
                int firstPosition = (checksum - secondPosition)/Radix;

                return string.Concat(value[firstPosition], value[secondPosition]);
            }
            else
            {
                return value[checksum].ToString();
            }
        }

        /// <summary>
        /// Computes the check digit and appends it to the given value.
        /// </summary>
        /// <param name="value">The value from which the check digit will be computed</param>
        /// <returns>The value and appended check digit</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public string Compute(string value)
        {
            ValidateInput(value);
            value = value.ToUpperInvariant();

            return string.Concat(value, ComputeCheckDigit(value));
        }

        /// <summary>
        /// Validates if the given value can be computed and returns the value
        /// ready to be processed.
        /// </summary>
        /// <param name="value">The value to be validates and prepared</param>
        /// <returns>The value prepared for processing</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
#if !NET40
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
        private void ValidateInput(string value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(value));
            if (value.Length <= _numCheckDigits)
                throw new ArgumentException(
                    string.Concat("Value length should be greater than ", _numCheckDigits), nameof(value));
        }
    }
}
