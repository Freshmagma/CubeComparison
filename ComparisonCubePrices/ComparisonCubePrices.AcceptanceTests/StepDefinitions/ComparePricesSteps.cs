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

        [Then(@"the seller is Cubeless")]
        public void ThenTheSellerIsCubeless()
        {
            cubeObject.CubeSeller.Should().Be("Cubeless");
        }

        [Then(@"the price contains (.*)")]
        public void ThenThePriceContainsTrue(bool number)
        {
            if(number)
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

    }
}