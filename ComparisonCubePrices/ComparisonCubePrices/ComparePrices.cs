using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
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

        public void GetPriceCubeLess(string cubeName)
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            webDriver = new ChromeDriver();
            Actions act = new Actions(webDriver);
            var CubeCubeLess = new CubeObjects();

            webDriver.Navigate().GoToUrl("https://www.cubeless.ch/");
            act.MoveToElement(webDriver.FindElement(By.XPath("//div[@id='search_typeahead']/div/form/div/button"))).Click().Perform();
            webDriver.FindElement(By.XPath("//div[@id='search_typeahead']/div/form/div/input")).SendKeys(cubeName);
            act.MoveToElement(webDriver.FindElement(By.XPath("//div[@id='search_typeahead']/div/form/div/button"))).Click().Perform();
            Thread.Sleep(5000);
            webDriver.FindElement(By.XPath("//div[@id='content_col']/div/div/div/div/a")).Click();
            Thread.Sleep(5000);

            CubeCubeLess.CubePrice = webDriver.FindElement(By.XPath("//div[@id='pricebox']/div/p")).Text;
            CubeCubeLess.CubeSeller = "Cubeless";
            CubeCubeLess.CubeName = cubeName;
        }

        public void GetPriceFabitasia(string cubeName)
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            webDriver = new ChromeDriver();
            Actions act = new Actions(webDriver);
            var CubeFabitasia = new CubeObjects();

            webDriver.Navigate().GoToUrl("https://fabitasia.ch/");
            //act.MoveToElement(webDriver.FindElement(By.XPath("//div[@id='search_typeahead']/div/form/div/button"))).Click().Perform();
            webDriver.FindElement(By.XPath("//form[@id='RemoteSearch1']/div/div/div/input")).SendKeys(cubeName);
            act.MoveToElement(webDriver.FindElement(By.XPath("//form[@id='RemoteSearch1']/div/div/div/button"))).Click().Perform();
            Thread.Sleep(5000);
            webDriver.FindElement(By.XPath("//div[@id='RemoteSearchResults']/div[@class='HotDealList']/table/tbody/tr/td/div/h3/a")).Click();
            Thread.Sleep(5000);

            CubeFabitasia.CubePrice = webDriver.FindElement(By.XPath("//div[@class='Price']/span/span[2]")).Text;
            CubeFabitasia.CubeSeller = "Fabitasia";
            CubeFabitasia.CubeName = cubeName;
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
