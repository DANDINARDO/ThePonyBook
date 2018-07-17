using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThePonyBookLibraries.Repositories.EF
{
    [Table("VehicleGenerationYear")]
    public class VehicleGenerationYear
    {
        public VehicleGenerationYear()
        {
            VehicleGenerationYearSubmodels = new HashSet<VehicleSubmodel>();
            VehicleGenerationYearBodies = new HashSet<VehicleBody>();
        }

        [Key]
        public int Id { get; set; }

        public int Year { get; set; }

        public virtual ICollection<VehicleSubmodel> VehicleGenerationYearSubmodels { get; set; }

        public virtual ICollection<VehicleBody> VehicleGenerationYearBodies { get; set; }
    }
}
