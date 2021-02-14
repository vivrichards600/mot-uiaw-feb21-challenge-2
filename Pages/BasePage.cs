using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Challenge_2.Pages
{
    public class BasePage
    {       
        [SetUp]
        public void Init()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            loginPage = new LoginPage(driver);
            roomsPage = new RoomsPage(driver);
            brandingPage = new BrandingPage(driver);
            contactPage = new ContactPage(driver);
            messagesPage = new MessagesPage(driver);
        }

        [TearDown]
        public void Cleanup() => driver.Quit();

        private IWebDriver driver;

        public LoginPage loginPage;
        public RoomsPage roomsPage;
        public BrandingPage brandingPage;
        public ContactPage contactPage;
        public MessagesPage messagesPage;

    }
}