# SimpleISO7064
C# library that provide ISO 7064 implementations to verify or calculate check characters.

Out of the box, the library supports the following pure systems:
* Modulus 11 with Radix 2
* Modulus 37 with Radix 2
* Modulus 97 with Radix 10
* Modulus 661 with Radix 26
* Modulus 1271 with Radix 36

## Installation 
This library can be installed via [NuGet](https://www.nuget.org/packages/SimpleISO7064/) package. Just run the following command:

```powershell
Install-Package SimpleISO7064
```

## Compatibility

This library is compatible with the folowing frameworks:

* MonoAndroid 1.0;
* MonoTouch 1.0;
* .NETFramework 2.0;
* .NETFramework 4.0;
* .NETFramework 4.5;
* .NETCore 5.0;
* .NETStandard 1.0;
* Portable Class Library (.NETFramework 4.0, Silverlight 5.0, Windows 8.0, WindowsPhone 8.0, WindowsPhoneApp 8.1);
* Portable Class Library (.NETFramework 4.5, Windows 8.0, WindowsPhoneApp 8.1);
* WindowsPhoneApp 8.1;
* Xamarin.iOS 1.0;
* Xamarin.TVOS 1.0;

## Usage (Version 1.0.0)

Basic example:

```csharp
public static void Main(string[] args)
{
    string value = "1011000026831187407";
    Console.WriteLine(
        $"Value '{value}' is Mod 11 Radix 2 valid? {Iso7064.PureSystem.Mod11Radix2.IsValid(value)}");
}
//Value '1011000026831187407' is Mod 11 Radix 2 valid? True
```

Example with all currently supported pure systems

```csharp
public static void Main(string[] args)
{
    Console.WriteLine("SimpleISO7064 Examples application started...");

    var results = new[]
    {
        "1011000026831187407",
        "G123489654321Y",
        "9999123456789012141490",
        "BAISDLAFKBM",
        "ISO793W"
    }.Select(v => {
        bool isMod11Radix2Valid;
        try
        {
            isMod11Radix2Valid = Iso7064.PureSystem.Mod11Radix2.IsValid(v);
        }
        catch
        {
            isMod11Radix2Valid = false;
        }
        bool isMod37Radix2Valid;
        try
        {
            isMod37Radix2Valid = Iso7064.PureSystem.Mod37Radix2.IsValid(v);
        }
        catch
        {
            isMod37Radix2Valid = false;
        }
        bool isMod97Radix10Valid;
        try
        {
            isMod97Radix10Valid = Iso7064.PureSystem.Mod97Radix10.IsValid(v);
        }
        catch
        {
            isMod97Radix10Valid = false;
        }
        bool isMod661Radix26Valid;
        try
        {
            isMod661Radix26Valid = Iso7064.PureSystem.Mod661Radix26.IsValid(v);
        }
        catch
        {
            isMod661Radix26Valid = false;
        }
        bool isMod1271Radix36Valid;
        try
        {
            isMod1271Radix36Valid = Iso7064.PureSystem.Mod1271Radix36.IsValid(v);
        }
        catch
        {
            isMod1271Radix36Valid = false;
        }
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
    Console.WriteLine(
        "Value \t\t\t Mod11Radix2 \t Mod37Radix2 \t Mod97Radix10 \t Mod661Radix26 \t Mod1271Radix36");
    foreach(var result in results)
    {
        Console.WriteLine(
            $"{result.Value.PadRight(22)} \t {result.IsMod11Radix2Valid} \t\t {result.IsMod37Radix2Valid} \t\t {result.IsMod97Radix10Valid} \t\t {result.IsMod661Radix26Valid} \t\t {result.IsMod1271Radix36Valid}");
    }

    Console.WriteLine("Application ended. Press <enter> to exit...");
    Console.ReadLine();
}
/*
SimpleISO7064 Examples application started...
Value                    Mod11Radix2     Mod37Radix2     Mod97Radix10    Mod661Radix26   Mod1271Radix36
1011000026831187407      True            False           False           False           False
G123489654321Y           False           True            False           False           False
9999123456789012141490   False           False           True            False           False
BAISDLAFKBM              False           False           False           True            False
ISO793W                  False           False           False           False           True
Application ended. Press <enter> to exit...
*/
```
