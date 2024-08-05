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

namespace SimpleISO7064;

internal static class Ensure
{
    public static void GreaterThan(int value, int comparer, string paramName)
    {
        if (value <= comparer)
            throw new ArgumentOutOfRangeException(paramName, value, $"Value should be greater than {comparer}");
    }

    public static void NotNull<T>(T value, string paramName) where T : class
    {
        if (value == null)
            throw new ArgumentNullException(paramName);
    }

    public static void NotNullOrWhiteSpace(string value, string paramName)
    {
        NotNull(value, paramName);

#if NET20
        var isWhiteSpace = true;

        if (value.Length > 0)
        {
            foreach (var c in value)
            {
                if (char.IsWhiteSpace(c))
                    continue;

                isWhiteSpace = false;
                break;
            }
        }
#else
        var isWhiteSpace = string.IsNullOrWhiteSpace(value);
#endif

        if (isWhiteSpace)
            throw new ArgumentException("Value cannot be whitespace.", paramName);
    }
}