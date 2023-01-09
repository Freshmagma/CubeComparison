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

        public CubeObjects GetPriceCubeLess(string cubeName)
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
            webDriver.FindElement(By.XPath("//div[@id='content_col']/div/div/div/div[@class='searchresult-panel items']/a")).Click();
            Thread.Sleep(5000);

            CubeCubeLess.CubePrice = webDriver.FindElement(By.XPath("//div[@id='pricebox']/div/p")).Text;
            CubeCubeLess.CubeSeller = "Cubeless";
            CubeCubeLess.CubeName = cubeName;

            return CubeCubeLess;
        }

        public CubeObjects GetPriceFabitasia(string cubeName)
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            webDriver = new ChromeDriver();
            Actions act = new Actions(webDriver);
            var CubeFabitasia = new CubeObjects();

            webDriver.Navigate().GoToUrl("https://fabitasia.ch/");
            webDriver.FindElement(By.XPath("//form[@id='RemoteSearch1']/div/div/div/input")).SendKeys(cubeName);
            act.MoveToElement(webDriver.FindElement(By.XPath("//form[@id='RemoteSearch1']/div/div/div/button"))).Click().Perform();
            Thread.Sleep(5000);
            webDriver.FindElement(By.XPath("//div[@id='RemoteSearchResults']/div[@class='HotDealList']/table/tbody/tr/td/div/h3/a")).Click();
            Thread.Sleep(5000);

            CubeFabitasia.CubePrice = webDriver.FindElement(By.XPath("//div[@class='Price']/span/span[2]")).Text;
            CubeFabitasia.CubeSeller = "Fabitasia";
            CubeFabitasia.CubeName = cubeName;

            return CubeFabitasia;
        }

        public CubeObjects GetPriceTheCubicle(string cubeName)
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            webDriver = new ChromeDriver();
            Actions act = new Actions(webDriver);
            var CubeTheCubicle = new CubeObjects();

            webDriver.Navigate().GoToUrl("https://www.thecubicle.com/");
            webDriver.FindElement(By.XPath("//input[@id='desktopSearchBar']")).SendKeys(cubeName);
            act.MoveToElement(webDriver.FindElement(By.XPath("//button[@class='search-bar--submit']"))).Click().Perform();
            Thread.Sleep(5000);
            webDriver.FindElement(By.XPath("//a[@class='product-grid-item']")).Click();
            Thread.Sleep(5000);

            CubeTheCubicle.CubePrice = webDriver.FindElement(By.XPath("//span[@id='productPrice-product-template']/span[@class='visually-hidden']")).Text;
            CubeTheCubicle.CubeSeller = "TheCubicle";
            CubeTheCubicle.CubeName = cubeName;

            return CubeTheCubicle;
        }
    }
}
