using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LinkedInTestConnections.pages
{
    class HomePage
    {
     
  private readonly  IWebDriver driver;
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void SetEmail(String Email)
        {
            IWebElement userName_Input = driver.FindElement(By.XPath("//input[@id='login-email']"));
            userName_Input.SendKeys(Email);
        }

        public void SetPassword(String Password)
        {
            IWebElement passWord_Input = driver.FindElement(By.XPath("//input[@id='login-password']"));
            passWord_Input.SendKeys(Password);
        }

        public void ClickOnSignInButton()
        {
            IWebElement signIn_Button = driver.FindElement(By.XPath("//input[@id='login-submit']"));
            signIn_Button.Click();
            Thread.Sleep(5000);
        }
    }
}
