using ThePonyBookLibraries.ViewModels.PhoneType;

namespace ThePonyBookLibraries.ViewModels.ContactPhone
{
    public class ApiContactPhoneViewModel
    {
        public int Id { get; set; }

        public int ContactId { get; set; }

        public int? AreaCode { get; set; }

        public int? Phone { get; set; }

        public ApiPhoneTypeViewModel PhoneType { get; set; }
    }
}
