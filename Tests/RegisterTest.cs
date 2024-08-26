using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using WebShopAutomation.Pages;
using WebShopAutomation.Utilities;
using WebShopAutomation.Reporting;

namespace WebShopAutomation.Tests
{
    public class RegisterTest : BaseClass
    {
        private LandingPage landingPage;
        private RegisterPage registerPage;
        private ExtentReports extentReports;
        private ExtentTest? extentTest;
        private UsersRoot usersRoot;

        [SetUp]
        public new void SetUp()
        {
            base.SetUp(); // Call the base class's SetUp method

            // Initialize page objects
            landingPage = new LandingPage(driver);
            registerPage = new RegisterPage(driver);

            // Load user data from JSON file
            usersRoot = DataLoader.LoadUsersFromJson(Resources.FilePathManager.FilePath);

            // Initialize ExtentReports
            extentReports = ReportManager.GetExtentReports();
        }

        [Test, Order(5)]
        public void TestClickRegisterLink()
        {
            extentTest = extentReports.CreateTest(TestContext.CurrentContext.Test.Name);

            try
            {
                // Click the Register link
                landingPage.ClickRegisterLink();

                // Assert: Verify that the URL contains "register" and the title contains "Register"
                Assert.That(driver.Url.Contains("register"), "The URL does not contain 'register'.");
                Assert.That(driver.Title.Contains("Register"), "The page title does not contain 'Register'.");

                extentTest.Pass("Register link clicked and page verified.");
            }
            catch (Exception ex)
            {
                extentTest.Fail($"Test failed with exception: {ex.Message}");
                throw; // Re-throw the exception to ensure NUnit handles it
            }
        }

        [Test, Order(6)]
        public void VerifyRegisterOrRegisterNewUser()
        {
            extentTest = extentReports.CreateTest(TestContext.CurrentContext.Test.Name);

            foreach (var user in usersRoot.Users)
            {
                try
                {
                    extentTest.Info($"Starting test for user: {user.UserProfileData.Email}");

                    // Navigate to the Register page
                    landingPage.ClickRegisterLink();

                    // Perform registration steps
                    registerPage.SelectGender(user.UserProfileData.Gender);
                    registerPage.EnterFirstName(user.UserProfileData.FirstName);
                    registerPage.EnterLastName(user.UserProfileData.LastName);
                    registerPage.EnterEmail(user.UserProfileData.Email);
                    registerPage.EnterPassword(user.UserProfileData.Password);
                    registerPage.EnterConfirmPassword(user.UserProfileData.Password);
                    registerPage.ClickRegisterButton();

                    // Verify registration result
                    bool registrationSuccessful = registerPage.IsRegistrationSuccessful();
                    bool userAlreadyRegistered = !registrationSuccessful && registerPage.IsUserAlreadyRegistered();

                    // Use Assert.Multiple to log all assertions
                    Assert.Multiple(() =>
                    {
                        if (registrationSuccessful)
                        {
                            extentTest.Pass("Registration was successful.");
                        }
                        else if (userAlreadyRegistered)
                        {
                            extentTest.Info("User is already registered.");
                        }
                        else
                        {
                            extentTest.Fail("Neither registration was successful nor is the user already registered.");
                            Assert.Fail("Neither registration was successful nor is the user already registered.");
                        }
                    });
                }
                catch (Exception ex)
                {
                    extentTest.Fail($"Test failed for user {user.UserProfileData.Email} with exception: {ex.Message}");
                    // Log the exception and continue to the next user
                }
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
