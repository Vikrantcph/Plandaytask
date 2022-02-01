using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using Plandaytask.Base_Class;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;


namespace Plandaytask
{


    [TestFixture]

    public class PlandayTest : Connectclass
    {
        private static void GreenMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void Redmessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }


        public class Tests : Connectclass

        {
            ExtentReports Extent = null;

            [OneTimeSetUp]
            public void ExtentReportOpen()
            {
                Extent = new ExtentReports();
                var htmlReporter = new ExtentHtmlReporter("C:\\Users\\45916\\source\\repos\\Plandaytask\\Plandaytask\\Base Class\\Extent Reports\\index.html");
                Extent.AttachReporter(htmlReporter);


            }
            [OneTimeTearDown]
            public void ExtentReportclose()
            {
                Extent.Flush();

            }


            [Test, Category("Login Page Tests"), Order(1)]

            public void LoginFormElements()
            {
                ExtentTest Testreport;


                Testreport = Extent.CreateTest("CookieConsent Test").Info("Test Started:");
                Testreport.Log(Status.Info, "Chrome browser is launched");


                IWebElement Cookie_consent = driver.FindElement(By.Id("cookie-consent-button"));
                IWebElement Username = driver.FindElement(By.Id("Username"));
                IWebElement Password = driver.FindElement(By.Id("Password"));
                IWebElement Loginbtn = driver.FindElement(By.Id("MainLoginButton"));

                if (Cookie_consent.Displayed)
                {
                    GreenMessage("Cookie Consent is required to proceed further");
                    Testreport.Log(Status.Info, "Cookie consent confirmation appeared");
                    Assert.IsTrue(Cookie_consent.Displayed);
                    Cookie_consent.Click();
                    Assert.IsTrue(Username.Displayed);
                    Assert.IsTrue(Password.Displayed);
                    Assert.IsTrue(Loginbtn.Displayed);
                    Testreport.Log(Status.Info, "All the Page Elements are present");
                    driver.Quit();
                    Testreport.Log(Status.Pass, "Test Case for Login Form Elements is Passed");
                }
                else
                {
                    Redmessage("Nothing found");
                    Testreport.Log(Status.Pass, "Test Case for Login Form Elements is Failed");
                    ITakesScreenshot takescreen = driver as ITakesScreenshot;
                    Screenshot screenshot = takescreen.GetScreenshot();
                    screenshot.SaveAsFile("C:\\Users\\45916\\source\\repos\\Plandaytask\\Plandaytask\\Screenshots\\Screenshot.jpeg", ScreenshotImageFormat.Jpeg);



                }

            }
            [Test, Category("Login Page Tests"), Order(2)]
            public void InvalidCredentials()
            {
                ExtentTest Testreport;
                Testreport = Extent.CreateTest("Invalid Credentials Test").Info("Test Started:");
                Testreport.Log(Status.Info, "Chrome browser is launched");
                IWebElement Cookie_consent = driver.FindElement(By.Id("cookie-consent-button"));
                if (Cookie_consent.Displayed)
                {
                    Cookie_consent.Click();
                }

                IWebElement Username = driver.FindElement(By.Id("Username"));
                Username.Click();
                Username.SendKeys("icorrect@email.com");
                IWebElement Password = driver.FindElement(By.Id("Password"));
                Password.Click();
                Password.SendKeys("incorrectPass");
                IWebElement Loginbtn = driver.FindElement(By.Id("MainLoginButton"));
                Loginbtn.Click();
                IWebElement UsernameValidation = driver.FindElement(By.Id("Username-validation-error"));
                IWebElement PasswordValidation = driver.FindElement(By.Id("Password-validation-error"));
                if (UsernameValidation.Enabled)
                {

                    Assert.AreEqual(UsernameValidation.Text, PasswordValidation.Text);

                    Testreport.Log(Status.Pass, "Test Case for Login Form Elements is Passed");
                }
                else
                {
                    Testreport.Log(Status.Fail, "Test Case for Login Form Elements is Failed");
                    ITakesScreenshot takescreen = driver as ITakesScreenshot;
                    Screenshot screenshot = takescreen.GetScreenshot();
                    screenshot.SaveAsFile("C:\\Users\\45916\\source\\repos\\Plandaytask\\Plandaytask\\Screenshots\\Screenshot.jpeg", ScreenshotImageFormat.Jpeg);

                }


                driver.Quit();


            }

