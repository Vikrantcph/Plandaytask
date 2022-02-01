using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Plandaytask.Base_Class
{
    public class Connectclass
    {
        public IWebDriver driver;

        [SetUp]
        public void Open()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://test1234.planday.com/");
            Thread.Sleep(3000);

        }
        [TearDown]
        public void Close()
        {
            driver.Quit();

        }
    }
}
