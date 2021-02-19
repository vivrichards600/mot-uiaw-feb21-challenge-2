using OpenQA.Selenium;

namespace Challenge_2.Pages
{
    public class AdminPage
    {
        private readonly IWebDriver driver;
        public AdminPage(IWebDriver _driver) => driver = _driver;

        private IWebElement UsernameInput => driver.FindElement(By.Id("username"));
        private IWebElement PasswordInput => driver.FindElement(By.Id("password"));
        private IWebElement LoginButton => driver.FindElement(By.Id("doLogin"));
        
        public void GoToPage(string url = "https://automationintesting.online/#/admin") => driver.Navigate().GoToUrl(url);

        public void Login()
        {
            UsernameInput.SendKeys("admin");
            PasswordInput.SendKeys("password");
            LoginButton.Click();
        }
    }
}