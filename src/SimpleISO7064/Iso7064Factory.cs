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
    public class Iso7064Factory
    {
        /// <summary>
        /// Creates a insatnce of <see cref="Iso7064PureSystemProvider"/> with Modulus 11 and Radix 2
        /// </summary>
        /// <returns>An ISO 7064 Pure System provider to validate or compute check digits, with Modulus 11 and Radix 2</returns>
        public static Iso7064PureSystemProvider GetMod11Radix2()
        {
            return new Iso7064PureSystemProvider(11, 2, false, "0123456789X");
        }

        /// <summary>
        /// Creates a insatnce of <see cref="Iso7064PureSystemProvider"/> with Modulus 11 and Radix 2
        /// </summary>
        /// <returns>An ISO 7064 Pure System provider to validate or compute check digits, with Modulus 11 and Radix 2</returns>
        public static Iso7064PureSystemProvider GetMod37Radix2()
        {
            return new Iso7064PureSystemProvider(37, 2, false, "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ*");
        }

        /// <summary>
        /// Creates a insatnce of <see cref="Iso7064PureSystemProvider"/> with Modulus 11 and Radix 2
        /// </summary>
        /// <returns>An ISO 7064 Pure System provider to validate or compute check digits, with Modulus 11 and Radix 2</returns>
        public static Iso7064PureSystemProvider GetMod97Radix10()
        {
            return new Iso7064PureSystemProvider(97, 10, true, "0123456789");
        }

        /// <summary>
        /// Creates a insatnce of <see cref="Iso7064PureSystemProvider"/> with Modulus 11 and Radix 2
        /// </summary>
        /// <returns>An ISO 7064 Pure System provider to validate or compute check digits, with Modulus 11 and Radix 2</returns>
        public static Iso7064PureSystemProvider GetMod661Radix26()
        {
            return new Iso7064PureSystemProvider(661, 26, true, "ABCDEFGHIJKLMNOPQRSTUVWXYZ");
        }

        /// <summary>
        /// Creates a insatnce of <see cref="Iso7064PureSystemProvider"/> with Modulus 11 and Radix 2
        /// </summary>
        /// <returns>An ISO 7064 Pure System provider to validate or compute check digits, with Modulus 11 and Radix 2</returns>
        public static Iso7064PureSystemProvider GetMod1271Radix36()
        {
            return new Iso7064PureSystemProvider(1271, 36, true, "0123456789ABCDEFGHIJKLMNOPQRSTUVWXZY");
        }
    }
}