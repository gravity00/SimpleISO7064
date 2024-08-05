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
