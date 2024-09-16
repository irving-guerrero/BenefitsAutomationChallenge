using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenefitsAutomationChallenge.Pages.Benefits.Api
{
    public class EmployeesResponse
    {
        public string PartitionKey { get; set; }
        public string SortKey { get; set; }
        public string Username { get; set; }
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Dependants { get; set; }
        public DateTime Expiration { get; set; }
        public decimal Salary { get; set; }
        public decimal Gross { get; set; }
        public decimal BenefitsCost { get; set; }
        public decimal Net { get; set; }
    }
}
