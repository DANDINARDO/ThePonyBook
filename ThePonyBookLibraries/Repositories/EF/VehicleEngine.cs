using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThePonyBookLibraries.Repositories.EF
{
    [Table("VehicleEngine")]
    public class VehicleEngine
    {
        public VehicleEngine()
        {
            VehicleEnginePlants = new HashSet<VehicleEnginePlant>();
        }

        [Key]
        public int Id { get; set; }

        [StringLength(256)]
        public string Name { get; set; }

        public int ? CID { get; set; }

        public virtual ICollection<VehicleEnginePlant> VehicleEnginePlants { get; set; }
    }
}
