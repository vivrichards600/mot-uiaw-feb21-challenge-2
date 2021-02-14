using System;
using OpenQA.Selenium;

namespace Challenge_2.Pages
{
    public class ContactPage
    {
        private readonly IWebDriver driver;
        public ContactPage(IWebDriver _driver) => driver = _driver;


        public IWebElement NameInput => driver.FindElement(By.Id("name"));
        public IWebElement EmailInput => driver.FindElement(By.Id("email"));
        public IWebElement PhoneInput => driver.FindElement(By.Id("phone"));
        public IWebElement SubjectInput => driver.FindElement(By.Id("subject"));
        public IWebElement DescriptionInput => driver.FindElement(By.Id("description"));
        public IWebElement SubmitMessageButton => driver.FindElement(By.Id("submitContact"));
        public IWebElement Confirmation => driver.FindElement(By.CssSelector(".contact h2"));

        private void GoToPage(string url = "https://automationintesting.online/") => driver.Navigate().GoToUrl(url);

        public void SendMessage() {
            GoToPage();
            NameInput.SendKeys("TEST123");
            EmailInput.SendKeys("TEST123@TEST.COM");
            PhoneInput.SendKeys("01212121311");
            SubjectInput.SendKeys("TEsTEST");
            DescriptionInput.SendKeys("TEsTESTTEsTESTTEsTEST");
            SubmitMessageButton.Click();
        }

        public bool MessageIsSent() => Confirmation.Text.Contains("Thanks for getting in touch");
    }
}
