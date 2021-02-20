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

            //TODO: Look to move this from here
            GenerateTestData();

            adminPage = new AdminPage(driver);
            roomsPage = new RoomsPage(driver, roomNumber, roomPrice);
            brandingPage = new BrandingPage(driver);
            contactPage = new ContactPage(driver, senderName, messageSubject);
            messagesPage = new MessagesPage(driver, senderName, messageSubject);
        }

        [TearDown]
        public void Cleanup() => driver.Quit();

        private IWebDriver driver;

        public AdminPage adminPage;
        public RoomsPage roomsPage;
        public BrandingPage brandingPage;
        public ContactPage contactPage;
        public MessagesPage messagesPage;

        #region "Generate test data"
        public void GenerateTestData()
        {
            //TODO: Not the most realisitic test data but random, will do for now
            Random rnd = new Random();
            senderName = "MoT " + rnd.Next(1, 999).ToString();
            messageSubject = "Automation Week " + rnd.Next(70, 200).ToString();
            roomNumber = rnd.Next(100, 999).ToString();
            roomPrice = rnd.Next(70, 200).ToString();
        }

        private string senderName;
        private string messageSubject;
        private string roomNumber;
        private string roomPrice;
        #endregion

    }
}