using CIAT.DAPA.AEPS.Data.Resources;
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
        [Display(Name = "SocAssociationsId", ResourceType = typeof(Resource))]
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }
        [Display(Name = "SocAssociationsName", ResourceType = typeof(Resource))]
        [Required]
        [Column("name")]
        [StringLength(250)]
        public string Name { get; set; }
        [Display(Name = "SocAssociationsEnable", ResourceType = typeof(Resource))]
        [Column("enable", TypeName = "tinyint(4)")]
        public byte Enable { get; set; }
        [Display(Name = "SocAssociationsExtId", ResourceType = typeof(Resource))]
        [Column("ext_id")]
        [StringLength(100)]
        public string ExtId { get; set; }
        [Display(Name = "SocAssociationsCreated", ResourceType = typeof(Resource))]
        [Column("created")]
        public DateTime Created { get; set; }
        [Display(Name = "SocAssociationsUpdated", ResourceType = typeof(Resource))]
        [Column("updated")]
        public DateTime Updated { get; set; }

        [InverseProperty("AssociationNavigation")]
        public virtual ICollection<SocTechnicalAssistants> SocTechnicalAssistants { get; set; }
    }
}
