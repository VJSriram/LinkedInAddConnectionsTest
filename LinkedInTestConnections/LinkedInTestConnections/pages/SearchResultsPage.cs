using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LinkedInTestConnections.pages
{
    class SearchResultsPage
    {

        private readonly IWebDriver driver;
      

        public SearchResultsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ClickOnConnect()
        {

            ReadOnlyCollection<IWebElement> connects = driver.FindElements(By.XPath("//button[contains(@aria-label,'Connect')]"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click();", connects.First());

            Thread.Sleep(5000);
        }

        public void SetMessage(String message)
        {

            IWebElement note_InputBox = driver.FindElement(By.Id("custom-message"));
            note_InputBox.SendKeys(message);
            Thread.Sleep(2000);
        }

        public void ClickOnAddNote()
        {
            IWebElement addNote_Button = driver.FindElement(By.XPath("//div[@class='send-invite__actions']/button[contains(@class,'button-secondary-large')]"));
            addNote_Button.Click();
            Thread.Sleep(2000);
        }

        public void ClickOnSendInvitationButton()
        {
            IWebElement sendInvitation_Button = driver.FindElement(By.XPath("//div[@class='send-invite__actions']/button[contains(@class,'button-primary-large')]"));
            sendInvitation_Button.Click();
            Thread.Sleep(2000);

        }

        public IWebElement GetFirstNameInList()
        {
          
            IWebElement firstNamein_List = driver.FindElement(By.XPath("(//span[contains(@class,'actor-name')])[1]"));
            return firstNamein_List;
        }

        public void scrollDownInSearchResultsPage(IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView();", element);
        }

        public IWebElement GetMessageButton(String name)
        {
           IWebElement element =  driver.FindElement(By.XPath("//span[text()='" + name + "']/ancestor::div[contains(@class,'search-result__info')]/following-sibling::div"));
            return element;
        }

        public IWebElement GetConnectButton(String name)
        {
            IWebElement element = driver.FindElement(By.XPath("//span[text()='" + name + "']/ancestor::div[contains(@class,'search-result__info')]/following-sibling::div//button"));
            return element;
        }
    }
}
