using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using WebShopAutomation.Pages;
using WebShopAutomation.Utilities;
using WebShopAutomation.Reporting;

namespace WebShopAutomation.Tests
{
    [TestFixture]
    public class HomeTest : BaseClass
    {
        private LoginPage loginPage;
        private HomePage homePage;
        private LandingPage landingPage;
        private ExtentTest? extentTest;
        private UserProfileData? userProfileData;
        private UsersRoot usersRoot;

        [SetUp]
        public new void SetUp()
        {
            base.SetUp(); // Call the base class's SetUp method

            // Initialize page objects
            landingPage = new LandingPage(driver);
            loginPage = new LoginPage(driver);
            homePage = new HomePage(driver);

            // Load user data from JSON file
            usersRoot = DataLoader.LoadUsersFromJson(Resources.FilePathManager.FilePath);
            userProfileData = usersRoot.Users[0].UserProfileData;

            // Initialize Extent Report
            extentTest = ReportManager.GetExtentReports().CreateTest(TestContext.CurrentContext.Test.Name);

            // Click the Login link
            landingPage.ClickLoginLink();
            extentTest.Info("Clicked on the Login link.");

            // Perform login steps
            loginPage.EnterEmail(userProfileData.Email);
            loginPage.EnterPassword(userProfileData.Password);
            loginPage.ClickLoginButton();

            extentTest.Info("Logged in with email: " + userProfileData.Email);
        }

        [Test, Order(9)]
        public void TestSelectJewelryCategory()
        {
            extentTest = ReportManager.GetExtentReports().CreateTest(TestContext.CurrentContext.Test.Name);

            try
            {
                homePage.SelectJewelryCategory();
                extentTest.Info("Selected the Jewelry category.");

                Assert.IsTrue(homePage.IsOnJewelryPage(), "The URL does not contain 'jewelry' after selecting the Jewelry category.");
                extentTest.Pass("Successfully verified that the URL contains 'jewelry'.");
            }
            catch (Exception ex)
            {
                extentTest.Fail($"Test failed with exception: {ex.Message}");
                throw; // Re-throw the exception to ensure NUnit handles it
            }
        }

        [Test, Order(10)]
        public void TestClickLogout()
        {
            extentTest = ReportManager.GetExtentReports().CreateTest(TestContext.CurrentContext.Test.Name);

            try
            {
                homePage.ClickLogout();
                extentTest.Info("Clicked on the Logout link.");

                Assert.That(driver.Url, Is.EqualTo("https://demowebshop.tricentis.com/"), "URL did not match expected after logout.");
                extentTest.Pass("Successfully verified that the user returns to the landing page.");
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
