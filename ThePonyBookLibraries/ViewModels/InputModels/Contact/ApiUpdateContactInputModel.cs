using System.ComponentModel.DataAnnotations;

namespace ThePonyBookLibraries.ViewModels.InputModels.Contact
{
    public class ApiUpdateContactInputModel : ApiContactInputModelBase 
    {
        [Required]
        public int Id { get; set; }
    }
}
