using OpenQA.Selenium;

namespace WebShopAutomation.Locators
{
    public static class LandingPageLocators
    {
        // Landing Page Locators
        public static readonly By RegisterLink = By.XPath("//a[text()='Register']");
        public static readonly By LoginLink = By.XPath("//a[@class='ico-login']");
    }
}
