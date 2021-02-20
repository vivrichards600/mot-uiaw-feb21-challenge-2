using OpenQA.Selenium;

namespace Challenge_2.Pages
{
    public class ContactPage
    {
        private readonly IWebDriver driver;
        private readonly string senderName;
        private readonly string messageSubject;

        public ContactPage(IWebDriver _driver, string _senderName, string _messageSubject)
        {
            driver = _driver;
            senderName = _senderName;
            messageSubject = _messageSubject;
        }

        private IWebElement NameInput => driver.FindElement(By.Id("name"));
        private IWebElement EmailInput => driver.FindElement(By.Id("email"));
        private IWebElement PhoneInput => driver.FindElement(By.Id("phone"));
        private IWebElement SubjectInput => driver.FindElement(By.Id("subject"));
        private IWebElement DescriptionInput => driver.FindElement(By.Id("description"));
        private IWebElement SubmitMessageButton => driver.FindElement(By.Id("submitContact"));
        private IWebElement Confirmation => driver.FindElement(By.CssSelector(".contact h2"));

        public void GoToPage(string url = "https://automationintesting.online/") => driver.Navigate().GoToUrl(url);

        public void SendNewMessage() {
            NameInput.SendKeys(senderName);
            EmailInput.SendKeys("TEST123@TEST.COM");
            PhoneInput.SendKeys("01212121311");
            SubjectInput.SendKeys(messageSubject);
            DescriptionInput.SendKeys("TEsTESTTEsTESTTEsTEST");
            SubmitMessageButton.Click();
        }

        public bool DisplaysConfirmationMessage() => Confirmation.Text.Contains("Thanks for getting in touch");
    }
}