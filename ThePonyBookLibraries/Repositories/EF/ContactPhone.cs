﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThePonyBookLibraries.Repositories.EF
{
    [Table("ContactPhone")]
    public class ContactPhone
    {
        [Key]
        public int Id { get; set; }

        public int ContactId { get; set; }

        public int? AreaCode { get; set; }

        public int? Phone { get; set; }

        public virtual PhoneType PhoneType { get; set; }

        public virtual Contact Contact { get; set; }
    }
}
