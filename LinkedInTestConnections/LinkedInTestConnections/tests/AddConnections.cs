using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Collections.ObjectModel;
using LinkedInTestConnections.pages;

namespace LinkedInTestConnections
{
    [TestFixture()]
    class AddConnections
    {

       private static IWebDriver driver;
        HomePage hPage;
        DashboardPage dPage;
        SearchResultsPage sPage;

        [SetUp]
        public void IntializeBrowser()
        {
            if (driver == null)
            {
                Console.WriteLine("In Setup......");
                System.Environment.SetEnvironmentVariable("webdriver.chrome.driver", @"LinkedInTestConnections\Files\chromedriver.exe");
                driver = new ChromeDriver();

                hPage = new HomePage(driver);
                dPage = new DashboardPage(driver);
                sPage = new SearchResultsPage(driver);

            }

        }

        [Test, Order(1)]
        public void TestLaunchApplication()
        { 
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.linkedin.com/");
        }

        [Test, Order(2)]
        public void TestLoginIntoApplication()
        { 
            hPage.SetEmail("vjobhunt4124@gmail.com");
            hPage.SetPassword("Happyholiday123");
            hPage.ClickOnSignInButton();
        }

        [Test, Order(3)]
        [TestCase("pooja", "Hi, I would like to connect you to my LinkedIn account")]
        public void TestSearchUsersandAddConnections(String searchName, String noteText)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            dPage.SetSearchText(searchName);
            dPage.ClickOnSearchButton();
            Thread.Sleep(5000);

            IWebElement firstNamein_List =  sPage.GetFirstNameInList();
            js.ExecuteScript("arguments[0].scrollIntoView();", firstNamein_List);
            IList<IWebElement> DisplayedNames_List = driver.FindElements(By.XPath("//span[contains(@class,'actor-name')]"));
            Thread.Sleep(5000);

            for (int i = 0; i < DisplayedNames_List.Count; i++)
            {
                if (DisplayedNames_List[i].Text.ToLower().Contains(searchName))
                {
                    Thread.Sleep(2000);

                    string name = DisplayedNames_List[i].Text;
                    if (sPage.GetMessageButton(name).Text.Contains("Message"))
                    {
                        js.ExecuteScript("arguments[0].scrollIntoView();", driver.FindElement(By.XPath("//span[text()='" + name + "']")));
                        Console.WriteLine("The " + name + " has Message button so skipping it.");
                    }
                    else if (sPage.GetConnectButton(name).Text.Equals("Connect"))
                    {
                        Console.WriteLine("The " + name + " has connect button sending Invitation. ");
                        Thread.Sleep(2000);
                        sPage.ClickOnConnect();
                        sPage.ClickOnAddNote();
                        sPage.SetMessage("Hi, I would like to connect you to my LinkedIn account");
                        sPage.ClickOnSendInvitationButton();
                    }
                }
                DisplayedNames_List = driver.FindElements(By.XPath("//span[contains(@class,'actor-name')]"));
            }
        }


        [Test, Order(4)]
        public void TestLogOut()
        {
            dPage.Logout();
        }

        [OneTimeTearDown]
        public void CloseBrowser()
        {
            driver.Close();
        }


    }
}