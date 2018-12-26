using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedInTestConnections
{
    class NunitTest
    {
        IWebDriver driver;
        [OneTimeSetUp]
        public void IntializeBrowser()
        {
            //create chrome browser instance
            driver = new ChromeDriver();
        }
    }
}
