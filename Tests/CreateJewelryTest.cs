using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using WebShopAutomation.Pages;
using WebShopAutomation.Utilities;
using WebShopAutomation.Reporting;

namespace WebShopAutomation.Tests
{
    [TestFixture]
    public class CreateJewelryTest : BaseClass
    {
        private LoginPage loginPage;
        private HomePage homePage;
        private LandingPage landingPage;
        private CreateJewelryPage createJewelryPage;
        private ExtentTest extentTest;
        private UserProfileData userProfileData;
        private JewelryData jewelryData;
        private UsersRoot usersRoot;

        [SetUp]
        public new void SetUp()
        {
            base.SetUp(); // Call the base class's SetUp method

            // Initialize page objects
            loginPage = new LoginPage(driver);
            homePage = new HomePage(driver);
            landingPage = new LandingPage(driver);
            createJewelryPage = new CreateJewelryPage(driver);

            // Load user and jewelry data from JSON file
            usersRoot = DataLoader.LoadUsersFromJson(Resources.FilePathManager.FilePath);
            userProfileData = usersRoot.Users[0].UserProfileData;
            jewelryData = usersRoot.Users[0].JewelryData;

            // Initialize Extent Report
            extentTest = ReportManager.GetExtentReports().CreateTest(TestContext.CurrentContext.Test.Name);

            // Log in to the application
            landingPage.ClickLoginLink();
            extentTest.Info("Clicked on the Login link.");
            loginPage.EnterEmail(userProfileData.Email);
            loginPage.EnterPassword(userProfileData.Password);
            loginPage.ClickLoginButton();
            extentTest.Info("Logged in with email: " + userProfileData.Email);

            // Navigate to Create Jewelry page
            homePage.SelectJewelryCategory();
            homePage.ClickCreateYourOwnJewelry();
        }

        [Test, Order(11)]
        public void TestNavigateJewelryPage()
        {
            extentTest = ReportManager.GetExtentReports().CreateTest(TestContext.CurrentContext.Test.Name);

            try
            {
                // Perform actions on Create Jewelry page
                createJewelryPage.SelectOptionFromDropdown(jewelryData.Material);
                createJewelryPage.EnterLengthInCM(jewelryData.LengthInCM);
                createJewelryPage.SelectRadioButton(jewelryData.Shape);
                createJewelryPage.SetQuantity(jewelryData.Quantity);

                // Verify setting an out-of-range quantity throws an exception
                Assert.Throws<ArgumentOutOfRangeException>(() => createJewelryPage.SetQuantity(60),
                    "Expected ArgumentOutOfRangeException when setting quantity to 60.");

                createJewelryPage.ClickAddToCart();
                createJewelryPage.ClickShoppingCart();

                extentTest.Pass("Successfully completed navigation and actions on the Create Jewelry page.");
            }
            catch (Exception ex)
            {
                extentTest.Fail($"Test failed with exception: {ex.Message}");
                throw; // Re-throw the exception to ensure NUnit handles it
            }
        }

        [Test, Order(12)]
        public void TestClickDemoWorkShopLogoReturnsToHomepage()
        {
            extentTest = ReportManager.GetExtentReports().CreateTest(TestContext.CurrentContext.Test.Name);

            try
            {
                homePage.ClickDemoWorkShopLogo();
                extentTest.Info("Clicked on the Demo Work Shop logo.");

                string expectedUrl = "https://demowebshop.tricentis.com/";
                string actualUrl = driver.Url;

                Assert.That(actualUrl, Is.EqualTo(expectedUrl), "The URL after clicking the logo did not match the expected value.");
                extentTest.Pass("Successfully verified that clicking the Demo Work Shop logo returns to the homepage.");
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
            // Flush the ExtentReports after the test
            ReportManager.FlushReports();

            base.TearDown(); // Call the base class's TearDown method
        }
    }
}
