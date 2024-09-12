using BenefitsAutomationChallenge.Pages;

namespace BenefitsAutomationChallenge.StepDefinitions
{
    public abstract class BaseStepDefinition
    {
        protected BenefitsDashboardApp BenefitsDashboardApp = new BenefitsDashboardApp();

        [BeforeScenario]
        public void SetUp()
        {
        }

        [AfterScenario]
        public void TearDown()
        {
            BenefitsDashboardApp.QuitDriver();
        }
    }
}
