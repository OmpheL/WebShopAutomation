using NUnit.Framework;
using OpenQA.Selenium;
using WebShopAutomation.Pages;

namespace WebShopAutomation.Tests
{
    [TestFixture]
    public class LandingTest : BaseClass
    {
        private LandingPage landingPage;

        [SetUp]
        public new void SetUp()
        {
            base.SetUp(); // Call the base class's SetUp method

            // Initialize page object
            landingPage = new LandingPage(driver);
        }

        [Test, Order(1)]
        public void TestRegisterLinkPresenceAndClickability()
        {
            // Verify that the Register link is displayed
            Assert.That(landingPage.IsRegisterLinkDisplayed(), Is.True, "Register link is not displayed.");

            // Verify that the Register link is clickable
            Assert.That(landingPage.IsRegisterLinkClickable(), Is.True, "Register link is not clickable.");
        }

        [Test, Order(2)]
        public void TestLoginLinkPresenceAndClickability()
        {
            // Verify that the Login link is displayed
            Assert.That(landingPage.IsLoginLinkDisplayed(), Is.True, "Login link is not displayed.");

            // Verify that the Login link is clickable
            Assert.That(landingPage.IsLoginLinkClickable(), Is.True, "Login link is not clickable.");
        }

        [Test, Order(3)]
        public void TestClickRegisterLink()
        {
            // Click the Register link and verify the page navigation
            landingPage.ClickRegisterLink();
            Assert.That(driver.Url.Contains("register"), "URL does not contain 'register'.");
            Assert.That(driver.Title.Contains("Register"), "Page title does not contain 'Register'.");
        }

        [Test, Order(4)]
        public void TestClickLoginLink()
        {
            // Click the Login link and verify the page navigation
            landingPage.ClickLoginLink();
            Assert.That(driver.Url.Contains("login"), "URL does not contain 'login'.");
            Assert.That(driver.Title.Contains("Login"), "Page title does not contain 'Login'.");
        }

        [TearDown]
        public new void TearDown()
        {
            base.TearDown(); // Call the base class's TearDown method
        }
    }
}
