using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CIAT.DAPA.AEPS.Data.Database
{
    [Table("soc_associations", Schema = "aeps_2_0")]
    public partial class SocAssociations
    {
        public SocAssociations()
        {
            SocTechnicalAssistants = new HashSet<SocTechnicalAssistants>();
        }

        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }
        [Required]
        [Column("name")]
        [StringLength(250)]
        public string Name { get; set; }
        [Column("enable", TypeName = "tinyint(4)")]
        public byte Enable { get; set; }
        [Column("ext_id")]
        [StringLength(100)]
        public string ExtId { get; set; }
        [Column("created")]
        public DateTime Created { get; set; }
        [Column("updated")]
        public DateTime Updated { get; set; }

        [InverseProperty("AssociationNavigation")]
        public virtual ICollection<SocTechnicalAssistants> SocTechnicalAssistants { get; set; }
    }
}
