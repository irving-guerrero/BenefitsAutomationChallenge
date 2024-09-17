using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace BenefitsAutomationChallenge.Utilities
{
    public static class WebDriverManager
    {
        private static IWebDriver _driver;

        public static IWebDriver GetDriver()
        {
            if (_driver == null)
            {
                new DriverManager().SetUpDriver(new ChromeConfig());
                var options = new ChromeOptions();

                _driver = new ChromeDriver(options);
                _driver.Manage().Window.Maximize();
            }
            return _driver;
        }

        public static void QuitDriver()
        {
            if (_driver != null)
            {
                _driver.Quit();
                _driver = null;  // Asegúrate de liberar el recurso
            }
        }
    }

}
