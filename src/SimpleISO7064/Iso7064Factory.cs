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
    using PureSystems;

    /// <summary>
    /// Factory class for building ISO 7064 providers
    /// </summary>
    public class Iso7064Factory
    {
        /// <summary>
        /// Creates a insatnce of <see cref="Iso7064PureSystemProvider"/> with Modulus 11 and Radix 2
        /// </summary>
        /// <returns>An ISO 7064 Pure System provider to validate or compute check digits, with Modulus 11 and Radix 2</returns>
        public Mod11Radix2 GetMod11Radix2()
        {
            return new Mod11Radix2();
        }

        /// <summary>
        /// Creates a insatnce of <see cref="Iso7064PureSystemProvider"/> with Modulus 37 and Radix 2
        /// </summary>
        /// <returns>An ISO 7064 Pure System provider to validate or compute check digits, with Modulus 37 and Radix 2</returns>
        public Mod37Radix2 GetMod37Radix2()
        {
            return new Mod37Radix2();
        }

        /// <summary>
        /// Creates a insatnce of <see cref="Iso7064PureSystemProvider"/> with Modulus 97 and Radix 10
        /// </summary>
        /// <returns>An ISO 7064 Pure System provider to validate or compute check digits, with Modulus 97 and Radix 10</returns>
        public Mod97Radix10 GetMod97Radix10()
        {
            return new Mod97Radix10();
        }

        /// <summary>
        /// Creates a insatnce of <see cref="Iso7064PureSystemProvider"/> with Modulus 661 and Radix 26
        /// </summary>
        /// <returns>An ISO 7064 Pure System provider to validate or compute check digits, with Modulus 661 and Radix 26</returns>
        public Mod661Radix26 GetMod661Radix26()
        {
            return new Mod661Radix26();
        }

        /// <summary>
        /// Creates a insatnce of <see cref="Iso7064PureSystemProvider"/> with Modulus 1271 and Radix 36
        /// </summary>
        /// <returns>An ISO 7064 Pure System provider to validate or compute check digits, with Modulus 1271 and Radix 36</returns>
        public Iso7064PureSystemProvider GetMod1271Radix36()
        {
            return new Iso7064PureSystemProvider(1271, 36, true, "0123456789ABCDEFGHIJKLMNOPQRSTUVWXZY");
        }
    }
}