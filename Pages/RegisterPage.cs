using OpenQA.Selenium;
using WebShopAutomation.Utilities;
using WebShopAutomation.Locators;

namespace WebShopAutomation.Pages
{
    public class RegisterPage
    {
        private readonly IWebDriver driver;

        public RegisterPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        // Page Methods

        // Select gender radio button
        public void SelectGender(string gender)
        {
            var genderLocator = gender.ToLower() switch
            {
                "male" => RegisterPageLocators.GenderMale,
                "female" => RegisterPageLocators.GenderFemale,
                _ => throw new ArgumentException("Invalid gender value")
            };

            ElementActions.Click(driver, genderLocator);
        }

        // Enter first name
        public void EnterFirstName(string value)
        {
            ElementActions.EnterText(driver, RegisterPageLocators.FirstName, value);
        }

        // Enter last name
        public void EnterLastName(string value)
        {
            ElementActions.EnterText(driver, RegisterPageLocators.LastName, value);
        }

        // Enter email
        public void EnterEmail(string value)
        {
            ElementActions.EnterText(driver, RegisterPageLocators.Email, value);
        }

        // Enter password
        public void EnterPassword(string value)
        {
            ElementActions.EnterText(driver, RegisterPageLocators.Password, value);
        }

        // Enter confirm password
        public void EnterConfirmPassword(string value)
        {
            ElementActions.EnterText(driver, RegisterPageLocators.ConfirmPassword, value);
        }

        // Click the Register button
        public void ClickRegisterButton()
        {
            ElementActions.Click(driver, RegisterPageLocators.RegisterButton);
        }

        // Check if registration was successful
        public bool IsRegistrationSuccessful()
        {
            try
            {
                var successElement = driver.FindElement(RegisterPageLocators.SuccessMessage);
                return successElement.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        // Check if the user is already registered
        public bool IsUserAlreadyRegistered()
        {
            try
            {
                var errorElement = driver.FindElement(RegisterPageLocators.ErrorMessage);
                return errorElement.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
