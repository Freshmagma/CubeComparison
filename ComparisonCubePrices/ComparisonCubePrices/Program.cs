using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using ComparisonCubePrices;
using ConsoleTables;

//Console.WriteLine("Hello, World!");
//ComparePrices Compare = new ComparePrices();
//Compare.CompareCubeLess();
Console.WriteLine("------------------------------------");
Console.WriteLine("             Cube");
Console.WriteLine("------------------------------------");

var table = new ConsoleTable("Händler:", "", "","");
table.AddRow("Preis:", "", "", "")
     .AddRow("Lieferzeit:", "", "","");

Console.WriteLine(table);