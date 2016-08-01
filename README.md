# SimpleISO7064
C# library that provide ISO 7064 implementations to verify or calculate check characters.

## Installation 
This library can be installed via [NuGet](https://www.nuget.org/packages/SimpleISO7064/) package. Just run the following command:

```powershell
Install-Package SimpleISO7064 -Pre
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

## Usage (Version 1.0.0-rc01)

```csharp

public static void Main(string[] args)
{
	var mod11radix2ValuesToCheck = new[]
	{
		"1011000026831187407",
		"1011000026163915906",
		"1011000028387611302",
		"1011000028387611302",
		"2011000028343021308"
	};
	foreach (var value in mod11radix2ValuesToCheck)
	{
		var mod11Rad2Result = Iso7064.PureSystem.Mod11Radix2.IsValid(value);
		var mod37Rad2Result = Iso7064.PureSystem.Mod37Radix2.IsValid(value);
		Console.WriteLine(
			$"Value: {value} Mod11Rad2Result: {mod11Rad2Result} Mod37Rad2Result: {mod37Rad2Result}");
	}
}

/*
Value: 1011000026831187407 Mod11Rad2Result: True Mod37Rad2Result: False
Value: 1011000026163915906 Mod11Rad2Result: True Mod37Rad2Result: False
Value: 1011000028387611302 Mod11Rad2Result: True Mod37Rad2Result: False
Value: 1011000028387611302 Mod11Rad2Result: True Mod37Rad2Result: False
Value: 2011000028343021308 Mod11Rad2Result: True Mod37Rad2Result: False
*/
```
