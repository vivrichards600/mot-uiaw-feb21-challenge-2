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
        }

        [TearDown]
        public void Cleanup()
        {
            driver.Quit();
        }

        public IWebDriver driver;
        public string baseUrl = "https://automationintesting.online/";
        public LoginPage loginPage;
        public RoomsPage roomsPage;

    }
}
