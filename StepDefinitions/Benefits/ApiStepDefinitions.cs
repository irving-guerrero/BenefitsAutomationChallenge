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

        [When(@"I delete a non valid employee")]
        public void WhenIDeleteANonValidEmployee()
        {
            BenefitsDashboardApp
                .Api.DeleteRandominvalidEmployee();
        }


        [When(@"I update an employee from employees list")]
        public void WhenIUpdateAnEmployeeFromEmployeesList()
        {
            BenefitsDashboardApp
                .Api.UpdateRandomValidEmployee();
        }

        [When(@"I update a non valid employee")]
        public void WhenIUpdateANonValidEmployee()
        {
            BenefitsDashboardApp
                .Api.UpdateInvalidalidEmployee();
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

        [When(@"I post a non valid employee")]
        public void WhenIPostANonValidEmployee()
        {
            BenefitsDashboardApp
                .Api.PostInvalidEmployee();
        }

        [When(@"I post invalid firstname max length")]
        public void WhenIPostInvalidFirstnameMaxLength()
        {
            BenefitsDashboardApp
                .Api.PostInvalidFirstNameMaxLengthEmployee();
        }

        [When(@"I post max firstname max length")]
        public void WhenIPostMaxFirstnameMaxLength()
        {
            BenefitsDashboardApp
                .Api.PostMaxFirstNameMaxLengthEmployee();
        }

        [When(@"I post firstname empty")]
        public void WhenIPostFirstnameEmpty()
        {
            BenefitsDashboardApp
                .Api.PostFirstNamezeroLengthEmployee();
        }


    }
}
