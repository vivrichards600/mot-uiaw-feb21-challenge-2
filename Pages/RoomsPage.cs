using System;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace Challenge_2.Pages
{
    public class RoomsPage
    {
        private readonly IWebDriver driver;
        public RoomsPage(IWebDriver _driver) => driver = _driver;

        public IWebElement RoomsLink => driver.FindElement(By.LinkText("Rooms"));
        public IWebElement RoomNumberInput => driver.FindElement(By.Id("roomNumber"));
        public IWebElement RoomPriceInput => driver.FindElement(By.Id("roomPrice"));
        public IWebElement CreateRoomButton => driver.FindElement(By.Id("createRoom"));
        public IList<IWebElement> Bookings => driver.FindElements(By.ClassName(".details"));

        public bool IsDisplayed() => RoomsLink.Text.Contains("Rooms");

        public void CreateBooking()
        {
            RoomNumberInput.SendKeys("101");
            RoomPriceInput.SendKeys("101");
            CreateRoomButton.Click();
        }

        public bool ContainsBookings()
        {
            return Bookings.Count != 1;
        }
    
    }
}
