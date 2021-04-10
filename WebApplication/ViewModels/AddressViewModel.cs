namespace WebApplication.ViewModels
{
    public class AddressViewModel
    {
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }

        public AddressViewModel(string address, string city, string region, string postalCode, string country)
        {
            Address = address;
            City = city;
            Region = region;
            PostalCode = postalCode;
            Country = country;
        }
    }
}