namespace ThePonyBookLibraries.ViewModels.InputModels.ContactPhone
{
    public class ApiContactPhoneInputModelBase
    {
        public int ContactId { get; set; }

        public int? AreaCode { get; set; }

        public int? Phone { get; set; }

        public int? PhoneTypeId { get; set; }
    }
}
