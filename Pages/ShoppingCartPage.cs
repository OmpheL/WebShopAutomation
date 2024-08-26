using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using WebShopAutomation.Utilities;
using System;

namespace WebShopAutomation.Pages
{
    public class ShoppingCartPage
    {
        private readonly IWebDriver driver;
        private const int MaxQuantity = 50; // Maximum quantity allowed

        public ShoppingCartPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        // Check if an item is in the cart
        public bool IsItemInCart(string itemName)
        {
            var cartItems = driver.FindElements(ShoppingCartPageLocators.CartItemTitle);
            return cartItems.Any(item => item.Text.Contains(itemName, StringComparison.OrdinalIgnoreCase));
        }

        // Get the quantity of items in the cart
        public int GetCartQuantity()
        {
            var cartQtyText = driver.FindElement(ShoppingCartPageLocators.CartQuantity).Text;
            int cartQuantity;

            // Ensure the cart quantity is parsed correctly and is not less than zero
            if (!int.TryParse(cartQtyText.Trim('(', ')'), out cartQuantity) || cartQuantity < 0)
            {
                throw new InvalidOperationException("Cart quantity cannot be less than zero.");
            }

            return cartQuantity;
        }

        // Select country from the dropdown
        public void SelectCountry(string country)
        {
            ElementActions.SelectDropdownByText(driver, ShoppingCartPageLocators.CountryDropdown, country);
        }

        // Select province based on the country
        public void SelectProvince(string country)
        {
            string province = GetProvinceForCountry(country);

            // Wait for the dropdown to be visible before interacting with it
            ElementActions.WaitForElementToBeVisible(driver, ShoppingCartPageLocators.ProvinceDropdown);

            if (!string.IsNullOrEmpty(province))
            {
                ElementActions.SelectDropdownByText(driver, ShoppingCartPageLocators.ProvinceDropdown, province);
            }
            else
            {
                ElementActions.SelectDropdownByText(driver, ShoppingCartPageLocators.ProvinceDropdown, "Other (Non US)");
            }
        }

        // Get province for the selected country (implement logic as needed)
        private string GetProvinceForCountry(string country)
        {
           return null;
        }

        // Enter the zipcode
        public void EnterZipcode(string zipcode)
        {
            ElementActions.EnterText(driver, ShoppingCartPageLocators.ZipcodeField, zipcode);
        }

        // Agree to terms and conditions
        public void AgreeToTerms()
        {
            ElementActions.Click(driver, ShoppingCartPageLocators.AgreeToTermsCheckbox);
        }

        // Click the Checkout button
        public void ClickCheckout()
        {
            ElementActions.Click(driver, ShoppingCartPageLocators.CheckoutButton);
        }
    }
}
