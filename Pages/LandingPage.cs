using OpenQA.Selenium;
using WebShopAutomation.Locators;
using WebShopAutomation.Utilities;

namespace WebShopAutomation.Pages
{
    public class LandingPage
    {
        private readonly IWebDriver driver;

        public LandingPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        // Methods

        // Check if the Register link is displayed
        public bool IsRegisterLinkDisplayed()
        {
            return ElementActions.WaitForElementToBeVisible(driver, LandingPageLocators.RegisterLink).Displayed;
        }

        // Check if the Register link is clickable
        public bool IsRegisterLinkClickable()
        {
            return ElementActions.WaitForElementToBeClickable(driver, LandingPageLocators.RegisterLink).Enabled;
        }

        // Click the Register link
        public void ClickRegisterLink()
        {
            ElementActions.Click(driver, LandingPageLocators.RegisterLink);
        }

        // Check if the Login link is displayed
        public bool IsLoginLinkDisplayed()
        {
            return ElementActions.WaitForElementToBeVisible(driver, LandingPageLocators.LoginLink).Displayed;
        }

        // Check if the Login link is clickable
        public bool IsLoginLinkClickable()
        {
            return ElementActions.WaitForElementToBeClickable(driver, LandingPageLocators.LoginLink).Enabled;
        }

        // Click the Login link
        public void ClickLoginLink()
        {
            ElementActions.Click(driver, LandingPageLocators.LoginLink);
        }
    }
}
