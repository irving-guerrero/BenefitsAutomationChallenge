using AutoFixture;
using BenefitsAutomationChallenge.Pages.Benefits;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenefitsAutomationChallenge.Utilities
{
    public class Shared
    {
        protected static readonly IConfiguration Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) 
                .AddJsonFile("config.json") 
                .Build();

        protected Employee GenerateRandomEmployeeDetails()
        {

            return new Fixture().Build<Employee>()
                .With(emp => emp.FirstName, "Random First Name " + new Random().Next().ToString())
                .With(emp => emp.LastName, "Random LAst Name" + new Random().Next().ToString())
                .With(emp => emp.Dependants, new Random().Next(33))
                .With(emp => emp.BenefitsCost, string.Empty)
                .Create();
        }
    }
}
