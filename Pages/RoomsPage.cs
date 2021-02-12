using System;
using OpenQA.Selenium;

namespace Challenge_2.Pages
{
    public class RoomsPage
    {
        private readonly IWebDriver driver;
        public RoomsPage(IWebDriver _driver) => driver = _driver;

        public IWebElement RoomsLink => driver.FindElement(By.LinkText("Rooms"));

        public bool IsDisplayed()
        {
            return RoomsLink.Text.Contains("Rooms");
        }
    
    }
}
