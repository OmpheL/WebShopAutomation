using System;

namespace WebShopAutomation.Utilities
{
    // Represents user profile data.
    public class UserProfileData
    {
        public string Gender { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    // Represents test data for a user, including profile, jewelry, shipping, and payment data.
    public class TestData
    {
        public UserProfileData UserProfileData { get; set; }
        public JewelryData JewelryData { get; set; }
        public ShippingData ShippingData { get; set; }
        public PaymentData PaymentData { get; set; }
        public BillingData BillingData { get; set; } // Updated type to BillingData
    }

    // Represents a collection of test data.
    public class UsersRoot
    {
        public List<TestData> Users { get; set; }
    }

    // Represents jewelry data for a user.
    public class JewelryData
    {
        public string Material { get; set; }
        public string LengthInCM { get; set; }
        public string Shape { get; set; }
        public int Quantity { get; set; }
    }

    // Represents shipping data for a user.
    public class ShippingData
    {
        public string Country { get; set; }
        public string Province { get; set; }
        public string Zipcode { get; set; }
        public string ShippingMethod { get; set; }
    }

    // Represents payment data for a user.
    public class PaymentData
    {
        public string PaymentMethod { get; set; }
        public string CardType { get; set; }
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public string ExpirationMonth { get; set; }
        public string ExpirationYear { get; set; }
        public string CardCode { get; set; }
    }

    // Represents billing data for a user.
    public class BillingData
    {
        public string City { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
    }
}
