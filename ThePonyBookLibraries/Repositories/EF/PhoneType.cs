using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThePonyBookLibraries.Repositories.EF
{
    [Table("PhoneType")]
    public class PhoneType
    {
        [Key]
        public int Id { get; set; }

        [StringLength(256)]
        public string Name { get; set; }
    }
}
