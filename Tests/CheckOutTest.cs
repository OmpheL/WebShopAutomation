using NUnit.Framework;
using OpenQA.Selenium;
using WebShopAutomation.Pages;
using WebShopAutomation.Utilities;
using AventStack.ExtentReports;
using WebShopAutomation.Reporting;
using System;

namespace WebShopAutomation.Tests
{
    [TestFixture]
    public class CheckOutTest : BaseClass
    {
        private LoginPage loginPage;
        private HomePage homePage;
        private LandingPage landingPage;
        private CreateJewelryPage createJewelryPage;
        private ShoppingCartPage shoppingCartPage;
        private CheckOutPage checkOutPage;
        private UserProfileData userData;
        private ShippingData shippingData;
        private BillingData billingData;
        private PaymentData paymentData;
        private ExtentTest extentTest;
        private UsersRoot usersRoot;

        [SetUp]
        public new void SetUp()
        {
            base.SetUp(); // Call the base class's SetUp method

            // Load user data from JSON file
            usersRoot = DataLoader.LoadUsersFromJson(Resources.FilePathManager.FilePath);

            var user = usersRoot.Users[0]; // Example: Using the first user

            userData = user.UserProfileData;
            shippingData = user.ShippingData;
            paymentData = user.PaymentData;
            billingData = user.BillingData;

            // Initialize the page objects
            loginPage = new LoginPage(driver);
            homePage = new HomePage(driver);
            landingPage = new LandingPage(driver);
            createJewelryPage = new CreateJewelryPage(driver);
            shoppingCartPage = new ShoppingCartPage(driver);
            checkOutPage = new CheckOutPage(driver);

            // Initialize Extent Report
            extentTest = ReportManager.GetExtentReports().CreateTest(TestContext.CurrentContext.Test.Name);

            // Perform login actions
            LogIn(userData);

            // Navigate to the Shopping Cart
            createJewelryPage.ClickShoppingCart();
            extentTest.Info("Navigated to Shopping Cart.");
        }

        private void LogIn(UserProfileData user)
        {
            landingPage.ClickLoginLink();
            extentTest.Info("Clicked on the Login link.");

            loginPage.EnterEmail(user.Email);
            loginPage.EnterPassword(user.Password);
            loginPage.ClickLoginButton();
            extentTest.Info("Logged in with email: " + user.Email);
        }

        [Test, Order(14)]
        public void TestCheckoutProcess()
        {
            try
            {
                // Perform checkout steps
                PerformCheckoutSteps();

                // Validate the order confirmation message and redirection
                ValidateOrderConfirmation();
            }
            catch (Exception ex)
            {
                extentTest.Fail($"Test failed with exception: {ex.Message}");
                throw; // Re-throw the exception to ensure NUnit handles it
            }
        }

        private void PerformCheckoutSteps()
        {
            // Select a country
            shoppingCartPage.SelectCountry(shippingData.Country);
            extentTest.Info($"Selected country: {shippingData.Country}");

            // Select the province based on the country
        // shoppingCartPage.SelectProvince(shippingData.Province);
        // extentTest.Info($"Selected province for country: {shippingData.Country}");

            // Enter the zipcode
            shoppingCartPage.EnterZipcode(shippingData.Zipcode);
            extentTest.Info($"Entered zipcode: {shippingData.Zipcode}");

            // Agree to terms and conditions
            shoppingCartPage.AgreeToTerms();
            extentTest.Info("Agreed to terms and conditions.");

            // Click the checkout button
            shoppingCartPage.ClickCheckout();
            extentTest.Info("Clicked on Checkout button.");

            // Continue through the checkout process
            CompleteCheckoutSteps();
        }

        private void CompleteCheckoutSteps()
        {

            checkOutPage.SelectAddressOption("New Address");
            // Select Address Option
            checkOutPage.SelectCountry(shippingData.Country);
            checkOutPage.SelectState(shippingData.Province);
            checkOutPage.EnterCity(billingData.City);
            checkOutPage.EnterAddress1(billingData.Address1);
            checkOutPage.EnterAddress2(billingData.Address2);
            checkOutPage.EnterZipCode(shippingData.Zipcode);
            checkOutPage.EnterPhoneNumber(billingData.PhoneNumber);

            // Click "Continue" on the billing page
            checkOutPage.ClickBillingAddressContinue();
            extentTest.Info("Clicked on 'Continue' for Billing Address.");

            // Click "Continue" on the shipping address page
            checkOutPage.ClickShippingAddressContinue();
            extentTest.Info("Clicked on 'Continue' for Shipping Address.");

            // Select Shipping Method
            checkOutPage.SelectShippingMethod(shippingData.ShippingMethod);
            extentTest.Info($"Selected shipping method: {shippingData.ShippingMethod}");

            // Click "Continue" after selecting the shipping method
            checkOutPage.ClickShippingMethodContinue();
            extentTest.Info("Clicked on 'Continue' after selecting shipping method.");

            // Select Payment Method
            checkOutPage.SelectPaymentMethod(paymentData.PaymentMethod);
            extentTest.Info($"Selected payment method: {paymentData.PaymentMethod}");

            checkOutPage.ClickPaymentMethodContinue();

            // Conditional logic for different payment methods
            if (paymentData.PaymentMethod == "Credit Card")
            {
                // Enter Credit Card Details
                checkOutPage.EnterCreditCardDetails(
                    paymentData.CardType,
                    paymentData.CardHolderName,
                    paymentData.CardNumber,
                    paymentData.ExpirationMonth,
                    paymentData.ExpirationYear,
                    paymentData.CardCode);
                extentTest.Info("Entered credit card details.");
            }
            else if (paymentData.PaymentMethod == "Purchase Order")
            {
                // Enter Purchase Order Number
                checkOutPage.EnterPONumber("PO123456");
                extentTest.Info("Entered purchase order number.");
            }

            // Click "Continue" after entering the payment info
            checkOutPage.ClickPaymentInfoContinue();
            extentTest.Info("Clicked on 'Continue' after entering payment info.");

            // Click "Confirm" to place the order
            checkOutPage.ClickConfirmButtonContinue();
            extentTest.Info("Clicked on 'Confirm' to place the order.");
        }

        private void ValidateOrderConfirmation()
        {
            string confirmationMessage = checkOutPage.GetConfirmationMessage();
            Assert.That(confirmationMessage.Contains("successfully processed!"),
                          "Order confirmation message is incorrect or missing.");
            extentTest.Info("Order confirmation message is correct.");

            // Assert that the user is redirected to the homepage
            string actualUrl = checkOutPage.GetCurrentPageUrl();
            string expectedUrl = "https://demowebshop.tricentis.com/checkout/completed/";
            Assert.That(actualUrl, Is.EqualTo(expectedUrl), "User was not redirected to the Checkout Completed Page after clicking 'Continue'.");
            extentTest.Info($"User was redirected to Checkout Completed Page: {expectedUrl}");

            extentTest.Pass("Checkout process completed successfully.");
        }

        [TearDown]
        public new void TearDown()
        {
            // Flush the ExtentReports after the test
            ReportManager.FlushReports();

            base.TearDown(); // Call the base class's TearDown method
        }
    }
}
