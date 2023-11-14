using FluentAssertions;
using TFL.Specs.PageObjects;
using System.Runtime.Intrinsics.X86;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.CommonModels;

namespace TFL.Specs.Steps
{
    [Binding]
    public sealed class PlanYourJourneyStepDefinitions
    {
        private readonly PlanYourJourneyPage _planYourJourneyPage;

        public PlanYourJourneyStepDefinitions(PlanYourJourneyPage planYourJourneyPage)
        {
            _planYourJourneyPage = planYourJourneyPage;
        }

        [Given("the user enter plan journey from (.*)")]
        [When(@"the user enter plan journey from (.*)")]
        public void GivenTheUserEnterPlanJourneyFrom(string journeyFrom)
        {
            _planYourJourneyPage.EnterPlanJourneyFrom(journeyFrom);
        }

        [Given("the user enter plan journey to (.*)")]
        [When("the user enter plan journey to (.*)")]
        public void GivenTheUserEnterPlanJourneyTo(string journeyTo)
        {
            _planYourJourneyPage.EnterPlanJourneyTo(journeyTo);
        }
        [When("the user clicks the plan my journey button")]
        public void GivenTheUserClicksThePlanMyJourneyButton()
        {
            _planYourJourneyPage.SubmitPlanMyJourney();
        }

        [When(@"the user clicks the accept all cookies button")]
        public void WhenTheUserClicksTheAcceptAllCookiesButton()
        {
            _planYourJourneyPage.CheckJourneyResultExists();
        }

        [Then(@"the user should verify the results")]
        public void ThenTheUserShouldVerifyTheResults()
        {
            _planYourJourneyPage.CheckJourneyResultExists().Should().BeTrue();
        }

        [Then(@"the user should not see the results")]
        public void ThenTheUserShouldNotSeeTheResults()
        {
            _planYourJourneyPage.CheckJourneyResultExists().Should().BeFalse();           
        }

        [Then(@"the user should see the error as ""([^""]*)""")]
        public void ThenTheUserShouldSeeTheErrorAs(string expectedError)
        {
            _planYourJourneyPage.ValidateErrorMessage(expectedError);
        }

       
        [Given("the user clicks the change time link")]
        public void GivenTheUserClicksTheChangeTimeLink()
        {
            _planYourJourneyPage.ChangeTimeLink();
        }

        [When(@"the user selects the arriving option")]
        public void WhenTheUserSelectsTheArrivingOption()
        {
            _planYourJourneyPage.ArrivingOption();
        }

        [Then(@"the user should see the results as ""([^""]*)""")]
        public void ThenTheUserShouldSeeTheResultsAs(string expectedMessage)
        {
            _planYourJourneyPage.ValidateResults(expectedMessage);
        }

        [When(@"the user clicks edit journey")]
        public void WhenTheUserClicksEditJourney()
        {
            _planYourJourneyPage.EditJourneyLink();
        }

        [When(@"the user clicks the update journey button")]
        public void WhenTheUserClicksTheUpdateJourneyButton()
        {
            _planYourJourneyPage.UpdateJourneyButton();
        }


        [When(@"the user clicks the home")]
        public void WhenTheUserClicksTheHome()
        {
            _planYourJourneyPage.HomeLink();
        }

        [When(@"the user clicks the recents tab")]
        public void WhenTheUserClicksTheRecentsTab()
        {
            _planYourJourneyPage.RecentsTab();
        }


    }
}
