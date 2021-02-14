using System.Collections.Generic;
using OpenQA.Selenium;

namespace Challenge_2.Pages
{
    public class RoomsPage
    {
        private readonly IWebDriver driver;
        public RoomsPage(IWebDriver _driver) => driver = _driver;

        public IWebElement RoomsLink => driver.FindElement(By.LinkText("Rooms"));
        private IWebElement RoomNumberInput => driver.FindElement(By.Id("roomNumber"));
        private IWebElement RoomPriceInput => driver.FindElement(By.Id("roomPrice"));
        private IWebElement CreateRoomButton => driver.FindElement(By.Id("createRoom"));
        private IList<IWebElement> Bookings => driver.FindElements(By.ClassName(".details"));

        public bool IsDisplayed() => RoomsLink.Text.Contains("Rooms");

        //TODO: might be nice to make the data dynamic
        public void CreateBooking()
        {
            RoomNumberInput.SendKeys("101");
            RoomPriceInput.SendKeys("101");
            CreateRoomButton.Click();
        }

        //TODO: might be nice to confirm dynamically added values are there as this check currently is a bit rubbish
        public bool ContainsBookings() => Bookings.Count != 1;

    }
}