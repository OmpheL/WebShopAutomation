using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using WebShopAutomation.Locators;
using WebShopAutomation.Utilities;

namespace WebShopAutomation.Pages
{
    public class HomePage
    {
        private readonly IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        // Page Actions

        public void SelectJewelryCategory()
        {
            ElementActions.Click(driver, HomePageLocators.JewelryCategory);
        }

        public bool IsOnJewelryPage()
        {
            return driver.Url.Contains("jewelry");
        }

        public void ClickCreateYourOwnJewelry()
        {
          ElementActions.Click(driver, HomePageLocators.CreateYourOwnJewelry);
        }

        public void ClickDemoWorkShopLogo()
        {
            ElementActions.Click(driver, HomePageLocators.DemoWorkShopLogo);
        }

        public void ClickLogout()
        {
            ElementActions.Click(driver, HomePageLocators.LogoutLink);
        }

        public bool IsOnHomePage()
        {
            return driver.Url.Contains("home");
        }

        public bool IsOnLoginPage()
        {
            return driver.Url.Contains("login");
        }
    }
}
