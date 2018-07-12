using System.ComponentModel.DataAnnotations;

namespace ThePonyBookLibraries.ViewModels.InputModels
{
    public abstract class ApiContactInputModelBase
    {
        [StringLength(256)]
        public string Email { get; set; }

        [StringLength(256)]
        public string FirstName { get; set; }

        [StringLength(256)]
        public string LastName { get; set; }
    }
}
