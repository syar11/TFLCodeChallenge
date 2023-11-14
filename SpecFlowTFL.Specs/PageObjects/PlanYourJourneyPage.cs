using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SpecFlow.Actions.Selenium;
using System;
using System.Linq;
using System.Threading;

namespace TFL.Specs.PageObjects
{
    public class PlanYourJourneyPage
    {

        private const string PageUrl = "http://www.tfl.gov.uk";

        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        private readonly IBrowserInteractions _browserInteractions;
        
        public PlanYourJourneyPage()
        {
            _driver = new ChromeDriver();
            _wait = new WebDriverWait(this._driver, new TimeSpan(0, 0, 20));
        }

        private IWebElement ButtonAcceptCookies => _driver.FindElement(By.XPath("//*[text()='Accept all cookies']/parent::button"));
        private IWebElement PlanJourneyFrom => _driver.FindElement(By.Id("InputFrom"));
        private IWebElement PlanJourneyTo => _driver.FindElement(By.Id("InputTo"));
        private IWebElement PlanJourneyButton => _driver.FindElement(By.Id("plan-journey-button"));
        private int JourneyOptionResultsCount => getElementCount("option-1-content");

        private IWebElement FromError => _driver.FindElement(By.Id("InputFrom-error"));
        private IWebElement ToError => _driver.FindElement(By.Id("InputTo-error"));
        private IWebElement ChangeTime => _driver.FindElement(By.ClassName("change-departure-time"));
        private IWebElement Arriving => _driver.FindElement(By.Id("arriving"));
        private IWebElement JourneyResultSummary => _driver.FindElement(By.ClassName("journey-result-summary"));
        private IWebElement EditJourney => _driver.FindElement(By.ClassName("edit-journey"));
        private IWebElement UpdateJourney => _driver.FindElement(By.XPath("//*[@value='Cancel']/following-sibling::input[@id='plan-journey-button']"));
        private IWebElement Home => _driver.FindElement(By.ClassName("home"));
        private IWebElement Recents => _driver.FindElement(By.XPath("//*[@id='recent-journeys']//a[text()='Recents']"));
        public void Goto()
        {
            _driver.Navigate().GoToUrl(PageUrl);
            _driver.Manage().Window.Maximize();

        }
        public void CloseBrowser()
        {
            _driver.Close();
        }

        public void AcceptAllCookies()
        {
            //_driver.Manage().Cookies.DeleteAllCookies();
            ButtonAcceptCookies.Click();
            Thread.Sleep(2000);
        }

        public void EnterPlanJourneyFrom(string location)
        {
            PlanJourneyFrom.Click();
            PlanJourneyFrom.SendKeys(Keys.Control + "a");
            PlanJourneyFrom.SendKeys(Keys.Delete);
            PlanJourneyFrom.SendKeys(location);
            PlanJourneyFrom.SendKeys(Keys.Tab);
        }

        public void EnterPlanJourneyTo(string location)
        {
            PlanJourneyTo.Click();
            PlanJourneyTo.SendKeys(Keys.Control + "a");
            PlanJourneyTo.SendKeys(Keys.Delete);
            PlanJourneyTo.SendKeys(location);
            PlanJourneyTo.SendKeys(Keys.Tab);
        }

        public void SubmitPlanMyJourney()
        {
            PlanJourneyButton.Click();
        }

        public bool CheckJourneyResultExists()
        {
            if (JourneyOptionResultsCount > 0)
            {
                return true;
            }

            return false;
        }
        public bool CheckJourneyResultNotExists()
        {
            bool t = _driver.FindElement(By.Id("option-1-content")).Displayed;
            if (t)
            {
                return false;
            }
            return true;
        }
        public bool ValidateErrorMessage(string expectedError)
        {
            var fromActualError = FromError.GetAttribute("value");
            var toActualError = ToError.GetAttribute("value");
            if (expectedError.Equals(fromActualError) || expectedError.Equals(toActualError))
            {
                return true;
            }

            return false;
        }
        public void ChangeTimeLink()
        {
            ChangeTime.Click();
        }
        public void ArrivingOption()
        {
            Arriving.Click();
        }

        private int getElementCount(string elementId)
        {
            By elementbyId = By.Id(elementId);
            try
            {
                _wait.Until(drv => drv.FindElement(elementbyId));
                return _driver.FindElements(By.Id(elementId)).Count();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }
        public void EditJourneyLink()
        {
            EditJourney.Click();
        }
        public void UpdateJourneyButton()
        {
            UpdateJourney.Click();
        }
        public void HomeLink()
        {
            Home.Click();
        }
        public void RecentsTab()
        {
            Recents.Click();
        }
        public bool ValidateResults(string expectedResult)
        {
            var actualResult = _driver.FindElement(By.XPath("//*[contains(text(),'" + expectedResult + "')]")).GetAttribute("value");
            if (expectedResult.Equals(actualResult))
            {
                return true;
            }
            return false;
        }

    }
    
}
