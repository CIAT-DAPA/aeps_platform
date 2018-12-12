using CIAT.DAPA.AEPS.Data.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CIAT.DAPA.AEPS.Data.Database
{
    [Table("frm_forms", Schema = "aeps_2_0")]
    public partial class FrmForms
    {
        public FrmForms()
        {
            FarProductionEvents = new HashSet<FarProductionEvents>();
            FrmBlocksForms = new HashSet<FrmBlocksForms>();
        }
        [Display(Name = "FrmFormsId", ResourceType = typeof(Resource))]
        [Column("id", TypeName = "int(11)")]        
        public int Id { get; set; }
        [Display(Name = "FrmFormsName", ResourceType = typeof(Resource))]
        [Required]
        [Column("name")]
        [StringLength(250)]
        public string Name { get; set; }
        [Display(Name = "FrmFormsTitle", ResourceType = typeof(Resource))]
        [Required]
        [Column("title")]
        [StringLength(250)]
        public string Title { get; set; }
        [Display(Name = "FrmFormsDescription", ResourceType = typeof(Resource))]
        [Required]
        [Column("description")]
        [StringLength(500)]
        public string Description { get; set; }
        [Display(Name = "FrmFormsEnable", ResourceType = typeof(Resource))]
        [Column("enable", TypeName = "tinyint(4)")]
        public byte Enable { get; set; }
        [Display(Name = "FrmFormsExtId", ResourceType = typeof(Resource))]
        [Column("ext_id")]
        [StringLength(100)]
        public string ExtId { get; set; }
        [Display(Name = "FrmFormsCreated", ResourceType = typeof(Resource))]
        [Column("created")]
        public DateTime Created { get; set; }
        [Display(Name = "FrmFormsUpdated", ResourceType = typeof(Resource))]
        [Column("updated")]
        public DateTime Updated { get; set; }

        [InverseProperty("FormNavigation")]
        public ICollection<FarProductionEvents> FarProductionEvents { get; set; }
        [InverseProperty("FormNavigation")]
        public ICollection<FrmBlocksForms> FrmBlocksForms { get; set; }
    }
}
