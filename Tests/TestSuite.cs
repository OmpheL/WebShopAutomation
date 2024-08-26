using NUnit.Framework;

namespace WebShopAutomation.Tests
{
    [TestFixture]
    public class TestSuite
    {
        [Test]
        public void RunAllTests()
        {
            // Initialize and run LandingTest
            var landingTest = new LandingTest();
            landingTest.SetUp();
            landingTest.TestRegisterLinkPresenceAndClickability();
            landingTest.TestLoginLinkPresenceAndClickability();
            landingTest.TestClickRegisterLink();
            landingTest.TestClickLoginLink();
            landingTest.TearDown();

            // Initialize and run RegisterTest
            var registerTest = new RegisterTest();
            registerTest.SetUp();
            registerTest.TestClickRegisterLink(); // Test click on the register link
            registerTest.VerifyRegisterOrRegisterNewUser(); // Test registration functionality
            registerTest.TearDown();

            // Initialize and run LoginTest
            var loginTest = new LoginTest();
            loginTest.SetUp();
            loginTest.TestClickLoginLink(); // Test click on the login link
            loginTest.VerifyLogin(); // Test login functionality
            loginTest.TearDown();

            // Initialize and run HomeTest
            var homeTest = new HomeTest();
            homeTest.SetUp();
            homeTest.TestSelectJewelryCategory(); // Test selecting jewelry category
            homeTest.TestClickLogout(); // Test logout functionality
            homeTest.TearDown();

            // Initialize and run CreateJewelryTest
            var createJewelryTest = new CreateJewelryTest();
            createJewelryTest.SetUp();
            createJewelryTest.TestNavigateJewelryPage(); // Test actions on Create Jewelry page
            createJewelryTest.TestClickDemoWorkShopLogoReturnsToHomepage(); // Test logo redirection
            createJewelryTest.TearDown();

            // Initialize and run CheckOutTest
            var checkOutTest = new CheckOutTest();
            checkOutTest.SetUp();
            checkOutTest.TestCheckoutProcess(); // Test checkout process
            checkOutTest.TearDown();
        }
    }
}
