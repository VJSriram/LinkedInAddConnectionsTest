using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LinkedInTestConnections.pages
{
    class DashboardPage

    {

        private readonly IWebDriver driver;
        public DashboardPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void SetSearchText(String searchtext)
        {
            IWebElement searchBox_Input = driver.FindElement(By.XPath("//*[@id='nav-search-artdeco-typeahead']//input"));
            searchBox_Input.SendKeys(searchtext);
          
        }

        public void ClickOnSearchButton()
        {
            IWebElement searchBox_SearchIcon = driver.FindElement(By.XPath("(//li-icon[@type='search-icon'])[1]"));
            searchBox_SearchIcon.Click();
            Thread.Sleep(5000);

        }

        public void Logout()
        {
            IWebElement me_DropDown = driver.FindElement(By.XPath("//button[@id='nav-settings__dropdown-trigger']/div[@class='nav-item__title-container']/span[contains(@class,'nav-item__dropdown-trigger--icon')]"));

            me_DropDown.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5000);

            IWebElement signOut_Link = driver.FindElement(By.XPath("//a[@data-control-name='nav.settings_signout']"));

            signOut_Link.Click();
        }

            
    }
}
