using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CIAT.DAPA.AEPS.Data.Database
{
    [Table("aspnetuserlogins", Schema = "aeps_2_0")]
    public partial class Aspnetuserlogins
    {
        [StringLength(128)]
        public string LoginProvider { get; set; }
        [StringLength(128)]
        public string ProviderKey { get; set; }
        [StringLength(128)]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        [InverseProperty("Aspnetuserlogins")]
        public virtual Aspnetusers User { get; set; }
    }
}
