using OpenQA.Selenium;
using WebShopAutomation.Locators;
using WebShopAutomation.Utilities;

namespace WebShopAutomation.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        // Page Methods

        // Enter email
        public void EnterEmail(string value)
        {
            ElementActions.EnterText(driver, LoginPageLocators.EmailField, value);
        }

        // Enter password
        public void EnterPassword(string value)
        {
            ElementActions.EnterText(driver, LoginPageLocators.PasswordField, value);
        }

        // Click the Login button
        public void ClickLoginButton()
        {
            ElementActions.Click(driver, LoginPageLocators.LoginButton);
        }

        // Check if login was successful by verifying the presence of the account element
        public bool IsLoginSuccessful()
        {
            try
            {
                var accountElement = driver.FindElement(LoginPageLocators.LoggedIn);
                return accountElement.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        // Check if login failed by verifying the presence of the error message
        public bool IsLoginErrorMessageDisplayed()
        {
            try
            {
                var errorElement = driver.FindElement(LoginPageLocators.LoginErrorMessage);
                return errorElement.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
