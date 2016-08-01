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
namespace SimpleISO7064.Tests
{
    using System;
    using System.Collections.Generic;
    using Xunit;

    public class Iso7064PureSystemProviderTest
    {
        [Theory, MemberData(nameof(PureSystemProviderValidParametersData))]
        public void GivenAPureSystemProviderValidParametersWhenInstanceCreatedAllPropertiesHaveTheSameValues(
            int modulus, int radix, bool isDoubleCheckDigit, string characterSet)
        {
            var provider = new Iso7064PureSystemProvider(modulus, radix, isDoubleCheckDigit, characterSet);

            Assert.Equal(modulus, provider.Modulus);
            Assert.Equal(radix, provider.Radix);
            Assert.Equal(isDoubleCheckDigit, provider.IsDoubleCheckDigit);
            Assert.Equal(characterSet, provider.CharacterSet);
        }

        #region Data

        public static IEnumerable<object[]> PureSystemProviderValidParametersData
        {
            get
            {
                var random = new Random();
                for(var i = 0; i < 10; i++)
                {
                    var randomValue = random.Next(1, 2000);
                    yield return new object[]
                    {
                        randomValue, randomValue % 3, randomValue%2 == 0, string.Concat("ABCD", randomValue.ToString())
                    };
                }
            }
        }

        #endregion
    }
}
