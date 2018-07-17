using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Owin.Security;

namespace ThePonyBookLibraries.Repositories.EF
{
    [Table("Vehicle")]
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }

        [StringLength(256)]
        public string Name { get; set; }

        public bool Active { get; set; }

        public virtual VehicleManufacturer Manufacturer { get; set; }
    }
}
