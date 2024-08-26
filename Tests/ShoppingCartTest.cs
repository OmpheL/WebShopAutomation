using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using WebShopAutomation.Pages;
using WebShopAutomation.Utilities;
using WebShopAutomation.Reporting;

namespace WebShopAutomation.Tests
{
    [TestFixture]
    public class ShoppingCartTest : BaseClass
    {
        private LandingPage landingPage;
        private LoginPage loginPage;
        private HomePage homePage;
        private CreateJewelryPage createJewelryPage;
        private ShoppingCartPage shoppingCartPage;
        private ExtentTest? extentTest;
        private UsersRoot usersRoot;

        [SetUp]
        public new void SetUp()
        {
            base.SetUp(); // Call the base class's SetUp method

            // Initialize page objects
            landingPage = new LandingPage(driver);
            loginPage = new LoginPage(driver);
            homePage = new HomePage(driver);
            createJewelryPage = new CreateJewelryPage(driver);
            shoppingCartPage = new ShoppingCartPage(driver);

            // Load user data from JSON file
            usersRoot = DataLoader.LoadUsersFromJson(Resources.FilePathManager.FilePath);

            // Log in before each test
            LogIn(usersRoot.Users[0].UserProfileData);
        }

        private void LogIn(UserProfileData user)
        {
            landingPage.ClickLoginLink();
            loginPage.EnterEmail(user.Email);
            loginPage.EnterPassword(user.Password);
            loginPage.ClickLoginButton();
            extentTest?.Info($"Logged in with email: {user.Email}");
        }

        private void NavigateToShoppingCart()
        {
            homePage.SelectJewelryCategory();
            homePage.ClickCreateYourOwnJewelry();
            createJewelryPage.ClickShoppingCart();
        }

        [Test, Order(13)]
        public void TestClickShoppingCartLink()
        {
            extentTest = ReportManager.GetExtentReports().CreateTest(TestContext.CurrentContext.Test.Name);

            try
            {
                // Navigate to Shopping Cart
                NavigateToShoppingCart();

                // Assert: Verify that the Shopping Cart page is displayed
                Assert.That(driver.Url.Contains("cart"), "The URL does not contain 'cart'.");
                Assert.That(driver.Title.Contains("Cart"), "The page title does not contain 'Cart'.");

                extentTest.Pass("Shopping Cart link clicked and page verified.");
            }
            catch (Exception ex)
            {
                extentTest.Fail($"Test failed with exception: {ex.Message}");
                throw; // Re-throw the exception to ensure NUnit handles it
            }
        }

        [Test, Order(14)]
        public void TestWetherItemsAreInsertedInCart()
        {
            extentTest = ReportManager.GetExtentReports().CreateTest(TestContext.CurrentContext.Test.Name);

            try
            {
                // Navigate to Shopping Cart
                NavigateToShoppingCart();

                // Act
                extentTest.Info("Retrieving cart quantity.");
                int quantity = shoppingCartPage.GetCartQuantity();

                // Assert
                extentTest.Info("Validating cart quantity.");
                Assert.GreaterOrEqual(quantity, 1, "Cart quantity should be more than 1 item.");
                extentTest.Pass("Cart quantity validation passed.");
            }
            catch (Exception ex)
            {
                extentTest.Fail($"Test failed with exception: {ex.Message}");
                throw; // Re-throw the exception to ensure NUnit handles it
            }
        }

        [TearDown]
        public new void TearDown()
        {
            base.TearDown(); // Call the base class's TearDown method

            // Flush the ExtentReports after all tests
            ReportManager.FlushReports();
        }
    }
}
