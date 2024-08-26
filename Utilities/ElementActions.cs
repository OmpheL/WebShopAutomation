using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace WebShopAutomation.Utilities
{
    public static class ElementActions
    {
        // Wait for an element to be visible
        public static IWebElement WaitForElementToBeVisible(IWebDriver driver, By locator, int timeoutInSeconds = 30)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            return wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        // Wait for an element to be clickable
        public static IWebElement WaitForElementToBeClickable(IWebDriver driver, By locator, int timeoutInSeconds = 10)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            return wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        // Set text in a text field
        public static void EnterText(IWebDriver driver, By locator, string text)
        {
            IWebElement element = WaitForElementToBeVisible(driver, locator);
            if (element.Displayed && element.Enabled)
            {
                element.Clear();
                element.SendKeys(text);
            }
            else
            {
                throw new ElementNotInteractableException("The text field is not interactable.");
            }
        }

        // Click on an element
        public static void Click(IWebDriver driver, By locator)
        {
            IWebElement element = WaitForElementToBeClickable(driver, locator);
            if (element.Displayed && element.Enabled)
            {
                element.Click();
            }
            else
            {
                throw new ElementNotInteractableException("The element is not interactable.");
            }
        }

        // Select dropdown option by visible text
        public static void SelectDropdownByText(IWebDriver driver, By locator, string text)
        {
            var dropdown = new SelectElement(WaitForElementToBeVisible(driver, locator));
            dropdown.SelectByText(text);
        }

        // Select dropdown option by value
        public static void SelectDropdownByValue(IWebDriver driver, By locator, string value)
        {
            var dropdown = new SelectElement(WaitForElementToBeVisible(driver, locator));
            dropdown.SelectByValue(value);
        }

        // Select dropdown option by index
        public static void SelectDropdownByIndex(IWebDriver driver, By locator, int index)
        {
            var dropdown = new SelectElement(WaitForElementToBeVisible(driver, locator));
            dropdown.SelectByIndex(index);
        }

        // Wait for an element to be clickable and click on it (for radio buttons)
        public static void ClickRadioButton(IWebDriver driver, By locator)
        {
            IWebElement radioButton = WaitForElementToBeClickable(driver, locator);
            if (radioButton.Displayed && radioButton.Enabled)
            {
                radioButton.Click();
            }
            else
            {
                throw new ElementNotInteractableException("The radio button is not interactable.");
            }
        }
    }
}
