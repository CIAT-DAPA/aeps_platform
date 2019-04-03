using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CIAT.DAPA.AEPS.Data.Database
{
    [Table("aspnetroles", Schema = "aeps_2_0")]
    public partial class Aspnetroles
    {
        public Aspnetroles()
        {
            Aspnetuserroles = new HashSet<Aspnetuserroles>();
        }

        [StringLength(128)]
        public string Id { get; set; }
        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        [InverseProperty("Role")]
        public virtual ICollection<Aspnetuserroles> Aspnetuserroles { get; set; }
    }
}
