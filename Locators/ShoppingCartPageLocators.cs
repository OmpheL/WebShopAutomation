using OpenQA.Selenium;

namespace WebShopAutomation.Utilities
{
    public static class ShoppingCartPageLocators
    {
        // Shopping Cart Page Locators
        public static readonly By CartItemTitle = By.CssSelector(".cart-item-title"); 
        public static readonly By CartQuantity = By.CssSelector(".cart-qty"); 
        public static readonly By CountryDropdown = By.Id("CountryId"); 
        public static readonly By ProvinceDropdown = By.Id("StateProvinceId"); 
        public static readonly By ZipcodeField = By.Id("ZipPostalCode"); 
        public static readonly By AgreeToTermsCheckbox = By.Id("termsofservice"); 
        public static readonly By CheckoutButton = By.Id("checkout");
    }
}
