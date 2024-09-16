using AutoFixture;
using BenefitsAutomationChallenge.Pages;
using BenefitsAutomationChallenge.Pages.Benefits;
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
                .VerifyIsDisplayed()
                .LogOut();
        }

        [When(@"I select Add Employee")]
        public void WhenISelectAddEmployee()
        {
            BenefitsDashboardApp.DashboardPage
                .AddEmployee();
        }

        [Then(@"I should be able to enter employee details")]
        public void ThenIShouldBeAbleToEnterEmployeeDetails()
        {
            BenefitsDashboardApp.DashboardPage
                .EnterRandomEmployeeDetails();

        }

        [Then(@"the employee should save")]
        public void ThenTheEmployeeShouldSave()
        {
            BenefitsDashboardApp.DashboardPage
                .SaveEmployee();
        }

        [Then(@"I should see the employee in the table")]
        public void ThenIShouldSeeTheEmployeeInTheTable()
        {
            BenefitsDashboardApp.DashboardPage
                .VerifyThatEmployeeWasSaved();
        }

        [When(@"I select the Action Edit")]
        public void WhenISelectTheActionEdit()
        {
            BenefitsDashboardApp.DashboardPage
                .EditEmployee();
        }

        [When(@"I select the Action X")]
        public void WhenISelectTheActionX()
        {
            BenefitsDashboardApp.DashboardPage
                .DeleteEmployee();
        }


        [Then(@"I can edit employee details")]
        public void ThenICanEditEmployeeDetails()
        {
            BenefitsDashboardApp.DashboardPage
                .EnterRandomEmployeeDetails()
                .UpdateEmployee();
        }

        [Then(@"the data should change in the table")]
        public void ThenTheDataShouldChangeInTheTable()
        {
            BenefitsDashboardApp.DashboardPage
                .VerifyThatEmployeeWasUpdated();
        }

        [Then(@"the employee should be deleted")]
        public void ThenTheEmployeeShouldBeDeleted()
        {
            BenefitsDashboardApp.DashboardPage
                .VerifyThatEmployeeWasDeleted();
        }

        [Then(@"the benefit cost calculations are correct")]
        public void ThenTheBenefitCostCalculationsAreCorrect()
        {
            BenefitsDashboardApp.DashboardPage
                .VerifyBenefitCostAreCorrect();

        }



        [Then(@"I add a new employee with the following details:")]
        public void ThenIAddANewEmployeeWithTheFollowingDetails(Table table)
        {
            BenefitsDashboardApp.DashboardPage
                .EnterEmployeeDetails(table);
        }

        [Then(@"I enter random employee data")]
        public void ThenIEnterRandomEmployeeData()
        {
            BenefitsDashboardApp.DashboardPage
                .EnterRandomEmployeeDetails();
        }



    }
}
