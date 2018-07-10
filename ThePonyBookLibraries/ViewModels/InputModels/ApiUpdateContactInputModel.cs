using System.ComponentModel.DataAnnotations;

namespace ThePonyBookLibraries.ViewModels.InputModels
{
    public class ApiUpdateContactInputModel : ApiContactInputModelBase 
    {
        [Required]
        public int Id { get; set; }
    }
}
