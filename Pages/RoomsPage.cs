﻿using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace Challenge_2.Pages
{
    public class RoomsPage
    {
        private readonly IWebDriver driver;

        private readonly string roomNumber;
        private readonly string roomPrice;

        public RoomsPage(IWebDriver _driver, string _roomNumber, string _roomPrice)
        {
            driver = _driver;
            roomNumber = _roomNumber;
            roomPrice = _roomPrice;
        }

        public IWebElement RoomsLink => driver.FindElement(By.LinkText("Rooms"));
        private IWebElement RoomNumberInput => driver.FindElement(By.Id("roomNumber"));
        private IWebElement RoomPriceInput => driver.FindElement(By.Id("roomPrice"));
        private IWebElement CreateRoomButton => driver.FindElement(By.Id("createRoom"));

        private IList<IWebElement> Bookings => driver.FindElements(By.XPath("//*[@data-type='room']"));

        //TODO: Refactor, markup not best, selector not great
        IWebElement BookingsContainer => driver.FindElement(By.XPath("//*[@id='root']/div[2]/div"));

        public bool IsDisplayed() => RoomsLink.Text.Contains("Rooms");

        public void CreateBooking()
        {
            RoomNumberInput.SendKeys(roomNumber);
            RoomPriceInput.SendKeys(roomPrice);
            CreateRoomButton.Click();
        }

        public bool ContainsNewBooking()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElement(BookingsContainer, roomNumber));

            var lastBooking = Bookings.Last().Text;
            return lastBooking.Contains(roomNumber) && lastBooking.Contains(roomPrice);
        }

    }
}