using System;
using FluentAssertions;
using KataThirdAttempt;
using TechTalk.SpecFlow;

namespace KataTests
{
    [Binding]
    public class CalculatorBindings
    {
        private int _actualResult;
        private Calculator _calculator;

        [Given(@"A new instance of my calculator")]
        public void GivenANewInstanceOfMyCalculator()
        {
            _calculator = new Calculator();
        }

        [When(@"I press pass an (.*)")]
        public void WhenIPressPassAnOfNumbers(string arbituraryListOfNumbers)
        {
            _actualResult = _calculator.Add(arbituraryListOfNumbers);
        }


        [When(@"the following string is passed to the calculator")]
        public void WhenTheFollowingStringIsPassedToTheCalculator(string listOfNumbers)
        {
            try
            {
                _actualResult = _calculator.Add(listOfNumbers);
            }
            catch (Exception exception)
            {
                ScenarioContext.Current.Add("exception", exception);
            }
        }


        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(string expectedResult)
        {
            _actualResult.ShouldBeEquivalentTo(expectedResult);
        }

        
        [Then(@"an exception should be thrown detailing the negative values")]
        public void ThenAnExcpetionShouldBeThrownDetailingTheNegativeValues()
        {
            var exception = ScenarioContext.Current.Get<Exception>("exception");
            exception.Should().NotBeNull();
            exception.Message.Should().Contain("-5");
        }

    }
}