# Simple ISO 7064
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

This library directly targets the following frameworks:

* .NET Standard 1.0;
* .NET Standard 2.0;
* .NET Framework 2.0;
* .NET Framework 4.0;
* .NET 5.0;

## Usage

Basic example (using Mod 11 Radix 2 singleton):

```cs
const string value = "101100002683118740";

IIso7064PureSystemProvider provider = Iso7064.PureSystem.Mod11Radix2;

// computes the check digit -> 7
var checkDigit = provider.ComputeCheckDigit(value);

// computes the value with the check digit -> 1011000026831187407
var computed = provider.Compute(value);

// checks if the value is valid -> true
var isValid = provider.IsValid(computed);
```

Out of the box pure systems are available in the `Iso7064.PureSystem` namespace.

```cs
var mod11Radix2 = new Mod11Radix2();
var mod37Radix2 = new Mod37Radix2();
var mod97Radix10 = new Mod97Radix10();
var mod661Radix26 = new Mod661Radix26();
var mod1271Radix36 = new Mod1271Radix36();
```

Since the pure system implementations are thread safe, it is recommended to use the singleton instances available in the `Iso7064.PureSystem` class.

```cs
var mod11Radix2 = Iso7064.PureSystem.Mod11Radix2;
var mod37Radix2 = Iso7064.PureSystem.Mod37Radix2;
var mod97Radix10 = Iso7064.PureSystem.Mod97Radix10;
var mod661Radix26 = Iso7064.PureSystem.Mod661Radix26;
var mod1271Radix36 = Iso7064.PureSystem.Mod1271Radix36;
```

You can also create your own pure systems either by creating a new instance of `Iso7064PureSystemProvider`, using the
builder method provided by the `Iso7064Factory` class or by implementing the `IIso7064PureSystemProvider` interface.

```cs
// using the constructor
var provider = new Iso7064PureSystemProvider(11, 2, false, "0123456789X");

// using the factory
var provider = Iso7064.Factory.Get(11, 2, false, "0123456789X");
```