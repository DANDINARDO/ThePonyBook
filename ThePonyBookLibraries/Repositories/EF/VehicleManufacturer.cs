using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThePonyBookLibraries.Repositories.EF
{
    [Table("VehicleManufacturer")]
    public class VehicleManufacturer
    {
        public VehicleManufacturer()
        {
            Vehicles = new HashSet<Vehicle>();
        }

        [Key]
        public int Id { get; set; }

        [StringLength(256)]
        public string Name { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
