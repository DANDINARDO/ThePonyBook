using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThePonyBookLibraries.Repositories.EF
{
    [Table("VehicleGeneration")]
    public class VehicleGeneration
    {
        [Key]
        public int Id { get; set; }

        [StringLength(256)]
        public string Name { get; set; }

        [StringLength(256)]
        public string CommonName1 { get; set; }

        [StringLength(256)]
        public string CommonName2 { get; set; }

        public virtual Vehicle Vehicle { get; set; }

        public virtual VehicleGenerationYear VehicleGenerationStartYear { get; set; }

        public virtual VehicleGenerationYear VehicleGenerationEndYear { get; set; }
    }
}
