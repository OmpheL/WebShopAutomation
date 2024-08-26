WebShop Automation Test Suite
Overview
This repository contains an automated test suite for the WebShop application. The suite is built using NUnit, Selenium WebDriver, and AventStack.ExtentReports for reporting. The tests cover various functionalities of the WebShop, including user registration, login, jewelry creation, and checkout processes.

Test Cases
1. RegisterTest
Purpose: Verify the user registration process.
Tests Included:
TestClickRegisterLink: Ensures that clicking the "Register" link redirects to the correct page.
VerifyRegisterOrRegisterNewUser: Tests the registration functionality with different user data.
2. LoginTest
Purpose: Validate the user login functionality.
Tests Included:
TestClickLoginLink: Confirms that clicking the "Login" link redirects to the login page.
VerifyLogin: Tests the login process with provided user credentials.
3. HomeTest
Purpose: Test various functionalities on the home page.
Tests Included:
TestSelectJewelryCategory: Checks that selecting the "Jewelry" category navigates to the correct page.
TestClickLogout: Verifies that clicking the "Logout" link returns to the landing page.
4. CreateJewelryTest
Purpose: Test the process of creating and adding jewelry items.
Tests Included:
TestNavigateJewelryPage: Tests navigation and actions on the "Create Jewelry" page.
TestClickDemoWorkShopLogoReturnsToHomepage: Validates that clicking the logo returns to the homepage.
5. CheckOutTest
Purpose: Verify the checkout process and ensure that it completes successfully.
Tests Included:
TestCheckoutProcess: Covers the entire checkout process, including address entry, payment method selection, and order confirmation.
Setup and Execution
Install Dependencies: Ensure you have all the necessary dependencies installed, including NUnit, Selenium WebDriver, AventStack.ExtentReports, and other relevant packages.

Configure Test Data: Test data is loaded from a JSON file located in Resources.FilePathManager.FilePath. Ensure that this file is correctly set up with the required data for your tests.

Run Tests: Execute the test suite to validate the WebShop functionalities. It is recommended to run the entire suite for the best results.

Review Reports: Test results and detailed reports are generated using AventStack.ExtentReports. Check the output reports for detailed information about test execution.

Disclaimer
The data used in these tests is for test purposes only and does not reflect real data. All user profiles, shipping details, and payment information are simulated for testing purposes and should not be considered real or used outside the testing environment.
