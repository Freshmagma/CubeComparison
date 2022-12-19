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
        public void Compare()
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            webDriver = new ChromeDriver();

            webDriver.Navigate().GoToUrl("https://www.gibz.ch");
        }
    }
}
