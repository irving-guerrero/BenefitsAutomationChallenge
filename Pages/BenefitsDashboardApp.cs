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
using BenefitsAutomationChallenge.Pages.Benefits;
using BenefitsAutomationChallenge.Pages.Benefits.Api;

namespace BenefitsAutomationChallenge.Pages
{
    public class BenefitsDashboardApp
    {
        private LoginPage _loginPage;
        private DashboardPage _dashboardPage;
        private Api _api;
        private IWebDriver _driver;

        private const int generalWaitTime = 10;

        public BenefitsDashboardApp()
        {

        }

        public Api Api
        {
            get
            {
                if (_api == null)
                {
                    _api = new Api();
                }
                return _api;
            }
        }

        public LoginPage LoginPage
        {
            get
            {
                if(_driver  is null) 
                {
                    _driver = Utilities.WebDriverManager.GetDriver(); // Usa el driver compartido
                }

                if (_loginPage == null)
                {
                    _loginPage = new LoginPage(_driver);
                }
                return _loginPage;
            }
        }

        public DashboardPage DashboardPage
        {
            get
            {
                if (_driver is null)
                {
                    _driver = Utilities.WebDriverManager.GetDriver(); // Usa el driver compartido
                }

                if (_dashboardPage == null)
                {
                    _dashboardPage = new DashboardPage(_driver);
                }
                return _dashboardPage;
            }
        }

        public void QuitDriver()
        {
            Utilities.WebDriverManager.QuitDriver();
        }



    }
}
