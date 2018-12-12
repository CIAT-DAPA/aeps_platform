using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CIAT.DAPA.AEPS.Data.Database
{
    [Table("frm_options", Schema = "aeps_2_0")]
    public partial class FrmOptions
    {
        public FrmOptions()
        {
            FarResponsesOptions = new HashSet<FarResponsesOptions>();
        }

        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }
        [Column("question", TypeName = "int(11)")]
        public int Question { get; set; }
        [Required]
        [Column("name")]
        [StringLength(250)]
        public string Name { get; set; }
        [Required]
        [Column("label")]
        [StringLength(400)]
        public string Label { get; set; }
        [Column("ext_id")]
        [StringLength(100)]
        public string ExtId { get; set; }
        [Column("enable", TypeName = "tinyint(4)")]
        public byte Enable { get; set; }
        [Column("created")]
        public DateTime Created { get; set; }
        [Column("updated")]
        public DateTime Updated { get; set; }

        [ForeignKey("Question")]
        [InverseProperty("FrmOptions")]
        public FrmQuestions QuestionNavigation { get; set; }
        [InverseProperty("OptionNavigation")]
        public ICollection<FarResponsesOptions> FarResponsesOptions { get; set; }
    }
}
