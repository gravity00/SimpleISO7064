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

namespace SimpleISO7064.PureSystems;

public class Mod97Radix10Test
{
    [Theory, MemberData(nameof(ValidComputedData))]
    public void IsValid_ValidParameter_ReturnTrue(
        string computedValue
    )
    {
        var provider = new Mod97Radix10();
        Assert.True(provider.IsValid(computedValue));
    }

    [Theory, MemberData(nameof(ValidComputedWithValueData))]
    public void Compute_ValidParameter_MustMatchComputed(
        string computedValue,
        string value
    )
    {
        var provider = new Mod97Radix10();
        Assert.Equal(
            computedValue,
            provider.Compute(value),
            StringComparer.InvariantCultureIgnoreCase
        );
    }

    [Theory, MemberData(nameof(ValidValueWithCheckDigitData))]
    public void ComputeCheckDigit_ValidParameter_MustMatchCheckDigit(
        string value,
        string checkDigit
    )
    {
        var provider = new Mod97Radix10();
        Assert.Equal(
            checkDigit,
            provider.ComputeCheckDigit(value),
            StringComparer.InvariantCultureIgnoreCase
        );
    }

    [Theory, MemberData(nameof(InvalidComputedData))]
    public void IsValid_InvalidParameter_ReturnFalse(string computedValue)
    {
        var provider = new Mod97Radix10();
        Assert.False(provider.IsValid(computedValue));
    }

    [Theory, MemberData(nameof(BadFormatData))]
    public void IsValid_BadFormatParameter_ThrowsArgumentException(string? computedValue)
    {
        var provider = new Mod97Radix10();
        Assert.ThrowsAny<ArgumentException>(() =>
        {
            provider.IsValid(computedValue!);
        });
    }

    [Theory, MemberData(nameof(BadFormatData))]
    public void Compute_BadFormatParameter_ThrowsArgumentException(string? computedValue)
    {
        var provider = new Mod97Radix10();
        Assert.ThrowsAny<ArgumentException>(() =>
        {
            provider.Compute(computedValue!);
        });
    }

    [Theory, MemberData(nameof(BadFormatData))]
    public void ComputeCheckDigit_BadFormatParameter_ThrowsArgumentException(string? computedValue)
    {
        var provider = new Mod97Radix10();
        Assert.ThrowsAny<ArgumentException>(() =>
        {
            provider.ComputeCheckDigit(computedValue!);
        });
    }

    #region Data

    public static TheoryData<string> ValidComputedData => new()
    {
        "9999123456789012141490",
        "08686001256515001121751"
    };

    public static TheoryData<string, string> ValidComputedWithValueData => new()
    {
        { "9999123456789012141490", "99991234567890121414" },
        { "08686001256515001121751", "086860012565150011217" }
    };

    public static TheoryData<string, string> ValidValueWithCheckDigitData => new()
    {
        { "99991234567890121414", "90" },
        { "086860012565150011217", "51" }
    };

    public static TheoryData<string> InvalidComputedData => new()
    {
        "9999123456789012141450",
        "08686001256515001121700"
    };

    public static TheoryData<string?> BadFormatData => new()
    {
        null,
        string.Empty,
        "   ",
        "123ABCD<>!X"
    };

    #endregion
}