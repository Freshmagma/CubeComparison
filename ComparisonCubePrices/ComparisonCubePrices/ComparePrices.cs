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
            try
            {
                webDriver.FindElement(By.XPath("//div[@id='content_col']/div/div/div/div[@class='searchresult-panel items']/a")).Click();

                CubeCubeLess.CubePrice = webDriver.FindElement(By.XPath("//div[@id='pricebox']/div/p")).Text;

                CubeCubeLess.CubeName = webDriver.FindElement(By.XPath("//div[@id='primary']/h1")).Text;
                CubeCubeLess.ShippingTime = webDriver.FindElement(By.XPath("//div[@id='pricebox']/div/div/p[2]")).Text.Replace("Lieferzeit: ", "");

                if (string.IsNullOrEmpty(CubeCubeLess.ShippingTime))
                {
                    CubeCubeLess.ShippingTime = "Nicht verfügbar";
                }
            }
            catch
            {
                CubeCubeLess.CubeName = "Würfel nicht gefunden";
                CubeCubeLess.CubePrice = "";
                CubeCubeLess.ShippingTime = "";
            }
            CubeCubeLess.CubeSeller = "Cubeless";

            webDriver.Quit();
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
            try
            {
                webDriver.FindElement(By.XPath("//div[@id='RemoteSearchResults']/div[@class='HotDealList']/table/tbody/tr/td/div/h3/a")).Click();

                try
                {
                    CubeFabitasia.CubePrice = webDriver.FindElement(By.XPath("//div[@class='Price']/span/span[2]")).Text + " " + webDriver.FindElement(By.XPath("//div[@class='Price']/span/span[1]")).Text;
                }
                catch
                {
                    CubeFabitasia.CubePrice = "Unbekannt";
                    CubeFabitasia.ShippingTime = "Nicht verfügbar";
                }
                CubeFabitasia.CubeName = webDriver.FindElement(By.XPath("//div[@class='InfoArea New']/h1")).Text;

                if (CubeFabitasia.ShippingTime != "Nicht verfügbar")
                {
                    CubeFabitasia.ShippingTime = "Unbekannt";
                }
            }
            catch
            {
                CubeFabitasia.CubeName = "Würfel nicht gefunden";
                CubeFabitasia.CubePrice = "";
                CubeFabitasia.ShippingTime = "";
            }
            CubeFabitasia.CubeSeller = "Fabitasia";

            webDriver.Quit();
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
            try
            {
                webDriver.FindElement(By.XPath("//a[@class='product-grid-item']")).Click();

                CubeTheCubicle.CubePrice = webDriver.FindElement(By.XPath("//span[@id='productPrice-product-template']/span[@class='visually-hidden']")).Text;

                CubeTheCubicle.CubeName = webDriver.FindElement(By.XPath("//div[@id='ProductSection']/div/div/h1")).Text;
                CubeTheCubicle.ShippingTime = "Unbekannt";
            }
            catch
            {
                CubeTheCubicle.CubeName = "Würfel nicht gefunden";
                CubeTheCubicle.CubePrice = "";
                CubeTheCubicle.ShippingTime = "";
            }
            CubeTheCubicle.CubeSeller = "TheCubicle";

            webDriver.Quit();
            return CubeTheCubicle;
        }
    }
}
