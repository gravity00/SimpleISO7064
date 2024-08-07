#region License
// The MIT License (MIT)
// 
// Copyright (c) 2024 João Simões
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

namespace SimpleISO7064;

/// <summary>
/// An ISO 7064 Pure System provider to validate or compute check digits
/// </summary>
public class Iso7064PureSystemProvider : IIso7064PureSystemProvider
{
    private readonly int _numCheckDigits;

    /// <summary>
    /// Creates a new instance.
    /// </summary>
    /// <param name="modulus">The pure system modulus</param>
    /// <param name="radix">The pure system radix</param>
    /// <param name="isDoubleCheckDigit">Is the computed check digit composed by two characters?</param>
    /// <param name="characterSet">The supported character set</param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentException"></exception>
    public Iso7064PureSystemProvider(
        int modulus,
        int radix,
        bool isDoubleCheckDigit,
        string characterSet
    )
    {
        Ensure.GreaterThan(modulus, 0, nameof(modulus));
        Ensure.GreaterThan(radix, 0, nameof(radix));
        Ensure.NotNullOrWhiteSpace(characterSet, nameof(characterSet));

        Modulus = modulus;
        Radix = radix;
        IsDoubleCheckDigit = isDoubleCheckDigit;
        CharacterSet = characterSet;

        _numCheckDigits = IsDoubleCheckDigit ? 2 : 1;
    }

    /// <summary>
    /// Creates a new instance.
    /// </summary>
    /// <param name="modulus">The pure system modulus</param>
    /// <param name="radix">The pure system radix</param>
    /// <param name="isDoubleCheckDigit">Is the computed check digit composed by two characters?</param>
    /// <param name="characterSet">The supported character set</param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentException"></exception>
    public Iso7064PureSystemProvider(
        int modulus, 
        int radix, 
        bool isDoubleCheckDigit, 
        params char[] characterSet
    ) : this(
        modulus, 
        radix, 
        isDoubleCheckDigit, 
        new string(characterSet)
    )
    {

    }

    /// <inheritdoc />
    public int Modulus { get; }

    /// <inheritdoc />
    public int Radix { get; }

    /// <inheritdoc />
    public bool IsDoubleCheckDigit { get; }

    /// <inheritdoc />
    public string CharacterSet { get; }

    /// <inheritdoc />
    public bool IsValid(string value)
    {
        ValidateInput(value, _numCheckDigits);

        ComputeCheckDigit(
            value,
            value.Length - _numCheckDigits,
            out var firstCheckDigit,
            out var secondCheckDigit
        );

        if (IsDoubleCheckDigit)
        {
            return value[value.Length - 2] == firstCheckDigit &&
                   value[value.Length - 1] == secondCheckDigit;
        }

        return value[value.Length - 1] == firstCheckDigit;
    }

    /// <inheritdoc />
    public string ComputeCheckDigit(string value)
    {
        ValidateInput(value, _numCheckDigits);

        ComputeCheckDigit(
            value,
            value.Length,
            out var firstCheckDigit,
            out var secondCheckDigit
        );

        return IsDoubleCheckDigit ? $"{firstCheckDigit}{secondCheckDigit}" : firstCheckDigit.ToString();
    }

    /// <inheritdoc />
    public string Compute(string value)
    {
        ValidateInput(value, _numCheckDigits);

        ComputeCheckDigit(
            value,
            value.Length,
            out var firstCheckDigit,
            out var secondCheckDigit
        );

        return IsDoubleCheckDigit ? $"{value}{firstCheckDigit}{secondCheckDigit}" : $"{value}{firstCheckDigit}";
    }

    private void ComputeCheckDigit(
        string value,
        int count,
        out char firstCheckDigit,
        out char secondCheckDigit
    )
    {
        var tmpCalculation = 0;

        for (var i = 0; i < count; i++)
        {
            var valueDigit = value[i];

            var indexToAdd = CharacterSet.IndexOf(valueDigit);
            if (indexToAdd < 0)
                throw new ArgumentException($"Found illegal character '{valueDigit}'", nameof(value));

            tmpCalculation = (tmpCalculation + indexToAdd) * Radix % Modulus;
        }

        if (IsDoubleCheckDigit)
            tmpCalculation = tmpCalculation * Radix % Modulus;

        var checksum = (Modulus - tmpCalculation + 1) % Modulus;

        if (!IsDoubleCheckDigit)
        {
            firstCheckDigit = CharacterSet[checksum];
            secondCheckDigit = default;
            return;
        }

        var secondPosition = checksum % Radix;
        var firstPosition = (checksum - secondPosition) / Radix;

        firstCheckDigit = CharacterSet[firstPosition];
        secondCheckDigit = CharacterSet[secondPosition];
    }

    private static void ValidateInput(string value, int numCheckDigits)
    {
        Ensure.NotNullOrWhiteSpace(value, nameof(value));
        Ensure.GreaterThan(value.Length, numCheckDigits, nameof(value));
    }
}