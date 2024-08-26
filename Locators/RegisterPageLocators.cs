using OpenQA.Selenium;

namespace WebShopAutomation.Locators
{
    public static class RegisterPageLocators
    {
        // Register Page Locators
        public static readonly By GenderMale = By.Id("gender-male");
        public static readonly By GenderFemale = By.Id("gender-female");
        public static readonly By FirstName = By.Id("FirstName");
        public static readonly By LastName = By.Id("LastName");
        public static readonly By Email = By.Id("Email");
        public static readonly By Password = By.Id("Password");
        public static readonly By ConfirmPassword = By.Id("ConfirmPassword");
        public static readonly By RegisterButton = By.Id("register-button");
        public static readonly By ErrorMessage = By.XPath("//li[contains(text(), 'exists')]");
        public static readonly By SuccessMessage = By.XPath("//div[contains(text(), 'completed')]");
    }
}
