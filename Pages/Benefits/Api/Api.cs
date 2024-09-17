using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using BenefitsAutomationChallenge.Utilities;
using AutoFixture;
using NUnit.Framework;

namespace BenefitsAutomationChallenge.Pages.Benefits.Api
{
    public class Api : Shared
    {
        RestClient client;
        RestRequest request;
        private List<EmployeesResponse>? employees;
        private Employee NewRandomEmployee;
        private string employeesApiUrl = Configuration["ApiSettings:EmployeeApiUrl"];
        private string Authorization = Configuration["ApiSettings:AuthToken"];
        private string contentType = Configuration["ApiSettings:ContentType"];

        public Api()
        {
            client = new RestClient(employeesApiUrl);
            request = new RestRequest();
            request.AddHeader("Content-Type", contentType);
            request.AddHeader(nameof(Authorization), Authorization);
        }

        public void SaveAndGenerateRandomEmployee()
        {
            NewRandomEmployee = GenerateRandomEmployeeDetails();
        }

        private RestResponse ExecuteRequest() 
        {
            try
            {
                return client.Execute(request);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepción: {ex.Message}");
                throw;
            }

        }

        public void PostFirstNamezeroLengthEmployee()
        {
            string maxValidTextLength = "123456789 123456789 123456789 123456789 1234567889";

            request.Method = Method.Post;

            // Body creation
            var employeePost = new
            {
                firstName = "",
                lastName = "Random last name" + new Random().Next(),
                dependants = new Random().Next(33)
            };

            Assert.True(employeePost.firstName.Length == 0, "Smaller string needed");

            request.AddJsonBody(employeePost);

            RestResponse response = ExecuteRequest();

            if (response.IsSuccessful)
            {

                EmployeesResponse? employee = JsonConvert.DeserializeObject<EmployeesResponse>(response.Content);

                Console.WriteLine("Respuesta:");
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode} - {response.StatusDescription}");
            }
            Assert.False(response.IsSuccessful, $"APi response not OK cose {response.StatusCode} message '{response.StatusDescription}'");


        }


