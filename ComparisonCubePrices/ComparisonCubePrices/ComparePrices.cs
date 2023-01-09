using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace ComparisonCubePrices
{
    public class CubeObjects
    {
        public string CubeName { get; set; }
        public string ShippingTime { get; set; }
        public string CubePrice { get; set; }
        public string CubeSeller { get; set; }
    }
    public class ComparePrices
    {
        private ChromeDriver webDriver;
        public void CompareCubeLess()
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            webDriver = new ChromeDriver();

            webDriver.Navigate().GoToUrl("https://www.cubeless.ch/?gclid=CjwKCAiAkfucBhBBEiwAFjbkr2Y_H7hj5ZguN7NkNAwZ8Ux6guLJ2SxX9E3JprdqXN1dSdMBKaV1txoCsQkQAvD_BwE");
        }

        public CubeObjects CompareFabitasia()
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            webDriver = new ChromeDriver();

            webDriver.Navigate().GoToUrl("https://fabitasia.ch/");

            var CubeFabitasia = new CubeObjects { CubePrice = "69.420" };
            CubeFabitasia.CubeSeller = "Fabitasia";
            CubeFabitasia.CubeName = "I wanna live up int the Sky!!";
            CubeFabitasia.ShippingTime = "Your Shipping has been cancelled";

            return CubeFabitasia;
        }

        public void CompareDailyPuzzles()
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            webDriver = new ChromeDriver();

            webDriver.Navigate().GoToUrl("https://www.dailypuzzles.com.au/en-ch");
        }

        public void CompareTheCubicle()
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            webDriver = new ChromeDriver();

            webDriver.Navigate().GoToUrl("https://www.thecubicle.com/");
        }
    }
}
