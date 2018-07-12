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
        public string Iso { get; set; }

        [StringLength(256)]
        public string Name { get; set; }

        [StringLength(256)]
        public string Nicename { get; set; }

        [StringLength(20)]
        public string Iso3 { get; set; }

        public int ? NumCode { get; set; }

        public int PhoneCode { get; set; }
    }
}
