using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Challenge_2
{
    //    Welcome to UI Automation Challenge 2
    //
    //    For this challenge it's all about creating clean, readable and maintainable code. Below
    //    are five tests that work (just about) but require cleaning up. Update this code base
    //    so that it's easier to maintain, more readable, and has sensible ways of asserting
    //    data. You might want to research different approaches to improving UI automation such as
    //    Page Object Models and implicit vs. explicit waits, as well as NUnit features that can make things
    //    easier to maintain

    public class Challenge2Tests
    {
        private IWebDriver driver;
        private String baseUrl = "https://automationintesting.online/";

        #region "Setup and tear down"
        [SetUp]
        public void Init()
        {
            driver = new ChromeDriver();
        }

        [TearDown]
        public void Cleanup()
        {
            driver.Quit();
        }
        #endregion


        //  Test one: Check to see if you can log in with valid credentials
        [Test]
        public void VerifyCanLoginWithValidCredentials()
        {
            driver.Url = $"{baseUrl}#/admin";
            driver.FindElement(By.Id("username")).SendKeys("admin");
            driver.FindElement(By.Id("password")).SendKeys("password");
            driver.FindElement(By.Id("doLogin")).Click();

            //TODO: Remove this
            Thread.Sleep(100);

            IWebElement webElement = driver.FindElement(By.ClassName("navbar-collapse"));
            Console.WriteLine(webElement.Text);
            Boolean title = webElement.Text.Contains("Rooms");

            Assert.IsTrue(title);
            driver.Close();
        }

        //  Test two: Check to see if rooms are saved and displayed in the UI
        [Test]
        public void VerifyRoomsAreSavedAndDisplayedInUI()
        {
            driver.Url = $"{baseUrl}#/admin";
            driver.FindElement(By.Id("username")).SendKeys("admin");
            driver.FindElement(By.Id("password")).SendKeys("password");
            driver.FindElement(By.Id("doLogin")).Click();

            //TODO: Remove this
            Thread.Sleep(100);

            driver.FindElement(By.Id("roomNumber")).SendKeys("101");
            driver.FindElement(By.Id("roomPrice")).SendKeys("101");
            driver.FindElement(By.Id("createRoom")).Click();

            Thread.Sleep(100);

            Assert.That(driver.FindElements(By.ClassName(".detail")).Count != 1);
            driver.Close();
        }


        //  Test three: Check to see the confirm message appears when branding is updated
        [Test]
        public void VerifyConfirmMessageAppearsWhenBrandingIsUpdated()
        {
            driver.Url = $"{baseUrl}#/admin";
            driver.FindElement(By.Id("username")).SendKeys("admin");
            driver.FindElement(By.Id("password")).SendKeys("password");
            driver.FindElement(By.Id("doLogin")).Click();

            driver.Url = $"{baseUrl}#/admin/branding";

            //TODO: Remove this
            Thread.Sleep(200);

            driver.FindElement(By.Id("name")).SendKeys("Test");
            driver.FindElement(By.Id("updateBranding")).Click();

            Thread.Sleep(100);

            int count = driver.FindElements(By.XPath("//button[text()=\"Close\"]")).Count;

            if (count == 1)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
            driver.Close();
        }

        //  Test four: Check to see if the contact form shows a success message
        [Test]
        public void VerifyContactFormShowsSuccessMessage()
        {
            driver.Url = "https://automationintesting.online/";
            driver.FindElement(By.CssSelector("input[placeholder=Name]")).SendKeys("TEST123");
            driver.FindElement(By.CssSelector("input[placeholder=Email]")).SendKeys("TEST123@TEST.COM");
            driver.FindElement(By.CssSelector("input[placeholder=Phone]")).SendKeys("01212121311");
            driver.FindElement(By.CssSelector("input[placeholder=Subject]")).SendKeys("TEsTEST");
            driver.FindElement(By.CssSelector("textarea")).SendKeys("TEsTESTTEsTESTTEsTEST");

            driver.FindElement(By.XPath("//button[text()=\"Submit\"]")).Click();

            //TODO: Look to see how we can remove this
            Thread.Sleep(100);
            Assert.True(driver.FindElement(By.CssSelector(".contact")).Text.Contains("Thanks for getting in touch"));
            driver.Close();
        }

        //  Test five: Check to see if unread messages are bolded
        [Test]
        public void VerifyUnreadMessagesAreBolded()
        {
            driver.Url = "https://automationintesting.online/#/admin/messages";

            driver.FindElement(By.XPath("//div[@class=\"form-group\"][1]/input")).SendKeys("admin");
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//div[@class=\"form-group\"][2]/input")).SendKeys("password");
            Thread.Sleep(1000);
            driver.FindElement(By.ClassName("float-right")).Click();

            Thread.Sleep(3000);
            Assert.True(CheckCount(driver.FindElements(By.CssSelector(".read-false"))));
            driver.Close();
        }

        private bool CheckCount(IReadOnlyCollection<IWebElement> elements)
        {
            if (elements.Count >= 1)
            {
                return true;
            }

            return false;
        }
    }
}
