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
        var Object1 = callComparePricesMethods.GetPriceCubeLess(input);
        var Object2 = callComparePricesMethods.GetPriceFabitasia(input);
        var Object3 = callComparePricesMethods.GetPriceCubeLess(input);
        var table = new ConsoleTable("Händler:", Object1.CubeSeller, Object2.CubeSeller, Object3.CubeSeller);
        table.AddRow("Name:", Object1.CubeName, Object2.CubeName, Object3.CubeName)
             .AddRow("Preis:", Object1.CubePrice, Object2.CubePrice, Object3.CubePrice)
             .AddRow("Lieferzeit:", Object1.ShippingTime, Object2.ShippingTime, Object3.ShippingTime);

        Console.WriteLine(table);
    }
}