        public void PostMaxFirstNameMaxLengthEmployee()
        {
            string maxValidTextLength = "123456789 123456789 123456789 123456789 1234567889";

            request.Method = Method.Post;

            // Body creation
            var employeePost = new
            {
                firstName = maxValidTextLength,
                lastName = "Random last name" + new Random().Next(),
                dependants = new Random().Next(33)
            };

            Assert.True(employeePost.firstName.Length == 50, "Smaller string needed");

            request.AddJsonBody(employeePost);

            RestResponse response = ExecuteRequest();

            if (response.IsSuccessful)
            {

                EmployeesResponse? employee = JsonConvert.DeserializeObject<EmployeesResponse>(response.Content);

                Console.WriteLine("Respuesta:");
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode} - {response.StatusDescription}");
            }
            Assert.True(response.IsSuccessful, $"APi response not OK cose {response.StatusCode} message '{response.StatusDescription}'");


        }


        public void PostInvalidFirstNameMaxLengthEmployee()
        {
            string invalidTextLength = "123456789 123456789 123456789 123456789 1234567889 ";

            request.Method = Method.Post;

            // Body creation
            var employeePost = new
            {
                firstName = "Invalid firstname " + invalidTextLength,
                lastName = "Random last name" + new Random().Next(),
                dependants = new Random().Next(33)
            };

            Assert.True(employeePost.firstName.Length > 50, "It is needed a larger string");
            request.AddJsonBody(employeePost);

            try
            {
                RestResponse response = client.Execute(request);

                if (response.IsSuccessful)
                {

                    EmployeesResponse? employee = JsonConvert.DeserializeObject<EmployeesResponse>(response.Content);

                    Console.WriteLine("Respuesta:");
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode} - {response.StatusDescription}");
                }
                Assert.False(response.IsSuccessful, $"APi response not OK cose {response.StatusCode} message '{response.StatusDescription}'");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepción: {ex.Message}");
                throw;
            }

        }

        public void PostInvalidLastNameMaxLengthEmployee()
        {
            string invalidTextLength = "123456789 123456789 123456789 123456789 1234567889 ";

            request.Method = Method.Post;

            // Body creation
            var employeePost = new
            {
                firstName = "Random First name" + new Random().Next(),
                lastName =  "Invalid lastname " + invalidTextLength,
                dependants = new Random().Next(33)
            };

            request.AddJsonBody(employeePost);

            try
            {
                RestResponse response = client.Execute(request);

                if (response.IsSuccessful)
                {

                    EmployeesResponse? employee = JsonConvert.DeserializeObject<EmployeesResponse>(response.Content);

                    Console.WriteLine("Respuesta:");
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode} - {response.StatusDescription}");
                }
                Assert.False(response.IsSuccessful, $"APi response not OK cose {response.StatusCode} message '{response.StatusDescription}'");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepción: {ex.Message}");
                throw;
            }

        }


        public void PostInvalidEmployee()
        {
            string invalidTextLength = "123456789 123456789 123456789 123456789 1234567889 ";

            request.Method = Method.Post;

            // Body creation
            var employeePost = new
            {
                firstName = "Invalid firstname " + invalidTextLength,
                lastName = "Random last name" + new Random().Next(),
                dependants = new Random().Next(33)
            };

            request.AddJsonBody(employeePost);

            try
            {
                RestResponse response = client.Execute(request);

                if (response.IsSuccessful)
                {

                    EmployeesResponse? employee = JsonConvert.DeserializeObject<EmployeesResponse>(response.Content);

                    Console.WriteLine("Respuesta:");
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode} - {response.StatusDescription}");
                }
                Assert.True(response.IsSuccessful, $"APi response not OK cose {response.StatusCode} message '{response.StatusDescription}'");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepción: {ex.Message}");
                throw;
            }

        }

        public void PostRandomValidEmployee() 
        {
            request.Method = Method.Post;

            // Body creation
            var employeePost = new
            {
                firstName = "Random firstname " + new Random().Next(),
                lastName = "Random last name" + new Random().Next(),
                dependants = new Random().Next(33)
            };

            request.AddJsonBody(employeePost);

            try
            {
                RestResponse response = client.Execute(request);

                if (response.IsSuccessful)
                {

                    EmployeesResponse? employee = JsonConvert.DeserializeObject<EmployeesResponse>(response.Content);

                    Console.WriteLine("Respuesta:");
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode} - {response.StatusDescription}");
                }
                Assert.True(response.IsSuccessful, $"APi response not OK cose {response.StatusCode} message '{response.ErrorMessage}'");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepción: {ex.Message}");
                throw;
            }
        }

        public void UpdateInvalidalidEmployee() 
        {
            EmployeesResponse randomEmployee = employees[new Random().Next(employees.Count)];

            request.Method = Method.Put;

            // Body creation
            var employeeUpdate = new
            {
                id = randomEmployee.Id.Replace("-","_"),
                firstName = "New random firstname " + new Random().Next(),
                lastName = "New random last name" + new Random().Next(),
                dependants = new Random().Next(33)
            };

            request.AddJsonBody(employeeUpdate);

            RestResponse response = ExecuteRequest();

            if (response.IsSuccessful)
            {

                EmployeesResponse? employee = JsonConvert.DeserializeObject<EmployeesResponse>(response.Content);

                Console.WriteLine("Respuesta:");
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode} - {response.StatusDescription}");
            }

            Assert.True(response.IsSuccessful, $"APi response not OK cose {response.StatusCode} message '{response.ErrorMessage}'");

        }

        public void UpdateRandomValidEmployee()
        {
            EmployeesResponse randomEmployee = employees[new Random().Next(employees.Count)];

            request.Method = Method.Put;

            // Body creation
            var employeeUpdate = new
            {
                id = randomEmployee.Id,
                firstName = "New random firstname " + new Random().Next(),
                lastName = "New random last name" + new Random().Next(),
                dependants = new Random().Next(33)
            };

            request.AddJsonBody(employeeUpdate);

            try
            {
                RestResponse response = client.Execute(request);

                if (response.IsSuccessful)
                {

                    EmployeesResponse? employee = JsonConvert.DeserializeObject<EmployeesResponse>(response.Content);

                    Console.WriteLine("Respuesta:");
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode} - {response.StatusDescription}");
                }

                Assert.True(response.IsSuccessful, $"APi response not OK cose {response.StatusCode} message '{response.ErrorMessage}'");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepción: {ex.Message}");
                throw;
            }
        }

        public void DeleteRandominvalidEmployee()
        {
            EmployeesResponse randomEmployee = employees[new Random().Next(employees.Count)];
            string employeeApiUrl = employeesApiUrl + $"/{randomEmployee.Id.Replace("-","_")}";

            client = new RestClient(employeeApiUrl);

            request.Method = Method.Delete;

            try
            {
                RestResponse response = client.Execute(request);

                if (response.IsSuccessful)
                {

                    //EmployeesResponse? employee = JsonConvert.DeserializeObject<EmployeesResponse>(response.Content);

                    Console.WriteLine("Respuesta:");
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode} - {response.StatusDescription}");
                }

                Assert.True(response.IsSuccessful, $"APi response not OK {response.StatusCode} message '{response.ErrorMessage}'");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepción: {ex.Message}");
                throw;
            }
        }

        public void DeleteRandomValidEmployee()
        {
            EmployeesResponse randomEmployee = employees[new Random().Next(employees.Count)];
            string employeeApiUrl = employeesApiUrl + $"/{randomEmployee.Id}";

            client = new RestClient(employeeApiUrl);

            request.Method = Method.Delete;

            try
            {
                RestResponse response = client.Execute(request);

                if (response.IsSuccessful)
                {

                    //EmployeesResponse? employee = JsonConvert.DeserializeObject<EmployeesResponse>(response.Content);

                    Console.WriteLine("Respuesta:");
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode} - {response.StatusDescription}");
                }

                Assert.True(response.IsSuccessful, $"APi response not OK cose {response.StatusCode} message '{response.ErrorMessage}'");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepción: {ex.Message}");
                throw;
            }

        }
        public void GetRandomValidEmployee()
        {
            EmployeesResponse randomEmployee = employees[new Random().Next(employees.Count)];
            string employeeApiUrl = employeesApiUrl + $"/{randomEmployee.Id}";

            client = new RestClient(employeeApiUrl);

            request.Method = Method.Get;

            try
            {
                RestResponse response = client.Execute(request);

                if (response.IsSuccessful)
                {

                    EmployeesResponse? employee = JsonConvert.DeserializeObject<EmployeesResponse>(response.Content);

                    Console.WriteLine("Respuesta:");
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode} - {response.StatusDescription}");
                }

                Assert.True(response.IsSuccessful, $"APi response not OK cose {response.StatusCode} message '{response.ErrorMessage}'");


            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepción: {ex.Message}");
                throw;
            }

        }


        public void GetEmployees()
        {
            request.Method = Method.Get;

            try
            {
                RestResponse response = client.Execute(request);

                if (response.IsSuccessful)
                {

                    employees = JsonConvert.DeserializeObject<List<EmployeesResponse>>(response.Content);

                    Console.WriteLine("Respuesta:");
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode} - {response.StatusDescription}");
                }
                Assert.True(response.IsSuccessful, $"APi response not OK cose {response.StatusCode} message '{response.ErrorMessage}'");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepción: {ex.Message}");
                throw;
            }
        }


    }
}
