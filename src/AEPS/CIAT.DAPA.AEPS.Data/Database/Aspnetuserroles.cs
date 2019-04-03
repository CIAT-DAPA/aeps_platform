using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CIAT.DAPA.AEPS.Data.Database
{
    [Table("aspnetuserroles", Schema = "aeps_2_0")]
    public partial class Aspnetuserroles
    {
        [StringLength(128)]
        public string UserId { get; set; }
        [StringLength(128)]
        public string RoleId { get; set; }

        [ForeignKey("RoleId")]
        [InverseProperty("Aspnetuserroles")]
        public virtual Aspnetroles Role { get; set; }
        [ForeignKey("UserId")]
        [InverseProperty("Aspnetuserroles")]
        public virtual Aspnetusers User { get; set; }
    }
}
