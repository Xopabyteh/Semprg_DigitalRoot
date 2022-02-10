Console.WriteLine($"Ex: 7 - {GetRoot("16")}");
Console.WriteLine($"Ex: 2 - {GetRoot("29")}");
Console.WriteLine($"Ex: 2 - {GetRoot("493193")}\n");

Console.WriteLine($"Ex: 7 - {GetRootInline("16")}");
Console.WriteLine($"Ex: 2 - {GetRootInline("29")}");
Console.WriteLine($"Ex: 2 - {GetRootInline("493193")}\n");

Console.WriteLine($"Ex: 7 - {GetRootCycle("16")}");
Console.WriteLine($"Ex: 2 - {GetRootCycle("29")}");
Console.WriteLine($"Ex: 2 - {GetRootCycle("493193")}\n");

Console.ReadLine();

//Absolutely not spaghetti code ;)
string GetRootInline(string num) =>
    num.Length == 1
    ? num
    : GetRootInline(
        (from dig in num.ToCharArray() select (int)dig - 48).Sum().ToString()
    );

string GetRoot(string num)
{
    if (num.Length == 1)
    {
        return num;
    }
    //Combine digits
    ulong sum = 0;
    foreach (char digit in num)
    {
        ulong.TryParse(digit.ToString(), out ulong a);
        sum += a;
    }
    return GetRoot(sum.ToString());
}


string GetRootCycle(string num)
{
    while (num.Length != 1)
    {
        int sum = 0;
        foreach (char digit in num)
        {
            sum += (int)char.GetNumericValue(digit);
        }

        num = sum.ToString();
    }
    return num;
}