using System;
using OpenQA.Selenium;

namespace Challenge_2.Pages
{
    public class BrandingPage
    {
        private readonly IWebDriver driver;
        public BrandingPage(IWebDriver _driver) => driver = _driver;

        public IWebElement BrandingLink => driver.FindElement(By.Id("brandingLink"));
        public IWebElement NameInput => driver.FindElement(By.Id("name"));
        public IWebElement UpdateBrandingButton => driver.FindElement(By.Id("updateBranding"));
        public IWebElement ConfirmationDialogue => driver.FindElement(By.ClassName("ReactModal__Content"));

        public void UpdateBranding()
        {
            BrandingLink.Click();
            NameInput.SendKeys("Test");
            UpdateBrandingButton.Click();
        }

        public bool IsUpdated() => ConfirmationDialogue.Text.Contains("Branding updated!");
    }
}
