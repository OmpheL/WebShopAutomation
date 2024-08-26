using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using WebShopAutomation.Utilities;

namespace WebShopAutomation.Pages
{
    public class CreateJewelryPage
    {
        private readonly IWebDriver driver;
        private const int MaxQuantity = 50; // Maximum quantity allowed

        public CreateJewelryPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void SelectOptionFromDropdown(string valueToSelect)
        {
            // perform the selection action
            ElementActions.SelectDropdownByValue(driver, CreateJewelryPageLocators.MaterialDropdown, valueToSelect);
        }

        public void EnterLengthInCM(string value)
        {
            ElementActions.EnterText(driver, CreateJewelryPageLocators.LengthInCM, value);
        }

        public void SelectRadioButton(string option)
        {
            switch (option.ToLower())
            {
                case "ladybug":
                    ElementActions.ClickRadioButton(driver, CreateJewelryPageLocators.LadybugRadioButton);
                    break;
                case "heart":
                    ElementActions.ClickRadioButton(driver, CreateJewelryPageLocators.HeartRadioButton);
                    break;
                case "star":
                    ElementActions.ClickRadioButton(driver, CreateJewelryPageLocators.StarRadioButton);
                    break;
                case "none":
                    ElementActions.ClickRadioButton(driver, CreateJewelryPageLocators.NoneRadioButton);
                    break;
                default:
                    throw new ArgumentException("Invalid option provided");
            }
        }

        public void SetQuantity(int quantity)
        {
            if (quantity > MaxQuantity)
            {
                throw new ArgumentOutOfRangeException(nameof(quantity), $"The quantity cannot exceed {MaxQuantity}.");
            }

            ElementActions.EnterText(driver, CreateJewelryPageLocators.QuantityField, quantity.ToString());
        }

        public void ClickAddToCart()
        {
            ElementActions.Click(driver, CreateJewelryPageLocators.AddToCartButton);
        }

        public void ClickShoppingCart()
        {
            ElementActions.Click(driver, CreateJewelryPageLocators.ShoppingCartLink);
        }
    }
}
