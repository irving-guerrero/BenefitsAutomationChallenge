using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenefitsAutomationChallenge.Utilities
{
    public class WebDriverFactory
    {
        private IWebDriver driver;
        private WebDriverWait _webDriverWait;
        private const int generalWaitTime = 10;

        public WebDriverFactory(IWebDriver driver)
        {
            this.driver = driver;
            _webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(generalWaitTime));
        }

        public void WaitForPageLoad()
        {
            _webDriverWait.Until(driver => ((IJavaScriptExecutor)driver)
                .ExecuteScript("return document.readyState").Equals("complete"));
        }

        public void WaitForElementToBeDIsplayed(IWebElement element)
        {
            _webDriverWait.Until(driver => element.Displayed);
        }

    }
}