            [Test, Category("Valid Login and traversing to Schedule Tab"), Order(3)]

            public void ValidLogintoScheduletab()
            {
                ExtentTest Testreport;
                Testreport = Extent.CreateTest("Valid Credentials Test").Info("Test Started:");
                Testreport.Log(Status.Info, "Chrome browser is launched");
                IWebElement Cookie_consent = driver.FindElement(By.Id("cookie-consent-button"));
                if (Cookie_consent.Displayed)
                {
                    Testreport.Log(Status.Info, "Cookie consent confirmation appeared");
                    Cookie_consent.Click();
                }

                IWebElement Username = driver.FindElement(By.Id("Username"));
                Username.Click();
                Username.SendKeys("plandayqa@outlook.com");
                IWebElement Password = driver.FindElement(By.Id("Password"));
                Password.Click();
                Password.SendKeys("APItesting21");
                IWebElement Loginbtn = driver.FindElement(By.Id("MainLoginButton"));
                Loginbtn.Click();
                Thread.Sleep(3000);
                Assert.IsTrue(driver.Url.Contains("/page/home"));
                Testreport.Log(Status.Pass, "Login to the app is Successful");

                string Scheduletab = "#root > div > header > nav.sc-eCImPb.bkFHwb > ul > li:nth-child(2) > a";
                try
                {
                    IWebElement Schedule = driver.FindElement(By.CssSelector(Scheduletab));

                    if (Schedule.Displayed)
                    {
                        GreenMessage("I can see the SCHEDULE tab");
                        Schedule.Click();

                        if (Schedule.GetAttribute("href").Contains("/page/schedule"))
                        {
                            GreenMessage("Congratulations we have passed");
                            Testreport.Log(Status.Pass, "Test Case for Valid Login to Schedule tab is Passed");

                        }
                    }
                }
                catch (NoSuchElementException)
                {


                    Redmessage("Cannot see the SCHEDULE tab");
                    Testreport.Log(Status.Fail, "Test Case for Schedule tab is Failed");
                    ITakesScreenshot takescreen = driver as ITakesScreenshot;
                    Screenshot screenshot = takescreen.GetScreenshot();
                    screenshot.SaveAsFile("C:\\Users\\45916\\source\\repos\\Plandaytask\\Plandaytask\\Screenshots\\Screenshot.jpeg", ScreenshotImageFormat.Jpeg);

                }


                driver.Quit();


            }
            [Test, Category("Testing Schedule Tab"), Order(5)]

