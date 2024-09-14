using BenefitsAutomationChallenge.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenefitsAutomationChallenge.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions : BaseStepDefinition
    {

        [Given(@"I am on the Benefits Dashboard login page")]
        public void GivenIAmOnTheBenefitsDashboardLoginPage()
        {
            BenefitsDashboardApp.LoginPage
                .Navigate();
        }

        [When(@"I enter username ""([^""]*)"" and password ""([^""]*)""")]
        public void WhenIEnterUsernameAndPassword(string username, string password)
        {
            BenefitsDashboardApp.LoginPage
                .SendCredentials(username, password);
        }

        [When(@"I click on log in button")]
        public void WhenIClickOnLogInButton()
        {
            BenefitsDashboardApp.LoginPage
                .Submit();
        }

        [Then(@"username ""([^""]*)"" and password ""([^""]*)"" are required")]
        public void ThenUsernameAndPasswordAreRequired(string username, string password)
        {
            BenefitsDashboardApp.LoginPage
                .ValidateRequiredFields(username, password);
        }

        [Then(@"username ""([^""]*)"" and password ""([^""]*)"" have min and max Length")]
        public void ThenUsernameAndPasswordHaveMinAndMaxLength(string username, string password)
        {
            BenefitsDashboardApp.LoginPage
                .ValidateMinMaxLeghtRequiredFields(username, password);
        }

        [Then(@"bad credentials error message should be displayed")]
        public void ThenBadCredentialsErrorMessageShouldBeDisplayed()
        {
            BenefitsDashboardApp.LoginPage
                .ValidateWrongCredentialsError();
        }


        [Then(@"benefits dashboard login page is displayed")]
        public void ThenBenefitsDashboardLoginPageIsDisplayed()
        {
            BenefitsDashboardApp.LoginPage
                .VerifyIsDisplayed();
        }

    }
}
