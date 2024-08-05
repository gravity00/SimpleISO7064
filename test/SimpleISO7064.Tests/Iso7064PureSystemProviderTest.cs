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

namespace SimpleISO7064.Tests;

public class Iso7064PureSystemProviderTest
{
    [Theory, MemberData(nameof(ValidParametersData))]
    public void Constructor_StringCharacterSet_ValidParameters_PropertiesMustMatch(
        int modulus,
        int radix,
        bool isDoubleCheckDigit,
        string characterSet
    )
    {
        var provider = new Iso7064PureSystemProvider(modulus, radix, isDoubleCheckDigit, characterSet);

        Assert.Equal(modulus, provider.Modulus);
        Assert.Equal(radix, provider.Radix);
        Assert.Equal(isDoubleCheckDigit, provider.IsDoubleCheckDigit);
        Assert.Equal(characterSet, provider.CharacterSet);
    }

    [Theory, MemberData(nameof(ValidParametersWithCharArrayData))]
    public void Constructor_CharArrayCharacterSet_ValidParameters_PropertiesMustMatch(
        int modulus, 
        int radix, 
        bool isDoubleCheckDigit, 
        char[] characterSet
    )
    {
        var provider = new Iso7064PureSystemProvider(modulus, radix, isDoubleCheckDigit, characterSet);

        Assert.Equal(modulus, provider.Modulus);
        Assert.Equal(radix, provider.Radix);
        Assert.Equal(isDoubleCheckDigit, provider.IsDoubleCheckDigit);
        Assert.Equal(characterSet, provider.CharacterSet.ToCharArray());
    }

    [Theory, MemberData(nameof(InvalidParametersData))]
    public void Constructor_StringCharacterSet_InvalidParameters_ThrowsArgumentException(
        int modulus, 
        int radix, 
        bool isDoubleCheckDigit, 
        string? characterSet
    )
    {
        Assert.ThrowsAny<ArgumentException>(
            () => new Iso7064PureSystemProvider(modulus, radix, isDoubleCheckDigit, characterSet!)
        );
    }

    [Theory, MemberData(nameof(InvalidParametersWithCharArrayData))]
    public void Constructor_CharArrayCharacterSet_InvalidParameters_ThrowsArgumentException(
        int modulus, 
        int radix, 
        bool isDoubleCheckDigit, 
        char[]? characterSet
    )
    {
        Assert.ThrowsAny<ArgumentException>(
            () => new Iso7064PureSystemProvider(modulus, radix, isDoubleCheckDigit, characterSet!)
        );
    }

    #region Data

    public static TheoryData<int, int, bool, string> ValidParametersData => new()
    {
        { 11, 2, false, "0123456789X" },
        { 37, 2, false, "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ*" },
        { 97, 10, true, "0123456789" },
        { 661, 26, true, "ABCDEFGHIJKLMNOPQRSTUVWXYZ" },
        { 1271, 36, true, "0123456789ABCDEFGHIJKLMNOPQRSTUVWXZY" }
    };

    public static TheoryData<int, int, bool, char[]> ValidParametersWithCharArrayData => new()
    {
        { 11, 2, false, "0123456789X".ToCharArray() },
        { 37, 2, false, "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ*".ToCharArray() },
        { 97, 10, true, "0123456789".ToCharArray() },
        { 661, 26, true, "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray() },
        { 1271, 36, true, "0123456789ABCDEFGHIJKLMNOPQRSTUVWXZY".ToCharArray() }
    };

    public static TheoryData<int, int, bool, string?> InvalidParametersData => new()
    {
        { 0, 2, false, "0123456789X" },
        { -20, 2, false, "0123456789X" },
        { 11, 0, false, "0123456789X" },
        { 11, -30, false, "0123456789X" },
        { 11, 2, false, null },
        { 11, 2, false, "" },
        { 11, 2, false, "     " }
    };

    public static TheoryData<int, int, bool, char[]?> InvalidParametersWithCharArrayData => new()
    {
        { 0, 2, false, "0123456789X".ToCharArray() },
        { -20, 2, false, "0123456789X".ToCharArray() },
        { 11, 0, false, "0123456789X".ToCharArray() },
        { 11, -30, false, "0123456789X".ToCharArray() },
        { 11, 2, false, null },
        { 11, 2, false, "".ToCharArray() },
        { 11, 2, false, "     ".ToCharArray() }
    };

    #endregion
}