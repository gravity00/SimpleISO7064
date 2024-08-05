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

using SimpleISO7064;

Console.WriteLine("SimpleISO7064 Examples application started...");

try
{
    var results = new[]
    {
        "1011000026831187407",
        "G123489654321Y",
        "9999123456789012141490",
        "BAISDLAFKBM",
        "ISO793W"
    }.Select(v =>
    {
        var isMod11Radix2Valid = CheckIsValid(Iso7064.PureSystem.Mod11Radix2, v);
        var isMod37Radix2Valid = CheckIsValid(Iso7064.PureSystem.Mod37Radix2, v);
        var isMod97Radix10Valid = CheckIsValid(Iso7064.PureSystem.Mod97Radix10, v);
        var isMod661Radix26Valid = CheckIsValid(Iso7064.PureSystem.Mod661Radix26, v);
        var isMod1271Radix36Valid = CheckIsValid(Iso7064.PureSystem.Mod1271Radix36, v);

        return new
        {
            Value = v,
            IsMod11Radix2Valid = isMod11Radix2Valid,
            IsMod37Radix2Valid = isMod37Radix2Valid,
            IsMod97Radix10Valid = isMod97Radix10Valid,
            IsMod661Radix26Valid = isMod661Radix26Valid,
            IsMod1271Radix36Valid = isMod1271Radix36Valid
        };
    });

    Console.WriteLine("Value \t\t\t Mod11Radix2 \t Mod37Radix2 \t Mod97Radix10 \t Mod661Radix26 \t Mod1271Radix36");
    foreach (var result in results)
    {
        Console.WriteLine(
            $"{result.Value,-22} \t {result.IsMod11Radix2Valid} \t\t {result.IsMod37Radix2Valid} \t\t {result.IsMod97Radix10Valid} \t\t {result.IsMod661Radix26Valid} \t\t {result.IsMod1271Radix36Valid}");
    }
}
catch (Exception e)
{
    Console.WriteLine("An unhandled exception has been thrown");
    Console.WriteLine(e.ToString());
}
finally
{
    Console.WriteLine("Application ended. Press <enter> to exit...");
    Console.ReadLine();
}

return;

static bool CheckIsValid(Iso7064PureSystemProvider provider, string value)
{
    try
    {
        return provider.IsValid(value);
    }
    catch
    {
        return false;
    }
}
