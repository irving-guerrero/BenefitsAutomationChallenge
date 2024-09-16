using AutoFixture;
using BenefitsAutomationChallenge.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Linq;


namespace BenefitsAutomationChallenge.Pages.Benefits
{
    public class DashboardPage
    {

        private WebDriverFactory webDriverFactory;

        private Employee? _employee;
        private Employee? _oldEmployee;
        private IWebElement _editEmployee;
        private IWebElement _deleteEmployee;

        const decimal baseSalaryPerPaycheck = 2000m;
        const int numberOfPaychecksPerYear = 26;
        const decimal benefitsCostPerYear = 1000m;
        const decimal dependentCostPerYear = 500m;

        public DashboardPage(IWebDriver driver)
        {
            webDriverFactory = new WebDriverFactory(driver);
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//a[text()='Log Out']\r\n")]
        public IWebElement LogOutLinnk { get; set; }

        [FindsBy(How = How.Id, Using = "add")]
        public IWebElement AddEmployeeButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div#employeeModal div.modal-content")]
        public IWebElement AddEmployeeModal { get; set; }

        [FindsBy(How = How.Id, Using = "firstName")]
        public IWebElement FirstNameInput { get; set; }

        [FindsBy(How = How.Id, Using = "lastName")]
        public IWebElement lastNameInput { get; set; }

        [FindsBy(How = How.Id, Using = "dependants")]
        public IWebElement dependantsInput { get; set; }

        [FindsBy(How = How.Id, Using = "addEmployee")]
        public IWebElement AddEmployeeModalButton { get; set; }

        [FindsBy(How = How.Id, Using = "updateEmployee")]
        public IWebElement UpdateEmployeeModalButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div table")]
        public IWebElement EmployeesTable { get; set; }


        [FindsBy(How = How.CssSelector, Using = "div#deleteModal div.modal-content")]
        public IWebElement DeleteEmployeeModal { get; set; }

        [FindsBy(How = How.Id, Using = "deleteEmployee")]
        public IWebElement DeleteEmployeeModalButton { get; set; }


        public DashboardPage VerifyIsDisplayed()
        {
            webDriverFactory.WaitForPageLoad();
            Assert.IsTrue(LogOutLinnk.Displayed, "Log Out option should be displayed");
            Assert.IsTrue(AddEmployeeButton.Displayed, "Add button should be dispayed");
            return this;
        }

        public DashboardPage LogOut()
        {
            LogOutLinnk.Click();
            webDriverFactory.WaitForPageLoad();
            return this;
        }

        public DashboardPage AddEmployee()
        {
            AddEmployeeButton.Click();
            webDriverFactory.WaitForElementToBeDIsplayed(AddEmployeeModal);
            return this;
        }

        public DashboardPage UpdateEmployee()
        {
            UpdateEmployeeModalButton.Click();
            webDriverFactory.WaitForElementToDisapear(AddEmployeeModal);
            webDriverFactory.WaitForPageLoad();
            return this;
        }

        public DashboardPage EnterEmployeeDetails()
        {
            AddEmployeeButton.Click();
            webDriverFactory.WaitForElementToBeDIsplayed(AddEmployeeModal);
            return this;
        }
        public DashboardPage EnterEmployeeDetails(Table table)
        {
            var employeeDetails = table.Rows[0];

            FirstNameInput.SendKeys(employeeDetails["FirstName"]);
            lastNameInput.SendKeys(employeeDetails["LastName"]);
            dependantsInput.SendKeys(employeeDetails["Dependents"]);

            SaveEmployee();

            return this;
            
        }

        public DashboardPage EnterEmployeeDetails(string firstName, string lastName, string dependents) 
        {
            Employee employee = new Fixture().Build<Employee>()
                .With(emp => emp.FirstName, firstName )
                .With(emp => emp.LastName, lastName )
                .With(emp => emp.Dependants, string.IsNullOrEmpty(dependents) ? 0 : Convert.ToInt32(dependents) )
                .With(emp => emp.BenefitsCost, string.Empty)
                .Create();

            FirstNameInput.Clear();
            lastNameInput.Clear();
            dependantsInput.Clear();

            FirstNameInput.SendKeys(employee.FirstName);
            lastNameInput.SendKeys(employee.LastName);
            dependantsInput.SendKeys(dependents);

            _employee = employee;
            return this;
        }

        public DashboardPage ValidateAddEmployeeModalRequiredFields()
        {
            string baseMessage = "The <fieldName> field is required.";
            
            Assert.False(AddEmployeeModal.Displayed, "Add employee modal Summary Errors are not displayed");
            
           

            return this;
        }

        public DashboardPage EnterRandomEmployeeDetails()
        {
            if(_employee is not null)
            {
                _oldEmployee = _employee;
            }

            Employee employee = new Fixture().Build<Employee>()
                .With(emp => emp.FirstName, "Random First Name " + new Random().Next().ToString())
                .With(emp => emp.LastName, "Random LAst Name" + new Random().Next().ToString())
                .With(emp => emp.Dependants, new Random().Next(29))
                .With(emp => emp.BenefitsCost, string.Empty)
                .Create();

            FirstNameInput.Clear();
            lastNameInput.Clear();
            dependantsInput.Clear();

            FirstNameInput.SendKeys(employee.FirstName);
            lastNameInput.SendKeys(employee.LastName);
            dependantsInput.SendKeys(employee.Dependants.ToString());

            _employee = employee;
            return this;
        }

        public DashboardPage SaveEmployee()
        {
            AddEmployeeModalButton.Click();

            try
            {
                webDriverFactory.WaitForElementToDisapear(AddEmployeeModal);
                Assert.False(AddEmployeeModal.Displayed, "Add Employee Modal should be closed after adding employee");
            }
            catch (Exception e)
            {

                Assert.False(AddEmployeeModal.Displayed, $"Add Employee Modal should be closed after adding employee '{e.Message}'");
            }

            webDriverFactory.WaitForPageLoad();

            return this;
        }

        private int FillEmployeeData(IWebElement employeeActionElement)
        {
            int retries = 3;
            IList<IWebElement> employeeWebElements = new List<IWebElement>();

            if (employeeActionElement is null)
            {
                webDriverFactory.WaitForElementToBeDIsplayed(EmployeesTable);


                while (retries > 0)  //To handle when stale element
                {
                    try
                    {
                        employeeWebElements = EmployeesTable.FindElements(By.CssSelector("tbody tr"));
                        IWebElement randomRow = employeeWebElements[new Random().Next(employeeWebElements.Count)];
                        IList<IWebElement> cells = randomRow.FindElements(By.CssSelector("td"));

                        if(cells.Count == 1)
                        {
                            return 0;
                        }

                        _employee = new Employee();
                        _employee.Id = cells[0].Text;
                        _employee.LastName = cells[1].Text;
                        _employee.FirstName = cells[2].Text;
                        _employee.Dependants = Convert.ToInt32(cells[3].Text);
                        _employee.Salary = cells[4].Text;
                        _employee.GrossPay = cells[5].Text;
                        _employee.BenefitsCost = cells[6].Text;
                        _employee.NetPay = cells[7].Text;
                        _editEmployee = cells[8].FindElements(By.CssSelector("i")).FirstOrDefault();//.fa-edit"));
                        _deleteEmployee = cells[8].FindElements(By.CssSelector("i")).LastOrDefault();//.fa-edit"));
                    }
                    catch (Exception)
                    {

                        Thread.Sleep(500);
                        employeeWebElements = EmployeesTable.FindElements(By.CssSelector("tbody tr"));
                    }

                    retries--;
                }
            }


            return employeeWebElements.Count;
        }

        private void DeleteAction()
        {
            _deleteEmployee.Click();

            webDriverFactory.WaitForElementToBeDIsplayed(DeleteEmployeeModal);
            webDriverFactory.WaitForElementToBeDIsplayed(DeleteEmployeeModalButton);

            DeleteEmployeeModalButton.Click();

            try
            {
                webDriverFactory.WaitForElementToDisapear(DeleteEmployeeModal);
                Assert.False(DeleteEmployeeModal.Displayed, "Delete Employee Modal should be closed after deleting employee");
            }
            catch (Exception e)
            {

                Assert.False(DeleteEmployeeModal.Displayed, $"Delete Employee Modal should be closed after deleting employee '{e.Message}'");
            }
        }

        public DashboardPage DeleteEmployee()
        {
            IList<IWebElement> employeeWebElements = new List<IWebElement>();

            int retries = 3;
            string textExpected = "No employees found.";

            if(_deleteEmployee is null) 
            {
                int initialEmployeeCount = FillEmployeeData(_deleteEmployee);
                if (initialEmployeeCount > 0)
                {
                    DeleteAction();
                }
                else
                {
                    IWebElement noEmployeeMessageElement = EmployeesTable.FindElement(By.CssSelector("tbody tr td"));

                    Assert.True(noEmployeeMessageElement.Text.Equals(textExpected), $"Actual: {noEmployeeMessageElement.Text} Expected: {textExpected}");
                }
            }
            else
            {
                DeleteAction();
            }

            return this;
        }
        public DashboardPage EditEmployee()
        {
            int retries = 3;

            if (_editEmployee is null) 
            {
                webDriverFactory.WaitForElementToBeDIsplayed(EmployeesTable);


                IList<IWebElement> employeeWebElements = EmployeesTable.FindElements(By.CssSelector("tbody tr"));


                while (retries > 0)  //To handle when stale element
                {
                    try
                    {
                        IWebElement randomRow = employeeWebElements[new Random().Next(employeeWebElements.Count)];
                        IList<IWebElement> cells = randomRow.FindElements(By.CssSelector("td"));

                        _employee = new Employee();
                        _employee.Id = cells[0].Text;
                        _employee.LastName = cells[1].Text;
                        _employee.FirstName = cells[2].Text;
                        _employee.Dependants = Convert.ToInt32(cells[3].Text);
                        _employee.Salary = cells[4].Text;
                        _employee.GrossPay = cells[5].Text;
                        _employee.BenefitsCost = cells[6].Text;
                        _employee.NetPay = cells[7].Text;
                        _editEmployee = cells[8].FindElements(By.CssSelector("i")).FirstOrDefault();//.fa-edit"));
                        _deleteEmployee = cells[8].FindElements(By.CssSelector("i")).LastOrDefault();//.fa-edit"));
                    }
                    catch (Exception)
                    {

                        Thread.Sleep(500);
                        employeeWebElements = EmployeesTable.FindElements(By.CssSelector("tbody tr"));
                    }

                    retries--;
                }
            }


            _editEmployee.Click();
            webDriverFactory.WaitForElementToBeDIsplayed(AddEmployeeModal);
            webDriverFactory.WaitForElementToBeDIsplayed(UpdateEmployeeModalButton);

            return this;
        }

        public DashboardPage VerifyThatEmployeeWasUpdated()
        {
            VerifyThatEmployeeWasSaved();
            Assert.False(isEmployeeInTable(_oldEmployee), $"New record created insted of update existing -> {_oldEmployee.ToString()}");
            return this;
        }

        public DashboardPage VerifyThatEmployeeWasDeleted()
        {
            string text = _employee is not null ? _employee.ToString() : "";

            Assert.False(isEmployeeInTable(_employee), $"Employee not deleted -> {text }");
            return this;
        }

        public DashboardPage VerifyThatEmployeeWasSaved()
        {
            Assert.True(isEmployeeInTable(_employee), $"Employee not saved -> {_employee.ToString()}");

            return this;
        }

        private bool isEmployeeInTable(Employee employee)
        {
            bool employeePresentInTable = false;
            int retries = 3;

            IList<IWebElement> employeeWebElements = EmployeesTable.FindElements(By.CssSelector("tbody tr"));
            IWebElement? resultElement;

            while (retries > 0 && employee is not null)  //To handle when stale element
            {
                try
                {
                    if (string.IsNullOrEmpty(employee.Id)) 
                    {
                        resultElement = employeeWebElements.FirstOrDefault(employeeRow =>
                        {
                            IList<IWebElement> cells = employeeRow.FindElements(By.CssSelector("td"));
                            return (cells.Any(cell => cell.Text == employee.Id));
                        });
                    }
                    else
                    {
                        resultElement = employeeWebElements.FirstOrDefault(employeeRow =>
                        {
                            IList<IWebElement> cells = employeeRow.FindElements(By.CssSelector("td"));

                            if (cells.Any(cell => cell.Text == employee.FirstName)
                                  && cells.Any(cell => cell.Text == employee.LastName)
                                  && cells.Any(cell => cell.Text == employee.Dependants.ToString()))
                            {
                                employeePresentInTable = true;
                                employee.Id = cells[0].Text;
                                employee.Salary = cells[4].Text;
                                employee.GrossPay = cells[5].Text;
                                employee.BenefitsCost = cells[6].Text;
                                employee.NetPay = cells[7].Text;
                                _editEmployee = cells[8].FindElements(By.CssSelector("i")).FirstOrDefault();//.fa-edit"));
                                _deleteEmployee = cells[8].FindElements(By.CssSelector("i")).LastOrDefault();//.fa-edit"));
                                return true;
                            }
                            else
                            {
                                return false;
                            }

                        });

                    }

                    return resultElement is null ? false : true;
                }
                catch (Exception)
                {
                    Thread.Sleep(500);
                    employeeWebElements = EmployeesTable.FindElements(By.CssSelector("tbody tr"));
                }

                retries--;
            }

            return employeePresentInTable;
        }

        public DashboardPage VerifyBenefitCostAreCorrect()
        {

            decimal totalDependentCostPerYear = _employee.Dependants * dependentCostPerYear;

            // Calculate total cost per year
            decimal totalBenefitsCostPerYear = benefitsCostPerYear + totalDependentCostPerYear;

            // Calculate cost per pay check
            decimal totalBenefitsCostPerPaycheck = totalBenefitsCostPerYear / numberOfPaychecksPerYear;
            totalBenefitsCostPerPaycheck = Math.Round(totalBenefitsCostPerPaycheck, 2);

            decimal displayedBenefitsCostPerPaycheck = Convert.ToDecimal(_employee.BenefitsCost);

            Assert.AreEqual(totalBenefitsCostPerPaycheck, displayedBenefitsCostPerPaycheck, $"BEnefit cost is not as expected: {totalBenefitsCostPerPaycheck}, Actual: {displayedBenefitsCostPerPaycheck}");

            return this;
        }

        public DashboardPage VerifyNetPayisCorrect()
        {

            decimal totalDependentCostPerYear = _employee.Dependants * dependentCostPerYear;

            // Calculate total cost per year
            decimal totalBenefitsCostPerYear = benefitsCostPerYear + totalDependentCostPerYear;

            // Calculate cost per pay check
            decimal totalBenefitsCostPerPaycheck = totalBenefitsCostPerYear / numberOfPaychecksPerYear;
            totalBenefitsCostPerPaycheck = Math.Round(Convert.ToDecimal(_employee.GrossPay) - totalBenefitsCostPerPaycheck, 2);

            decimal displayedGrossPayPaycheck = Convert.ToDecimal(_employee.NetPay);

            Assert.AreEqual(totalBenefitsCostPerPaycheck, displayedGrossPayPaycheck, $"BEnefit cost is not as expected: {totalBenefitsCostPerPaycheck}, Actual: {displayedGrossPayPaycheck}");

            return this;
        }


    }

    public record Employee
    {
        public string Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int Dependants { get; set; }
        public string Salary { get; set; }
        public string GrossPay { get; set; }
        public string BenefitsCost { get; set; }
        public string NetPay { get; set; }

        public override string ToString()
        {
            return $"FirstName: {FirstName} LastName: {LastName} Dependents: {Dependants}";
        }

    }
}
