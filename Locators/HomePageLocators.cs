using OpenQA.Selenium;

namespace WebShopAutomation.Locators
{
    public static class HomePageLocators
    {
        // Home Page Locators
        public static readonly By JewelryCategory = By.XPath("(//a[@href=\"/jewelry\"])[3]");
        public static readonly By CreateYourOwnJewelry = By.XPath("//a[@href='/create-it-yourself-jewelry']");
        public static readonly By DemoWorkShopLogo = By.XPath("//img[@alt='Tricentis Demo Web Shop']");
        public static readonly By LogoutLink = By.XPath("//a[@class=\"ico-logout\"]");
    }
}
