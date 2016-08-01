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

    public class Mod11Radix2Test
    {
        [Theory, MemberData(nameof(ValidData))]
        public void GivenAValidComputedValueWhenValidatedThenTrueMustBeReturned(
            string computedValue, string value, string checkDigit)
        {
            var provider = new Mod11Radix2();
            Assert.True(provider.IsValid(computedValue));
        }

        [Theory, MemberData(nameof(ValidData))]
        public void GivenAValidValueWhenComputedThenAValidComputedValueMustBeCreated(
            string computedValue, string value, string checkDigit)
        {
            var provider = new Mod11Radix2();
            Assert.Equal(computedValue, provider.Compute(value));
        }

        [Theory, MemberData(nameof(ValidData))]
        public void GivenAValidValueWhenComputedTheCheckDigitThenAValidCheckDigitMustBeCreated(
            string computedValue, string value, string checkDigit)
        {
            var provider = new Mod11Radix2();
            Assert.Equal(checkDigit, provider.ComputeCheckDigit(value));
        }

        [Theory, MemberData(nameof(InvalidComputedData))]
        public void GivenAnInvalidComputedValueWhenValidatedThenFalseMustBeReturned(string computedValue)
        {
            var provider = new Mod11Radix2();
            Assert.False(provider.IsValid(computedValue));
        }

        [Theory, MemberData(nameof(BadFormatComputedData))]
        public void GivenAnBadFormatComputedValueWhenValidatedThenExceptionMustBeThrown(string computedValue)
        {
            var provider = new Mod11Radix2();
            Assert.ThrowsAny<ArgumentException>(() =>
            {
                provider.IsValid(computedValue);
            });
        }

        #region Data

        public static IEnumerable<object[]> ValidData
        {
            get
            {
                yield return new object[] 
                {
                    "1011000026831187407", "101100002683118740", "7"
                };
                yield return new object[]
                {
                    "1011000026163915906", "101100002616391590", "6"
                };
                yield return new object[]
                {
                    "2011000028343021308", "201100002834302130", "8"
                };
            }
        }

        public static IEnumerable<object[]> InvalidComputedData
        {
            get
            {
                yield return new object[]
                {
                    "1011000026831187401"
                };
                yield return new object[]
                {
                    "1011000026163915903"
                };
                yield return new object[]
                {
                    "2011000028343021301"
                };
            }
        }

        public static IEnumerable<object[]> BadFormatComputedData
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
                    "2011ABCD28343021301"
                };
            }
        }

        #endregion
    }
}
