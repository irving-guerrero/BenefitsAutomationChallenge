using BenefitsAutomationChallenge.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenefitsAutomationChallenge.StepDefinitions.Benefits
{
    [Binding]
    public class DashboardStepDefinitions : BaseStepDefinition
    {
        [When(@"I Log Out")]
        public void WhenILogOut()
        {
            BenefitsDashboardApp.DashboardPage
                .LogOut();
        }

        [Given(@"an Employer ""([^""]*)""")]
        public void GivenAnEmployer(string employerName)
        {
            if (Enum.TryParse(employerName, out Employeer employer))
            {
                Console.WriteLine($"Employer is: {employer}");
                Employeer = employer;

            }
            else
            {
                throw new Exception($"Employer name: {employerName} is not in Enum Employeer");
            }

        }

        [Given(@"I am on the Benefits Dashboard page")]
        public void GivenIAmOnTheBenefitsDashboardPage()
        {
            BenefitsDashboardApp.LoginPage
                .Navigate()
                .SendCredentials(Employeer)
                .Submit();

            BenefitsDashboardApp.DashboardPage
                .VerifyIsDisplayed();


        }

        [Then(@"benefits dashboard page is displayed")]
        public void ThenBenefitsDashboardPageIsDisplayed()
        {
            BenefitsDashboardApp.DashboardPage
                .VerifyIsDisplayed();
        }

    }
}
