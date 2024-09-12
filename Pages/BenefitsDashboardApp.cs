using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace BenefitsAutomationChallenge.Pages
{
    public class BenefitsDashboardApp
    {
        private LoginPage _loginPage;
        private IWebDriver _driver;

        private const int generalWaitTime = 10;

        public BenefitsDashboardApp()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            var options = new ChromeOptions();

            _driver = new ChromeDriver(options);
            _driver.Manage().Window.Maximize();
        }

        public LoginPage LoginPage
        {
            get
            {
                if (_loginPage == null)
                {
                    _loginPage = new LoginPage(_driver);
                }
                return _loginPage;
            }
        }
        public void QuitDriver()
        {
            _driver.Quit();
        }
    }
}
