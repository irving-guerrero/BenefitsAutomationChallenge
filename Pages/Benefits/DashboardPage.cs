using BenefitsAutomationChallenge.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenefitsAutomationChallenge.Pages.Benefits
{
    public class DashboardPage
    {
        private IWebDriver driver;
        private WebDriverFactory webDriverFactory;

        public DashboardPage(IWebDriver driver)
        {
            webDriverFactory = new WebDriverFactory(driver);

            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//a[text()='Log Out']\r\n")]
        public IWebElement LogOutLinnk { get; set; }

        [FindsBy(How = How.Id, Using = "add")]
        public IWebElement AddButton { get; set; }

        public DashboardPage VerifyIsDisplayed()
        {
            webDriverFactory.WaitForPageLoad();
            Assert.IsTrue(LogOutLinnk.Displayed, "Log Out option should be displayed");
            Assert.IsTrue(AddButton.Displayed, "Add button should be dispayed");
            return this;
        }

        public DashboardPage LogOut()
        {
            LogOutLinnk.Click();
            webDriverFactory.WaitForPageLoad();
            return this;
        }

    }

}
