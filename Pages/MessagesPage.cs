using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

namespace Challenge_2.Pages
{
    public class MessagesPage
    {
        private readonly IWebDriver driver;
        private readonly string senderName;
        private readonly string messageSubject;

        public MessagesPage(IWebDriver _driver, string _senderName, string _messageSubject)
        {
            driver = _driver;
            senderName = _senderName;
            messageSubject = _messageSubject;
        }

        public void GoToPage(string url = "https://automationintesting.online/#/admin/messages") => driver.Navigate().GoToUrl(url);

        private IList<IWebElement> Messages => driver.FindElements(By.CssSelector(".read-false"));

        //TODO: This type of test would be best done using visual testing to check styles
        public bool DisplaysUnreadMessagesBold()
        {
            var lastMessage = Messages.Last().Text;
            if (lastMessage.Contains(senderName) && lastMessage.Contains(messageSubject)){
                if (Messages.Last().GetCssValue("font-weight").Equals("700")) return true;
            }
            return false;
         
        }
    }
}