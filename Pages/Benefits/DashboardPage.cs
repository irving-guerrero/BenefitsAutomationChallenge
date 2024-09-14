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

        private Employee _employee;

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

        [FindsBy(How = How.CssSelector, Using = "div table")]
        public IWebElement EmployeesTable { get; set; }


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

        public DashboardPage EnterEmployeeDetails()
        {
            AddEmployeeButton.Click();
            webDriverFactory.WaitForElementToBeDIsplayed(AddEmployeeModal);
            return this;
        }
        public DashboardPage EnterEmployeeDetails(Table table)
        {
            Employee employee = new Employee();
            var employeeDetails = table.Rows[0];

            FirstNameInput.SendKeys(employeeDetails["FirstName"]);
            lastNameInput.SendKeys(employeeDetails["LastName"]);
            dependantsInput.SendKeys(employeeDetails["Dependents"]);

            SaveEmployee();

            return this;
            
        }

        public DashboardPage EnterRandomEmployeeDetails()
        {
            Employee employee = new Fixture().Build<Employee>()
                .With(emp => emp.FirstName, "Random First Name "  + new Random().Next().ToString())
                .With(emp => emp.LastName, "Random LAst Name" + new Random().Next().ToString())
                .With(emp => emp.Dependants, new Random().Next(29) )
                .Create();

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

        public DashboardPage VerifyThatEmployeeWasSaved()
        {

            bool employeePresentInTable = false;
            int retries = 3;

            IList<IWebElement> employeeWebElements = EmployeesTable.FindElements(By.CssSelector("tbody tr"));


            while (retries > 0)  //To handle when stale element
            {
                try
                {
                    foreach (IWebElement employeeWebElement in employeeWebElements)
                    {
                        IList<IWebElement> cells = employeeWebElement.FindElements(By.CssSelector("td"));

                        bool isFirstNamePresent = cells.Any(cell => cell.Text == _employee.FirstName);
                        bool isLastNamePresent = cells.Any(cell => cell.Text == _employee.LastName);
                        bool isDependentPresent = cells.Any(cell => cell.Text == _employee.Dependants.ToString());

                        if (isFirstNamePresent && isLastNamePresent && isDependentPresent)
                        {
                            employeePresentInTable = true;
                            break;
                        }
                    }
                }
                catch (Exception)
                {
                    Thread.Sleep(500);
                    employeeWebElements = EmployeesTable.FindElements(By.CssSelector("tbody tr"));

                }
                if (employeePresentInTable) {
                    break;
                }
                retries--;
            }

            Assert.True( employeePresentInTable, $"Employee not saved -> {_employee.ToString()}");

            return this;
        }

    }

    public record Employee
    {
        public string FirstName { get; init; }
        public string LastName { get; set; }
        public int Dependants { get; set; }

        public override string ToString()
        {
            return $"FirstName: {FirstName} LastName: {LastName} Dependents: {Dependants}";
        }

    }
}
