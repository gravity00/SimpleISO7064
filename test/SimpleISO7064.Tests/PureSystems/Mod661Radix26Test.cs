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
namespace SimpleISO7064.Tests.PureSystems
{
    using SimpleISO7064.PureSystems;
    using System;
    using System.Collections.Generic;
    using Xunit;

    public class Mod661Radix26Test
    {
        [Theory, MemberData(nameof(ValidData))]
        public void GivenAValidComputedValueWhenValidatedThenTrueMustBeReturned(
            string computedValue, string value, string checkDigit)
        {
            var provider = new Mod661Radix26();
            Assert.True(provider.IsValid(computedValue));
        }

        [Theory, MemberData(nameof(ValidData))]
        public void GivenAValidValueWhenComputedThenAValidComputedValueMustBeCreated(
            string computedValue, string value, string checkDigit)
        {
            var provider = new Mod661Radix26();
            Assert.Equal(computedValue, provider.Compute(value));
        }

        [Theory, MemberData(nameof(ValidData))]
        public void GivenAValidValueWhenComputedTheCheckDigitThenAValidCheckDigitMustBeCreated(
            string computedValue, string value, string checkDigit)
        {
            var provider = new Mod661Radix26();
            Assert.Equal(checkDigit, provider.ComputeCheckDigit(value));
        }

        [Theory, MemberData(nameof(InvalidComputedData))]
        public void GivenAnInvalidComputedValueWhenValidatedThenFalseMustBeReturned(string computedValue)
        {
            var provider = new Mod661Radix26();
            Assert.False(provider.IsValid(computedValue));
        }

        [Theory, MemberData(nameof(BadFormatData))]
        public void GivenAnBadFormatComputedValueWhenValidatedThenExceptionMustBeThrown(string computedValue)
        {
            var provider = new Mod661Radix26();
            Assert.ThrowsAny<ArgumentException>(() =>
            {
                provider.IsValid(computedValue);
            });
        }

        [Theory, MemberData(nameof(BadFormatData))]
        public void GivenAnBadFormatComputedValueWhenComputedThenExceptionMustBeThrown(string computedValue)
        {
            var provider = new Mod661Radix26();
            Assert.ThrowsAny<ArgumentException>(() =>
            {
                provider.Compute(computedValue);
            });
        }

        [Theory, MemberData(nameof(BadFormatData))]
        public void GivenAnBadFormatComputedValueWhenComputedCheckDigitThenExceptionMustBeThrown(string computedValue)
        {
            var provider = new Mod661Radix26();
            Assert.ThrowsAny<ArgumentException>(() =>
            {
                provider.ComputeCheckDigit(computedValue);
            });
        }

        #region Data

        public static IEnumerable<object[]> ValidData
        {
            get
            {
                yield return new object[]
                {
                    "BAISDLAFKBM", "BAISDLAFK", "BM"
                };
            }
        }

        public static IEnumerable<object[]> InvalidComputedData
        {
            get
            {
                yield return new object[]
                {
                    "BAISDLAFKBMRJ"
                };
            }
        }

        public static IEnumerable<object[]> BadFormatData
        {
            get
            {
                yield return new object[]
                {
                    null
                };
                yield return new object[]
                {
                    string.Empty
                };
                yield return new object[]
                {
                    "   "
                };
                yield return new object[]
                {
                    "123ABCD<>!X"
                };
            }
        }

        #endregion
    }
}
