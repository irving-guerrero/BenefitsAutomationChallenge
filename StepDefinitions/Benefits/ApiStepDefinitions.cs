using BenefitsAutomationChallenge.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenefitsAutomationChallenge.StepDefinitions.Benefits
{
    [Binding]
    public class ApiStepDefinitions : BaseStepDefinition
    {
        [Given(@"a list of employess")]
        public void GivenAListOfEmployess()
        {
            BenefitsDashboardApp
                .Api.GetEmployees();
        }

        [When(@"I request an employee from employees list")]
        public void WhenIRequestAnEmployeeFromEmployeesList()
        {
            BenefitsDashboardApp
                .Api.GetRandomValidEmployee();
        }

        [When(@"I delete an employee from employees list")]
        public void WhenIDeleteAnEmployeeFromEmployeesList()
        {
            BenefitsDashboardApp
                .Api.DeleteRandomValidEmployee();
        }

        [When(@"I update an employee from employees list")]
        public void WhenIUpdateAnEmployeeFromEmployeesList()
        {
            BenefitsDashboardApp
                .Api.UpdateRandomValidEmployee();
        }
        [Given(@"a random employee")]
        public void GivenARandomEmployee()
        {
            BenefitsDashboardApp
                .Api.SaveAndGenerateRandomEmployee();
        }

        [When(@"I post an employee from employees list")]
        public void WhenIPostAnEmployeeFromEmployeesList()
        {
            BenefitsDashboardApp
                .Api.PostRandomValidEmployee();
        }


    }
}
