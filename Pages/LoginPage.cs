using System;
using OpenQA.Selenium;

namespace Challenge_2.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver driver;
        public LoginPage(IWebDriver _driver) => driver = _driver;

        public IWebElement UsernameInput => driver.FindElement(By.Id("username"));
        public IWebElement PasswordInput => driver.FindElement(By.Id("password"));
        public IWebElement LoginButton => driver.FindElement(By.Id("doLogin"));

        private void GoToPage(string url = "https://automationintesting.online/#/admin") => driver.Navigate().GoToUrl(url);

        public void Login()
        {
            GoToPage();
            UsernameInput.SendKeys("admin");
            PasswordInput.SendKeys("password");
            LoginButton.Click();
        }
    }
}
