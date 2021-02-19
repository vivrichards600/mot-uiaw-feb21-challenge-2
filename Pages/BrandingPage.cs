using OpenQA.Selenium;

namespace Challenge_2.Pages
{
    public class BrandingPage
    {
        private readonly IWebDriver driver;
        public BrandingPage(IWebDriver _driver) => driver = _driver;

        private IWebElement BrandingLink => driver.FindElement(By.Id("brandingLink"));
        private IWebElement NameInput => driver.FindElement(By.Id("name"));
        private IWebElement UpdateBrandingButton => driver.FindElement(By.Id("updateBranding"));
        private IWebElement ConfirmationDialogue => driver.FindElement(By.ClassName("ReactModal__Content"));

        public void GoToPage() => BrandingLink.Click();

        public void UpdateBranding()
        {
            NameInput.Clear();
            NameInput.SendKeys("Test");
            UpdateBrandingButton.Click();
        }

        public bool UpdatedConfirmationDisplayed() => ConfirmationDialogue.Text.Contains("Branding updated!");
    }
}