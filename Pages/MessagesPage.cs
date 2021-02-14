using System.Collections.Generic;
using OpenQA.Selenium;

namespace Challenge_2.Pages
{
    public class MessagesPage
    {
        private readonly IWebDriver driver;
        public MessagesPage(IWebDriver _driver) => driver = _driver;

        public void GoToPage(string url = "https://automationintesting.online/#/admin/messages") => driver.Navigate().GoToUrl(url);

        private IList<IWebElement> Messages => driver.FindElements(By.CssSelector(".read-false"));

        //TODO: Refactor. This type of test is best done using visual testing
        public bool AllUnreadMessagesAreBold()
        {
            foreach (IWebElement message in Messages)
            {
                if (!message.GetCssValue("font-weight").Equals("700")) return false;
            }

            return true;
        }
    }
}