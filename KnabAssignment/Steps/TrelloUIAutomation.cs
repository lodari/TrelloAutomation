using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace KnabAssignment.Steps
{
    [Binding]
    class TrelloUIAutomation
    {
        IWebDriver driver;
        int implicitWaitTime = Int32.Parse(ConfigurationManager.AppSettings.Get("ImplicitlyWait"));

        [Given(@"User has loaded the browser and navigated to Trello  home page")]
        public void GivenUserHasLoadedTheBrowserAndNavigatedToTrelloHomePage()
        {
            try
            {
                String browserType = ConfigurationManager.AppSettings.Get("Browser");
                if (browserType == "IE")
                {
                    driver = new InternetExplorerDriver();
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(implicitWaitTime);
                    driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
                    driver.Manage().Window.Maximize();
                }
                else if (browserType == "Chrome")
                {
                    driver = new ChromeDriver();
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(implicitWaitTime);
                    driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
                    driver.Manage().Window.Maximize();
                }
                else
                {
                    driver = new FirefoxDriver();
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(implicitWaitTime);
                    driver.Manage().Window.Maximize();
                }
                driver.Navigate().GoToUrl(ConfigurationManager.AppSettings.Get("Trellohomeurl"));
                String logIn = driver.FindElement(By.XPath("/html/body/div[1]/div[2]/a[1]")).Text;
                StringAssert.AreEqualIgnoringCase("Log In", logIn);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception while Navigating to Trello home page:" + e.ToString());
            }

        }

        [Given(@"logged in to Trello successfully")]
        public void GivenLoggedInToTrelloSuccessfully()
        {
            try { 
            driver.FindElement(By.XPath("/html/body/div[1]/div[2]/a[1]")).Click();
            driver.FindElement(By.CssSelector("#user")).SendKeys(ConfigurationManager.AppSettings.Get("Username"));
            driver.FindElement(By.CssSelector("#password")).SendKeys(ConfigurationManager.AppSettings.Get("Password"));
            driver.FindElement(By.Id("login")).Click();
            }
            catch(ElementNotVisibleException e)
            {
                Console.WriteLine("Exception while identifying the element:" + e.ToString());
            }
        }

        [Given(@"Navigated to the right hand of the screen and clicks on \+ create board button")]
        public void GivenNavigatedToTheRightHandOfTheScreenAndClicksOnCreateBoardButton()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            IWebElement element = wait.Until(condition: ExpectedConditions.ElementToBeClickable(By.CssSelector(".tile__link__3kNHQ")));
            element.Click();
        }

        [Given(@"Provide the board name in the board title section")]
        public void GivenProvideTheBoardNameInTheBoardTitleSection()
        {
            driver.FindElement(By.CssSelector(".subtle-input")).SendKeys(ConfigurationManager.AppSettings.Get("TrelloBoardName"));
        }

        [When(@"User clicks on Create Board button")]
        public void WhenUserClicksOnCreateBoardButton()
        {
            driver.FindElement(By.CssSelector(".primary")).Click();
        }

        [Then(@"Board should be created successfully")]
        public void ThenBoardShouldBeCreatedSuccessfully()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            IWebElement element = wait.Until(condition: ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[2]/div/div[3]/div[2]/div/div[1]/div[1]/a[1]/span")));

            String actualName = driver.FindElement(By.XPath("/html/body/div[2]/div/div[3]/div[2]/div/div[1]/div[1]/a[1]/span")).Text;
            StringAssert.AreEqualIgnoringCase("Employee Onboarding", actualName);

        }

    }
}
