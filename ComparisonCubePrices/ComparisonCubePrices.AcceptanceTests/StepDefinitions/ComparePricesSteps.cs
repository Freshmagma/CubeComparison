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
            throw new PendingStepException();
        }

        [Then(@"the price contains (.*)")]
        public void ThenThePriceContainsTrue(bool number)
        {
            throw new PendingStepException();
        }

        [Then(@"shipping time contains (.*)")]
        public void ThenShippingTimeContainsTrue(bool Lieferzeit)
        {
            throw new PendingStepException();
        }

    }
}