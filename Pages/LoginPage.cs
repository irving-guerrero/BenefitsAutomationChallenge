using BenefitsAutomationChallenge.Pages.Benefits;
using BenefitsAutomationChallenge.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System.Collections;
using System.Runtime.CompilerServices;

namespace BenefitsAutomationChallenge.Pages
{
    public class LoginPage
    {
        private WebDriverFactory webDriverFactory;

        public LoginPage(IWebDriver driver)
        {
            webDriverFactory = new WebDriverFactory(driver);
            PageFactory.InitElements(driver, this);
        }


        [FindsBy(How = How.Id, Using = "Username")]
        public IWebElement UsernameInput { get; set; }

        [FindsBy(How = How.Id, Using = "Password")]
        public IWebElement PasswordInput { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button[type='submit']")]
        public IWebElement SubmitButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.validation-summary-errors")]
        public IWebElement SummaryErrorsDiv { get; set; }


        public LoginPage Navigate()
        {
            webDriverFactory.driver.Navigate().GoToUrl("https://wmxrwq14uc.execute-api.us-east-1.amazonaws.com/Prod/Account/Login");
            webDriverFactory.WaitForPageLoad();
            webDriverFactory.WaitForElementToBeDIsplayed(UsernameInput);
            webDriverFactory.WaitForElementToBeDIsplayed(PasswordInput);

            return this;
        }

        public LoginPage VerifyIsDisplayed()
        {
            webDriverFactory.WaitForPageLoad();
            Assert.IsTrue(UsernameInput.Displayed, "Username input should be displayed");
            Assert.IsTrue(PasswordInput.Displayed, "Password input should be dispayed");
            return this;
        }

        public LoginPage SendCredentials(string username, string password)
        {
            UsernameInput.SendKeys(username);
            PasswordInput.SendKeys(password);
            return this;
        }

        public LoginPage SendCredentials(Employeer employer)
        {
            string username = string.Empty;
            string password = string.Empty;

            switch (employer)
            {
                case Employeer.Paylocity:
                    username = "TestUser438";
                    password = "!4xAFYaDO.u$";
                    break;
                default:
                    throw new NotImplementedException();
            }

            SendCredentials(username, password);
            return this;
        }

        public LoginPage Submit()
        {
            SubmitButton.Click();
            webDriverFactory.WaitForPageLoad();

            return this;
        }

        public LoginPage ValidateWrongCredentialsError()
        {
            List<IWebElement> summaryErrorList = new List<IWebElement>();
            bool errorIsPResent = false;
            string baseMessage = "The specified username or password is incorrect.";

            try
            {
                summaryErrorList = SummaryErrorsDiv.FindElements(By.CssSelector("ul li")).ToList();
                errorIsPResent = summaryErrorList.Any(elementError => elementError.Text == baseMessage);

                Assert.IsTrue(errorIsPResent, $"Message NOT displayed '{baseMessage}'");
            }
            catch (Exception e)
            {
                Assert.IsTrue(errorIsPResent, $"Message NOT displayed '{baseMessage}' due to '{e.Message}'");
            }

            return this;
        }

        public LoginPage ValidateMaxLeghtLoginRequiredFields(string username, string password)
        {
            Assert.IsTrue(SummaryErrorsDiv.Displayed, "Summary Errors are not displayed");
            List<IWebElement> summaryErrorList = SummaryErrorsDiv.FindElements(By.CssSelector("ul li")).ToList();

            string baseMessage = "The <fieldName> field is required.";

            bool errorIsPResent = false;

            //From documentation
            int maxlength = 50;


            Assert.True(UsernameInput.GetAttribute("value").Length <= maxlength, $"Username text max length is more than {maxlength} as per requirement ");

            //if (username.Length < Convert.ToInt32(UsernameInput.GetAttribute("data-val-length-min")))
            //{
            //    errorIsPResent = summaryErrorList.Any(elementError => elementError.Text == baseMessage.Replace("<fieldName>", UsernameInput.GetAttribute("id")));

            //    Assert.True(errorIsPResent, $"Min length should be {UsernameInput.GetAttribute("data-val-length-min")} actual: {username.Length} ");
            //}
            //else if (username.Length > Convert.ToInt32(UsernameInput.GetAttribute("maxlength")))
            //{
            //    Assert.True(UsernameInput.Text.Length < username.Length, $"Username max length ({username.Length}) > UsernameInput max length ({UsernameInput.GetAttribute("maxlength")})");
            //}

            //if (password.Length < Convert.ToInt32(PasswordInput.GetAttribute("data-val-length-min")))
            //{
            //    errorIsPResent = summaryErrorList.Any(elementError => elementError.Text == baseMessage.Replace("<fieldName>", PasswordInput.GetAttribute("id")));

            //    Assert.True(errorIsPResent, $"Min length should be {PasswordInput.GetAttribute("data-val-length-min")} actual: {password.Length} ");
            //}
            //else if (password.Length > Convert.ToInt32(PasswordInput.GetAttribute("maxlength")))
            //{
            //    Assert.True(PasswordInput.Text.Length < password.Length, $"Password max length ({password.Length}) > PasswordInput max length ({PasswordInput.GetAttribute("maxlength")})");
            //}


            return this;
        }

        public LoginPage ValidateRequiredFields(string username, string password)
        {
            Assert.IsTrue(SummaryErrorsDiv.Displayed, "Summary Errors are not displayed");
            List<IWebElement> summaryErrorList = SummaryErrorsDiv.FindElements(By.CssSelector("ul li")).ToList();

            string baseMessage = "The <fieldName> field is required.";

            Assert.True(SummaryErrorsDiv.Displayed, $"Summary errors are not displayed");


            bool errorIsPResent = summaryErrorList.Any(elementError => elementError.Text == baseMessage.Replace("<fieldName>", UsernameInput.GetAttribute("id")));

            if (username.Length < Convert.ToInt32(UsernameInput.GetAttribute("data-val-length-min")))
            {
                Assert.True(errorIsPResent, $"Error not displayed for empty Username");
            }
            else if (username.Length >= Convert.ToInt32(UsernameInput.GetAttribute("data-val-length-min")) 
                  && username.Length <= Convert.ToInt32(UsernameInput.GetAttribute("maxlength")))
            {
                Assert.False(errorIsPResent, $"Error displayed for valid Username");
            }

            errorIsPResent = summaryErrorList.Any(elementError => elementError.Text == baseMessage.Replace("<fieldName>", PasswordInput.GetAttribute("id")));

            if (password.Length < Convert.ToInt32(PasswordInput.GetAttribute("data-val-length-min")))
            {
                Assert.True(errorIsPResent, $"Error not displayed for empty Password");
            }
            else if (password.Length >= Convert.ToInt32(PasswordInput.GetAttribute("data-val-length-min"))
                  && password.Length <= Convert.ToInt32(PasswordInput.GetAttribute("maxlength")))
            {
                Assert.False(errorIsPResent, $"Error displayed for valid Password");
            }

            return this;
        }

    }
    public enum Employeer
    {
        Paylocity,
    }
}
