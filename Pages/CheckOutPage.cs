using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using WebShopAutomation.Utilities;
using System;
using OpenQA.Selenium.DevTools.V126.CSS;

public class CheckOutPage
{
    private readonly IWebDriver driver;

    public CheckOutPage(IWebDriver driver)
    {
        this.driver = driver;
    }

    public void SelectAddressOption(string value)
    {
        ElementActions.SelectDropdownByText(driver, CheckOutPageLocators.AddressOption, value);
    }

    public void SelectCountry(string country)
    {
        ElementActions.SelectDropdownByText(driver, CheckOutPageLocators.Country, country);
    }

    public void SelectState(string state)
    {
        ElementActions.SelectDropdownByText(driver, CheckOutPageLocators.State, state);
    }

    public void EnterCity(string city)
    {
        ElementActions.EnterText(driver, CheckOutPageLocators.City, city);
    }

    public void EnterAddress1(string address1)
    {
        ElementActions.EnterText(driver, CheckOutPageLocators.Address1, address1);
    }

    public void EnterAddress2(string address2)
    {
        ElementActions.EnterText(driver, CheckOutPageLocators.Address2, address2);
    }

    public void EnterZipCode(string zipCode)
    {
        ElementActions.EnterText(driver, CheckOutPageLocators.ZipCode, zipCode);
    }

    public void EnterPhoneNumber(string phoneNumber)
    {
        ElementActions.EnterText(driver, CheckOutPageLocators.PhoneNumber, phoneNumber);
    }

   



    // Click on "Continue" for Billing Address
    public void ClickBillingAddressContinue()
    {
        ElementActions.Click(driver, CheckOutPageLocators.BillingAddressContinueButton);
    }

    // Click on "Continue" for Shipping Address
    public void ClickShippingAddressContinue()
    {
        ElementActions.Click(driver, CheckOutPageLocators.ShippingAddressContinueButton);
    }

    // Select Shipping Method based on option provided
    public void SelectShippingMethod(string option)
    {
        By shippingOptionLocator;

        switch (option.ToLower())
        {
            case "nextdayair":
                shippingOptionLocator = CheckOutPageLocators.NextDayAirOption;
                break;
            case "ground":
                shippingOptionLocator = CheckOutPageLocators.GroundOption;
                break;
            case "seconddayair":
                shippingOptionLocator = CheckOutPageLocators.SecondDayAirOption;
                break;
            default:
                throw new ArgumentException("Invalid shipping option provided");
        }

        ElementActions.Click(driver, shippingOptionLocator);
    }

    // Click "Continue" after selecting the Shipping Method
    public void ClickShippingMethodContinue()
    {
        ElementActions.Click(driver, CheckOutPageLocators.ShippingMethodAddressButton);
    }

    // Select Payment Method based on option provided
    public void SelectPaymentMethod(string option)
    {
        By paymentMethodLocator;

        switch (option.ToLower())
        {
            case "cod":
            case "cash on delivery":
                paymentMethodLocator = CheckOutPageLocators.CodPaymentMethod;
                break;
            case "check":
            case "check / money order":
                paymentMethodLocator = CheckOutPageLocators.CheckPaymentMethod;
                break;
            case "credit card":
                paymentMethodLocator = CheckOutPageLocators.CreditCardPaymentMethod;
                break;
            case "purchase order":
                paymentMethodLocator = CheckOutPageLocators.PurchaseOrderPaymentMethod;
                break;
            default:
                throw new ArgumentException("Invalid payment method provided");
        }

        ElementActions.Click(driver, paymentMethodLocator);
    }

    // Click "Continue" after selecting Payment Method
    public void ClickPaymentMethodContinue()
    {
        ElementActions.Click(driver, CheckOutPageLocators.PaymentMethodContinueButton);
    }

    // If chosen payment method is Credit Card, enter Credit Card Details
    public void EnterCreditCardDetails(string cardType, string cardHolderName, string cardNumber, string expirationMonth, string expirationYear, string cardCode)
    {
        ElementActions.SelectDropdownByText(driver, CheckOutPageLocators.CreditCardTypeDropdown, cardType);
        ElementActions.EnterText(driver, CheckOutPageLocators.CardholderNameField, cardHolderName);
        ElementActions.EnterText(driver, CheckOutPageLocators.CardNumberField, cardNumber);
        ElementActions.SelectDropdownByText(driver, CheckOutPageLocators.ExpireMonthField, expirationMonth);
        ElementActions.SelectDropdownByText(driver, CheckOutPageLocators.ExpireYearField, expirationYear);
        ElementActions.EnterText(driver, CheckOutPageLocators.CardCodeField, cardCode);
    }

    // If chosen payment method is, Enter Purchase Order number
    public void EnterPONumber(string purchaseOrderNumber)
    {
        ElementActions.EnterText(driver, CheckOutPageLocators.PurchaseOrderNumberField, purchaseOrderNumber);
    }

    // Click "Continue" after entering Payment Information
    public void ClickPaymentInfoContinue()
    {
        ElementActions.Click(driver, CheckOutPageLocators.ShippingPaymentInfoButton);
    }

    // Click "Confirm" to place the order
    public void ClickConfirmButtonContinue()
    {
        ElementActions.Click(driver, CheckOutPageLocators.ConfirmOrderButton);
    }

    // Extract the confirmation message after order is placed
    public string GetConfirmationMessage()
    {
        return driver.FindElement(CheckOutPageLocators.ConfirmationMessage).Text;
    }

    // Extract the order number after order is placed
    public string GetOrderNumber()
    {
        return driver.FindElement(CheckOutPageLocators.OrderNumber).Text;
    }

    // Click "Continue" after the order is confirmed
    public void ClickThankYouContinueButton()
    {
        ElementActions.Click(driver, CheckOutPageLocators.ThankYouContinueButton);
    }

    // Get current page URL to verify redirection
    public string GetCurrentPageUrl()
    {
        return driver.Url;
    }
}
