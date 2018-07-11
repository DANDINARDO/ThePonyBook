using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThePonyBookLibraries.Repositories.EF
{
    [Table("Country")]
    public class Country
    {
        [Key]
        public int Id { get; set; }

        [StringLength(20)]
        public string Abbreviation { get; set; }

        [StringLength(256)]
        public string CountryName { get; set; }

        public int? PhoneCountryCode { get; set; }
    }
}
