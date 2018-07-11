using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePonyBookLibraries.Repositories.EF
{
    [Table("PhoneType")]
    public class PhoneType
    {
        [Key]
        public int Id { get; set; }

        [StringLength(256)]
        public string PhoneTypeName { get; set; }
    }
}