            public void EmployeeScheduleTest()
            {
                ExtentTest Testreport;
                Testreport = Extent.CreateTest("Employee Schedule Test").Info("Test Started:");
                Testreport.Log(Status.Info, "Chrome browser is launched");
                IWebElement Cookie_consent = driver.FindElement(By.Id("cookie-consent-button"));
                if (Cookie_consent.Displayed)
                {
                    Testreport.Log(Status.Info, "Cookie consent confirmation appeared");
                    Cookie_consent.Click();
                }

                IWebElement Username = driver.FindElement(By.Id("Username"));
                Username.Click();
                Username.SendKeys("plandayqa@outlook.com");
                IWebElement Password = driver.FindElement(By.Id("Password"));
                Password.Click();
                Password.SendKeys("APItesting21");
                IWebElement Loginbtn = driver.FindElement(By.Id("MainLoginButton"));
                Loginbtn.Click();
                Thread.Sleep(3000);
                Assert.IsTrue(driver.Url.Contains("/page/home"));
                Testreport.Log(Status.Pass, "Login to the app is Successful");

                string Scheduletab = "#root > div > header > nav.sc-eCImPb.bkFHwb > ul > li:nth-child(2) > a";
                try
                {
                    IWebElement Schedule = driver.FindElement(By.CssSelector(Scheduletab));

                    if (Schedule.Displayed)
                    {
                        GreenMessage("I can see the SCHEDULE tab");
                        Schedule.Click();

                        Console.WriteLine(Schedule.GetAttribute("href"));

                        if (Schedule.GetAttribute("href").Contains("/page/schedule"))
                        {
                            GreenMessage("Congratulations we have passed");
                            Testreport.Log(Status.Pass, "Test Case for Valid Login to Schedule tab is Passed");
                            Thread.Sleep(3000);


                        }
                    }
                }
                catch (NoSuchElementException)
                {


                    Redmessage("Cannot see the SCHEDULE tab");
                    Testreport.Log(Status.Fail, "Test Case for Schedule tab is Failed");
                }

                try
                {
                    driver.SwitchTo().Frame(0);
                    Thread.Sleep(3000);
                    string employee1 = "#app-container > div > div.app-frame__main.app-frame__main--schedule > div.app-frame__content.app-frame__content--no-scrollbar.app-frame__content--no-sidebar > div > div.virtualized-board__body > div:nth-child(1) > div > div > div:nth-child(2) > div:nth-child(3) > div";

                    string date = DateTime.UtcNow.ToString("MMMM dd, yyyy");
                    string aria = date + " Employee One";



                    IWebElement empbtn = driver.FindElement(By.CssSelector(employee1));
                    empbtn.Click();
                    GreenMessage("Employee Found");
                    Thread.Sleep(3000);

                    IWebElement sttime = driver.FindElement(By.Id("shiftStartEnd_start"));
                    //sttime.Click();
                    sttime.SendKeys("09:00");

                    IWebElement endtime = driver.FindElement(By.Id("shiftStartEnd_end"));
                    endtime.Click();
                    endtime.SendKeys("17:00");

                    string createbtn = "body > div:nth-child(11) > div > div > div > div.edit-shift-modal__footer > div > div > ul > li:nth-child(2) > button";
                    IWebElement crbtn = driver.FindElement(By.CssSelector(createbtn));
                    crbtn.Click();
                    Thread.Sleep(3000);


                    string confirmshift = "#app-container > div > div.app-frame__main.app-frame__main--schedule > div.app-frame__content.app-frame__content--no-scrollbar.app-frame__content--no-sidebar > div > div.virtualized-board__body > div:nth-child(1) > div > div > div:nth-child(2) > div:nth-child(3) > div > div > div > div.shift-tile__time.shift-tile__time--active > span:nth-child(1)";
                    IWebElement shiftcreated = driver.FindElement(By.CssSelector(confirmshift));

                    if (shiftcreated.Text.Contains("09"))
                    {

                        Testreport.Log(Status.Pass, "Shift is created for Employee 1 through Automation");
                        Assert.Pass(shiftcreated.Text);
                    }
                    else
                    {
                        Testreport.Log(Status.Fail, "No shift found");
                        ITakesScreenshot takescreen = driver as ITakesScreenshot;
                        Screenshot screenshot = takescreen.GetScreenshot();
                        screenshot.SaveAsFile("C:\\Users\\45916\\source\\repos\\Plandaytask\\Plandaytask\\Screenshots\\Screenshot.jpeg", ScreenshotImageFormat.Jpeg);


                    }


                    Thread.Sleep(3000);


                }
                catch (NoSuchElementException)
                {
                    Redmessage("Exception");
                }

                driver.Quit();


            }
            [Test, Category("Calender Test"), Order(4)]
            public void CalenderTest()
            {
                ExtentTest Testreport;
                Testreport = Extent.CreateTest("Calender Test").Info("Test Started:");
                Testreport.Log(Status.Info, "Chrome browser is launched");
                IWebElement Cookie_consent = driver.FindElement(By.Id("cookie-consent-button"));
                if (Cookie_consent.Displayed)
                {
                    Testreport.Log(Status.Info, "Cookie consent confirmation appeared");
                    Cookie_consent.Click();
                }

                IWebElement Username = driver.FindElement(By.Id("Username"));
                Username.Click();
                Username.SendKeys("plandayqa@outlook.com");
                IWebElement Password = driver.FindElement(By.Id("Password"));
                Password.Click();
                Password.SendKeys("APItesting21");
                IWebElement Loginbtn = driver.FindElement(By.Id("MainLoginButton"));
                Loginbtn.Click();
                Thread.Sleep(3000);
                Assert.IsTrue(driver.Url.Contains("/page/home"));
                Testreport.Log(Status.Pass, "Login to the app is Successful");

                string Scheduletab = "#root > div > header > nav.sc-eCImPb.bkFHwb > ul > li:nth-child(2) > a";
                try
                {
                    IWebElement Schedule = driver.FindElement(By.CssSelector(Scheduletab));

                    if (Schedule.Displayed)
                    {
                        GreenMessage("I can see the SCHEDULE tab");
                        Schedule.Click();

                        Console.WriteLine(Schedule.GetAttribute("href"));

                        if (Schedule.GetAttribute("href").Contains("/page/schedule"))
                        {
                            GreenMessage("Congratulations we have passed");
                            Testreport.Log(Status.Pass, "Test Case for Valid Login to Schedule tab is Passed");
                            Thread.Sleep(3000);


                        }
                    }
                }
                catch (NoSuchElementException)
                {


                    Redmessage("Cannot see the SCHEDULE tab");
                    Testreport.Log(Status.Fail, "Test Case for Schedule tab is Failed");
                    ITakesScreenshot takescreen = driver as ITakesScreenshot;
                    Screenshot screenshot = takescreen.GetScreenshot();
                    screenshot.SaveAsFile("C:\\Users\\45916\\source\\repos\\Plandaytask\\Plandaytask\\Screenshots\\Screenshot.jpeg", ScreenshotImageFormat.Jpeg);

                }

                try
                {
                    driver.SwitchTo().Frame(0);
                    Thread.Sleep(3000);
                    string weekbarR = "#app-container > div > div.app-frame__main.app-frame__main--schedule > div.app-frame__toolbar.app-frame__toolbar--schedule > div.toolbar__item.scheduling__container > div.scheduling__date-selector > div > button.button--right.date-bar__button";
                    IWebElement weekbarbtnR = driver.FindElement(By.CssSelector(weekbarR));
                    weekbarbtnR.Click();

                    Thread.Sleep(3000);

                    string weekbarL = "#app-container > div > div.app-frame__main.app-frame__main--schedule > div.app-frame__toolbar.app-frame__toolbar--schedule > div.toolbar__item.scheduling__container > div.scheduling__date-selector > div > button.button--left.date-bar__button";
                    IWebElement weekbarbtnL = driver.FindElement(By.CssSelector(weekbarL));
                    weekbarbtnL.Click();
                    Testreport.Log(Status.Pass, "Calender Test is Passed");
                }
                catch (NoSuchElementException)
                {
                    Redmessage("Exception");
                    Testreport.Log(Status.Error, "Calender Test- Exception!");
                    ITakesScreenshot takescreen = driver as ITakesScreenshot;
                    Screenshot screenshot = takescreen.GetScreenshot();
                    screenshot.SaveAsFile("C:\\Users\\45916\\source\\repos\\Plandaytask\\Plandaytask\\Screenshots\\Screenshot.jpeg", ScreenshotImageFormat.Jpeg);

                }

                driver.Quit();


            }



        }
    }
}