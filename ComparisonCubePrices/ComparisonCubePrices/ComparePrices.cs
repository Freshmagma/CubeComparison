using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace ComparisonCubePrices
{
    public class ComparePrices
    {
        private ChromeDriver webDriver;

        public void CompareCubeLess()
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            webDriver = new ChromeDriver();

            webDriver.Navigate().GoToUrl("https://www.cubeless.ch/?gclid=CjwKCAiAkfucBhBBEiwAFjbkr2Y_H7hj5ZguN7NkNAwZ8Ux6guLJ2SxX9E3JprdqXN1dSdMBKaV1txoCsQkQAvD_BwE");
        }

        public void CompareFabitasia()
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            webDriver = new ChromeDriver();

            webDriver.Navigate().GoToUrl("https://fabitasia.ch/");
        }
    }
}
