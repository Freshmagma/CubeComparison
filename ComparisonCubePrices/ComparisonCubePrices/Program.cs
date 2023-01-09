using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using ComparisonCubePrices;
using ConsoleTables;

Console.WriteLine("------------------------------------");
Console.WriteLine("           Cube Comparison");
Console.WriteLine("------------------------------------");
while (true)
{
    Console.WriteLine("Search for Cube or hit \"L\" for a list of avivable Cubes");
    string input = Console.ReadLine();
    var inputlist = new string[] { "L", "l", "list", "List" };
    var CubeList = new string[] { "Cube", "Cube", "Cube", "Cube" };

    if (inputlist.Contains(input))
    {
        Console.Clear();
        Console.WriteLine("------------------------------------");
        Console.WriteLine("           Cube Comparison");
        Console.WriteLine("------------------------------------");
        foreach (var item in CubeList)
        {
            Console.WriteLine("------------------------------------");
            Console.WriteLine(item);
            Console.WriteLine("------------------------------------");
        }
    }
    else
    {
        Console.Clear();
        Console.WriteLine("Search results for: " + input);
        Console.WriteLine("------------------------------------");
        Console.WriteLine("           Cube Comparison");
        Console.WriteLine("------------------------------------");
        var CubeObject = new CubeObjects();
        var callComparePricesMethods = new ComparePrices();
        //callComparePricesMethods.GetPriceCubeLess(input);
        var table = new ConsoleTable("Händler:", CubeObject.CubeSeller, "", "", "", "", "")
        table.AddRow("Name:", "", CubeObject.CubeName, "")
             .AddRow("Preis:", "", CubeObject.CubePrice, "")
             .AddRow("Lieferzeit:", "", CubeObject.ShippingTime, "");

        Console.WriteLine(table);
    }
}
