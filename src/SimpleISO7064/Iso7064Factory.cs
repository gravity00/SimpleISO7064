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

using SimpleISO7064.PureSystems;

namespace SimpleISO7064;

/// <summary>
/// Factory class for building ISO 7064 providers
/// </summary>
public class Iso7064Factory
{
    /// <summary>
    /// Creates an instance of <see cref="Iso7064PureSystemProvider"/> with Modulus 11 and Radix 2
    /// </summary>
    /// <returns>An ISO 7064 Pure System provider to validate or compute check digits, with Modulus 11 and Radix 2</returns>
    public Mod11Radix2 GetMod11Radix2() => new();

    /// <summary>
    /// Creates an instance of <see cref="Iso7064PureSystemProvider"/> with Modulus 37 and Radix 2
    /// </summary>
    /// <returns>An ISO 7064 Pure System provider to validate or compute check digits, with Modulus 37 and Radix 2</returns>
    public Mod37Radix2 GetMod37Radix2() => new();

    /// <summary>
    /// Creates an instance of <see cref="Iso7064PureSystemProvider"/> with Modulus 97 and Radix 10
    /// </summary>
    /// <returns>An ISO 7064 Pure System provider to validate or compute check digits, with Modulus 97 and Radix 10</returns>
    public Mod97Radix10 GetMod97Radix10() => new();

    /// <summary>
    /// Creates an instance of <see cref="Iso7064PureSystemProvider"/> with Modulus 661 and Radix 26
    /// </summary>
    /// <returns>An ISO 7064 Pure System provider to validate or compute check digits, with Modulus 661 and Radix 26</returns>
    public Mod661Radix26 GetMod661Radix26() => new();

    /// <summary>
    /// Creates an instance of <see cref="Iso7064PureSystemProvider"/> with Modulus 1271 and Radix 36
    /// </summary>
    /// <returns>An ISO 7064 Pure System provider to validate or compute check digits, with Modulus 1271 and Radix 36</returns>
    public Mod1271Radix36 GetMod1271Radix36() => new();

    /// <summary>
    /// Creates an instance of <see cref="IIso7064PureSystemProvider"/> with the given parameters
    /// </summary>
    /// <param name="modulus">The pure system modulus</param>
    /// <param name="radix">The pure system radix</param>
    /// <param name="isDoubleCheckDigit">Is the computed check digit composed by two characters?</param>
    /// <param name="characterSet">The supported character set</param>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentException"></exception>
    public IIso7064PureSystemProvider Get(
        int modulus,
        int radix,
        bool isDoubleCheckDigit,
        string characterSet
    ) => new Iso7064PureSystemProvider(modulus, radix, isDoubleCheckDigit, characterSet);
}