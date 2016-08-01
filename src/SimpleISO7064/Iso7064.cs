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
    /// Global ISO 7064 singletons
    /// </summary>
    public static class Iso7064
    {
        /// <summary>
        /// Global factory to build ISO 7064 providers
        /// </summary>
        public static Iso7064Factory Factory { get; } = new Iso7064Factory();

        /// <summary>
        /// Pure System providers
        /// </summary>
        public static class PureSystem
        {
            /// <summary>
            /// Singleton Mod 11 Radix 2 provider
            /// </summary>
            public static Mod11Radix2 Mod11Radix2 { get; } = Factory.GetMod11Radix2();

            /// <summary>
            /// Singleton Mod 37 Radix 2 provider
            /// </summary>
            public static Mod37Radix2 Mod37Radix2 { get; } = Factory.GetMod37Radix2();

            /// <summary>
            /// Singleton Mod 97 Radix 10 provider
            /// </summary>
            public static Iso7064PureSystemProvider Mod97Radix10 { get; } = Factory.GetMod97Radix10();

            /// <summary>
            /// Singleton Mod 661 Radix 26 provider
            /// </summary>
            public static Iso7064PureSystemProvider Mod661Radix26 { get; } = Factory.GetMod661Radix26();

            /// <summary>
            /// Singleton Mod 1271 Radix 36 provider
            /// </summary>
            public static Iso7064PureSystemProvider Mod1271Radix36 { get; } = Factory.GetMod1271Radix36();
        }
    }
}
