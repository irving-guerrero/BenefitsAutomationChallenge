using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using BenefitsAutomationChallenge.Utilities;

namespace BenefitsAutomationChallenge.Pages.Benefits.Api
{
    public class Api : Shared
    {
        public async void GetEmployees()
        {
            string employeeApiUrl = Configuration["ApiSettings:EmployeeApiUrl"];
            string authToken = Configuration["ApiSettings:AuthToken"];

            var client = new RestClient(employeeApiUrl);

            var request = new RestRequest
            {
                Method = Method.Get
            };

            request.AddHeader("Authorization", authToken);

            try
            {
                RestResponse response = await client.ExecuteAsync(request);

                if (response.IsSuccessful)
                {

                    List<EmployeesResponse>? employees = JsonConvert.DeserializeObject<List<EmployeesResponse>>(response.Content);

                    Console.WriteLine("Respuesta:");
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode} - {response.StatusDescription}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepción: {ex.Message}");
            }
        }
    }
}
