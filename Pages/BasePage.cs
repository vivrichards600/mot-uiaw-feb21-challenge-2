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
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            adminPage = new AdminPage(driver);
            roomsPage = new RoomsPage(driver);
            brandingPage = new BrandingPage(driver);
            contactPage = new ContactPage(driver);
            messagesPage = new MessagesPage(driver);

            roomsPage.GenerateTestData();
        }

        [TearDown]
        public void Cleanup() => driver.Quit();

        private IWebDriver driver;

        public AdminPage adminPage;
        public RoomsPage roomsPage;
        public BrandingPage brandingPage;
        public ContactPage contactPage;
        public MessagesPage messagesPage;
    }
}