using OpenQA.Selenium;

namespace WebShopAutomation.Utilities
{
    public static class CreateJewelryPageLocators
    {
        // Create Jewelry Page Locators
        public static readonly By MaterialDropdown = By.XPath("//select[@id='product_attribute_71_9_15']");
        public static readonly By LengthInCM = By.Id("product_attribute_71_10_16");
        public static readonly By LadybugRadioButton = By.Id("product_attribute_71_11_17_48");
        public static readonly By HeartRadioButton = By.Id("product_attribute_71_11_17_49");
        public static readonly By StarRadioButton = By.Id("product_attribute_71_11_17_50");
        public static readonly By NoneRadioButton = By.Id("product_attribute_71_11_17_51");
        public static readonly By QuantityField = By.Id("addtocart_71_EnteredQuantity");
        public static readonly By AddToCartButton = By.Id("add-to-cart-button-71");
        public static readonly By ShoppingCartLink = By.XPath("//a[@class=\"ico-cart\"]");
    }
}
