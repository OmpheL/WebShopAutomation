using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using WebShopAutomation.Pages;
using WebShopAutomation.Utilities;
using WebShopAutomation.Reporting;

namespace WebShopAutomation.Tests
{
    [TestFixture]
    public class LoginTest : BaseClass
    {
        private LandingPage landingPage;
        private LoginPage loginPage;
        private ExtentTest? extentTest;
        private UsersRoot usersRoot;

        [SetUp]
        public new void SetUp()
        {
            base.SetUp(); // Call the base class's SetUp method

            // Initialize page objects
            landingPage = new LandingPage(driver);
            loginPage = new LoginPage(driver);

            // Load user data from JSON file
            usersRoot = DataLoader.LoadUsersFromJson(Resources.FilePathManager.FilePath);

            // Navigate to the Login page
            landingPage.ClickLoginLink();
        }

        [Test, Order(7)]
        public void TestClickLoginLink()
        {
            extentTest = ReportManager.GetExtentReports().CreateTest(TestContext.CurrentContext.Test.Name);

            try
            {
                // Assert: Verify that the URL contains "login" and the title contains "Login"
                Assert.That(driver.Url.Contains("login"), "The URL does not contain 'login'.");
                Assert.That(driver.Title.Contains("Login"), "The page title does not contain 'Login'.");

                extentTest.Pass("Login link clicked and page verified.");
            }
            catch (Exception ex)
            {
                extentTest.Fail($"Test failed with exception: {ex.Message}");
                throw; // Re-throw the exception to ensure NUnit handles it
            }
        }

        [Test, Order(8)]
        public void VerifyLogin()
        {
            extentTest = ReportManager.GetExtentReports().CreateTest(TestContext.CurrentContext.Test.Name);

            try
            {
                extentTest.Info("Starting test: VerifyLogin");

                // Use the first user from the loaded data
                var user = usersRoot.Users[0].UserProfileData;

                // Perform login steps
                loginPage.EnterEmail(user.Email);
                loginPage.EnterPassword(user.Password);
                loginPage.ClickLoginButton();

                // Verify login result
                bool loginSuccessful = loginPage.IsLoginSuccessful();
                bool loginErrorMessageDisplayed = !loginSuccessful && loginPage.IsLoginErrorMessageDisplayed();

                Assert.Multiple(() =>
                {
                    if (loginSuccessful)
                    {
                        extentTest.Pass("Login was successful.");
                        Assert.That(loginSuccessful, "Login was not successful.");
                    }
                    else if (loginErrorMessageDisplayed)
                    {
                        extentTest.Info("Login failed with an error message.");
                        Assert.That(loginErrorMessageDisplayed, "Login error message is not displayed as expected.");
                    }
                    else
                    {
                        extentTest.Fail("Login was not successful and no error message was displayed.");
                        Assert.Fail("Login was not successful and no error message was displayed.");
                    }
                });
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
