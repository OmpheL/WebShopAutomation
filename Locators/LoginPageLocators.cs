using OpenQA.Selenium;

namespace WebShopAutomation.Locators
{
    public static class LoginPageLocators
    {
        // Login Page Locators
        public static readonly By EmailField = By.Id("Email");
        public static readonly By PasswordField = By.Id("Password");
        public static readonly By LoginButton = By.XPath("//input[@class='button-1 login-button']");
        public static readonly By LoggedIn = By.XPath("//a[@class='account']");
        public static readonly By LoginErrorMessage = By.XPath("//span[contains(text(), 'unsuccessful')]");
    }
}
