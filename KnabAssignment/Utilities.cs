using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnabAssignment
{
    class Utilities
    {
        public string id { get; set; }
        public string name { get; set; }

        IWebDriver driver;
        public static IEnumerable<String> BrowserToRunWith()
        {
            String[] browsers = BrowserSelection.BrowserToRunWith.Split(',');
            foreach (String b in browsers)
            {
                yield return b;
            }
        }

        public IWebElement explicitWaitForElement(IWebDriver driver, By element, int seconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            wait.Until(drv => drv.FindElement(element));
            return driver.FindElement(element);

        }

        public IWebDriver driverProperties()
        {
            IWebDriver driver = null;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            return driver;
        }

        

        public String GetWebElement(By by)
        {
            try
            {
                driver.FindElement(by);
                return driver.FindElement(by).Text;
            }
            catch (NoSuchElementException e)
            {
                String errorDetails = "No Such Element available" + e;
                return errorDetails;
            }
        }
    }
}
