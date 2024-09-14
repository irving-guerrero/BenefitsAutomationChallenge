using BenefitsAutomationChallenge.Pages;

namespace BenefitsAutomationChallenge.StepDefinitions
{
    public abstract class BaseStepDefinition
    {
        protected static BenefitsDashboardApp BenefitsDashboardApp = new BenefitsDashboardApp();

        protected static Employeer Employeer {  get; set; }

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
