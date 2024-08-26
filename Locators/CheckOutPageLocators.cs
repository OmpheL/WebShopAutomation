using OpenQA.Selenium;

namespace WebShopAutomation.Utilities
{
    public static class CheckOutPageLocators
    {
        // Billing Address Continue Button
        public static readonly By AddressOption = By.XPath("//select[@id='billing-address-select']");
        public static readonly By Country = By.XPath("//select[@id='BillingNewAddress_CountryId']");
        public static readonly By State = By.XPath("//select[@id='BillingNewAddress_StateProvinceId']");
        public static readonly By City = By.XPath("//input[@id='BillingNewAddress_City']");
        public static readonly By Address1 = By.XPath("//input[@id='BillingNewAddress_Address1']");
        public static readonly By Address2 = By.XPath("//input[@id='BillingNewAddress_Address2']");
        public static readonly By ZipCode = By.XPath("//input[@id='BillingNewAddress_ZipPostalCode']");
        public static readonly By PhoneNumber = By.XPath("//input[@id='BillingNewAddress_PhoneNumber']");
     
        public static readonly By BillingAddressContinueButton = By.XPath("//input[@onclick='Billing.save()']");

        // Shipping Address Continue Button
        public static readonly By ShippingAddressContinueButton = By.XPath("//input[@onclick='Shipping.save()']");

        // Shipping Options
        public static readonly By GroundOption = By.XPath("//input[@id='shippingoption_0']");
        public static readonly By NextDayAirOption = By.XPath("//input[@id='shippingoption_1']");
        public static readonly By SecondDayAirOption = By.XPath("//input[@id='shippingoption_2']");
        public static readonly By ShippingMethodAddressButton = By.XPath("//input[@onclick='ShippingMethod.save()']");

        // Payment Methods
        public static readonly By CodPaymentMethod = By.Id("paymentmethod_0");
        public static readonly By CheckPaymentMethod = By.Id("paymentmethod_1");
        public static readonly By CreditCardPaymentMethod = By.Id("paymentmethod_2");
        public static readonly By PurchaseOrderPaymentMethod = By.Id("paymentmethod_3");

        // Payment Method Continue Button
        public static readonly By PaymentMethodContinueButton = By.XPath("//input[@class='button-1 payment-method-next-step-button']");

        // Credit Card Details
        public static readonly By CreditCardTypeDropdown = By.Id("CreditCardType");
        public static readonly By CardholderNameField = By.Id("CardholderName");
        public static readonly By CardNumberField = By.Id("CardNumber");
        public static readonly By ExpireMonthField = By.Id("ExpireMonth");
        public static readonly By ExpireYearField = By.Id("ExpireYear");
        public static readonly By CardCodeField = By.Id("CardCode");

        // Purchase Order Number
        public static readonly By PurchaseOrderNumberField = By.Id("PurchaseOrderNumber");

        // Payment Info Continue Button
        public static readonly By ShippingPaymentInfoButton = By.XPath("//input[@onclick='PaymentInfo.save()']");

        // Confirm Order Button
        public static readonly By ConfirmOrderButton = By.XPath("//input[@onclick='ConfirmOrder.save()']");

        // Confirmation and Order Details
        public static readonly By ConfirmationMessage = By.CssSelector("div.order-completed");
        public static readonly By OrderNumber = By.CssSelector("div.order-number > strong");

        // Thank You Continue Button
        public static readonly By ThankYouContinueButton = By.XPath("//input[@onclick=' setLocation('/')']");
    }
}
