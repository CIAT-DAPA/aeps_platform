using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CIAT.DAPA.AEPS.Data.Database
{
    [Table("aspnetuserclaims", Schema = "aeps_2_0")]
    public partial class Aspnetuserclaims
    {
        [Column(TypeName = "int(11)")]
        public int Id { get; set; }
        [Required]
        [StringLength(128)]
        public string UserId { get; set; }
        [Column(TypeName = "longtext")]
        public string ClaimType { get; set; }
        [Column(TypeName = "longtext")]
        public string ClaimValue { get; set; }

        [ForeignKey("UserId")]
        [InverseProperty("Aspnetuserclaims")]
        public virtual Aspnetusers User { get; set; }
    }
}
