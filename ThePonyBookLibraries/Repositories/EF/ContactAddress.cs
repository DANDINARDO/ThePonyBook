using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThePonyBookLibraries.Repositories.EF
{
    [Table("ContactAddress")]
    public class ContactAddress
    {
        [Key]
        public int Id { get; set; }

        public int ContactId { get; set; }

        [StringLength(256)]
        public string Address1 { get; set; }

        [StringLength(256)]
        public string Address2 { get; set; }

        [StringLength(256)]
        public string City { get; set; }

        [StringLength(256)]
        public string Region { get; set; }

        [StringLength(256)]
        public string PostalCode { get; set; }

        public virtual Country Country { get; set; }

        public virtual Contact Contact { get; set; }
    }
}
