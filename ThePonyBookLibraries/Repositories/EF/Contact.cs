using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThePonyBookLibraries.Repositories.EF
{
    [Table("Contact")]
    public class Contact
    {
        public Contact()
        {
            ContactPhones = new HashSet<ContactPhone>();
            ContactAddresses = new HashSet<ContactAddress>();
        }

        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }

        [StringLength(256)]
        public string Email { get; set; }

        [StringLength(256)]
        public string FirstName { get; set; }

        [StringLength(256)]
        public string LastName { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

        public virtual ICollection<ContactPhone> ContactPhones { get; set; }

        public virtual ICollection<ContactAddress> ContactAddresses { get; set; }
    }
}
