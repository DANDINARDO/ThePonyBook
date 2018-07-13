using System.ComponentModel.DataAnnotations;

namespace ThePonyBookLibraries.ViewModels.InputModels.Contact
{
    public abstract class ApiContactInputModelBase
    {
        [StringLength(256)]
        public string Email { get; set; }

        [StringLength(256)]
        public string FirstName { get; set; }

        [StringLength(256)]
        public string LastName { get; set; }

        [StringLength(256)]
        public string DOB { get; set; }
    }
}
