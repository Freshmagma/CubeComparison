namespace ComparisonCubePrices.AcceptanceTests.StepDefinitions
{
    [Binding]
    public sealed class ComparePricesSteps
    {
        private CubeObjects cubeObject;

        [Given(@"I instantiate a CubeObject")]
        public void GivenTheCubeIsA()
        {
            cubeObject = new CubeObjects();
        }

        [When(@"I call the method GetPriceCubeless(.*)")]
        public void WhenICallTheMethodGetPriceCubeless(string cube)
        {
            var callComparePricesMethods = new ComparePrices();
            cubeObject = callComparePricesMethods.GetPriceCubeLess(cube);
        }

        [When(@"I call the method GetPriceFabitasia(.*)")]
        public void WhenICallTheMethodGetPriceFabitasia(string cube)
        {
            var callComparePricesMethods = new ComparePrices();
            cubeObject = callComparePricesMethods.GetPriceFabitasia(cube);
        }

        [When(@"I call the method GetPriceTheCubicle(.*)")]
        public void WhenICallTheMethodGetPriceTheCubicle(string cube)
        {
            var callComparePricesMethods = new ComparePrices();
            cubeObject = callComparePricesMethods.GetPriceTheCubicle(cube);
        }

        [When(@"get a non existing Cube from (.*)")]
        public void WhenGetANonExistingCubeFromCubeless(string shop)
        {
            var callComparePricesMethods = new ComparePrices();
            if (shop == "Cubeless")
            {
                cubeObject = callComparePricesMethods.GetPriceCubeLess("SomeWeirdNameASDF");
            }
            else if (shop == "Fabitasia")
            {
                cubeObject = callComparePricesMethods.GetPriceFabitasia("SomeWeirdNameASDF");
            }
            else if (shop == "TheCubicle")
            {
                cubeObject = callComparePricesMethods.GetPriceTheCubicle("SomeWeirdNameASDF");
            }
        }

        [Then(@"the seller is Cubeless")]
        public void ThenTheSellerIsCubeless()
        {
            cubeObject.CubeSeller.Should().Be("Cubeless");
        }

        [Then(@"the seller is Fabitasia")]
        public void ThenTheSellerIsFabitasia()
        {
            cubeObject.CubeSeller.Should().Be("Fabitasia");
        }

        [Then(@"the seller is TheCubicle")]
        public void ThenTheSellerIsTheCubicle()
        {
            cubeObject.CubeSeller.Should().Be("TheCubicle");
        }

        [Then(@"the price contains (.*)")]
        public void ThenThePriceContainsTrue(bool number)
        {
            if (number)
            {
                cubeObject.CubePrice.Any(char.IsDigit).Should().BeTrue();
            }
            else
            {
                cubeObject.CubePrice.Any(char.IsDigit).Should().BeFalse();
            }
        }

        [Then(@"shipping time contains (.*)")]
        public void ThenShippingTimeContainsTrue(bool shippingTime)
        {
            if (shippingTime)
            {
                cubeObject.ShippingTime.Should().Contain("Arbeitstage");
            }
            else
            {
                cubeObject.ShippingTime.Should().NotContain("Arbeitstage");
            }
        }

        [Then(@"I get the the message Cube not found")]
        public void ThenIGetTheTheMessageCubeNotFound()
        {
            cubeObject.CubeName.Should().Be("Würfel nicht gefunden");
        }
    }
}