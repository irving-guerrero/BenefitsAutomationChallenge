using BenefitsAutomationChallenge.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;

namespace BenefitsAutomationChallenge.StepDefinitions
{
    public abstract class BaseStepDefinition
    {
        protected BenefitsDashboardApp? BenefitsDashboardApp;

        protected static Employeer Employeer {  get; set; }

        protected IWebDriver _driver;


        [BeforeScenario]
        public void SetUp()
        {
            BenefitsDashboardApp = new BenefitsDashboardApp();

        }

        [AfterScenario]
        public void TearDown()
        {
            Utilities.WebDriverManager.QuitDriver();
        }

    }
}
