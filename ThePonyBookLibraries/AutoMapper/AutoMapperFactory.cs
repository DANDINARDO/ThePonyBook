

using AutoMapper;
using ThePonyBookLibraries.Repositories.EF;
using ThePonyBookLibraries.ViewModels;
using ThePonyBookLibraries.ViewModels.Contact;
using ThePonyBookLibraries.ViewModels.ContactAddress;
using ThePonyBookLibraries.ViewModels.ContactPhone;
using ThePonyBookLibraries.ViewModels.Country;
using ThePonyBookLibraries.ViewModels.PhoneType;

namespace ThePonyBookLibraries.AutoMapper
{
    public class AutoMapperFactory : Profile
    {
        public AutoMapperFactory()
        {
            CreateMap<Contact, ApiContactViewModel>();
            CreateMap<ContactAddress, ApiContactAddressViewModel>();
            CreateMap<ContactPhone, ApiContactPhoneViewModel>();
            CreateMap<PhoneType, ApiPhoneTypeViewModel>();
            CreateMap<Country, ApiCountryViewModel>();
        }
    }
}