using CIAT.DAPA.AEPS.Data.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CIAT.DAPA.AEPS.Data.Database
{
    [Table("frm_options")]
    public partial class FrmOptions
    {
        public FrmOptions()
        {
            FarResponsesOptions = new HashSet<FarResponsesOptions>();
        }
        [Display(Name = "FrmOptionsId", ResourceType = typeof(Resource))]
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }
        [Display(Name = "FrmOptionsQuestion", ResourceType = typeof(Resource))]
        [Column("question", TypeName = "int(11)")]
        public int Question { get; set; }
        [Display(Name = "FrmOptionsName", ResourceType = typeof(Resource))]
        [Required]
        [Column("name")]
        [StringLength(250)]
        public string Name { get; set; }
        [Display(Name = "FrmOptionsLabel", ResourceType = typeof(Resource))]
        [Required]
        [Column("label")]
        [StringLength(400)]
        public string Label { get; set; }
        [Display(Name = "FrmOptionsExtId", ResourceType = typeof(Resource))]
        [Column("ext_id")]
        [StringLength(100)]
        public string ExtId { get; set; }
        [Display(Name = "FrmOptionsEnable", ResourceType = typeof(Resource))]
        [Column("enable", TypeName = "tinyint(4)")]
        public byte Enable { get; set; }
        [Display(Name = "FrmOptionsCreated", ResourceType = typeof(Resource))]
        [Column("created")]
        public DateTime Created { get; set; }
        [Display(Name = "FrmOptionsUpdated", ResourceType = typeof(Resource))]
        [Column("updated")]
        public DateTime Updated { get; set; }

        [Display(Name = "FrmOptionsQuestionNavigation", ResourceType = typeof(Resource))]
        [ForeignKey("Question")]
        [InverseProperty("FrmOptions")]
        public virtual FrmQuestions QuestionNavigation { get; set; }
        [InverseProperty("OptionNavigation")]
        public virtual ICollection<FarResponsesOptions> FarResponsesOptions { get; set; }
    }
}
