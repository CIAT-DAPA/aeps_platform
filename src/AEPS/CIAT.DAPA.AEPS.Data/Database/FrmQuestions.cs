using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CIAT.DAPA.AEPS.Data.Database
{
    [Table("frm_questions", Schema = "aeps_2_0")]
    public partial class FrmQuestions
    {
        public FrmQuestions()
        {
            FarAnswers = new HashSet<FarAnswers>();
            FarResponsesBool = new HashSet<FarResponsesBool>();
            FarResponsesDate = new HashSet<FarResponsesDate>();
            FarResponsesNumeric = new HashSet<FarResponsesNumeric>();
            FarResponsesOptions = new HashSet<FarResponsesOptions>();
            FarResponsesText = new HashSet<FarResponsesText>();
            FrmOptions = new HashSet<FrmOptions>();
        }

        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }
        [Column("block", TypeName = "int(11)")]
        public int Block { get; set; }
        [Required]
        [Column("name")]
        [StringLength(250)]
        public string Name { get; set; }
        [Required]
        [Column("label")]
        [StringLength(400)]
        public string Label { get; set; }
        [Required]
        [Column("description")]
        [StringLength(500)]
        public string Description { get; set; }
        [Required]
        [Column("type", TypeName = "enum('string','int','double','bool','date','time','datetime','unique','multiple')")]
        public string Type { get; set; }
        [Column("order", TypeName = "int(11)")]
        public int Order { get; set; }
        [Column("enable", TypeName = "tinyint(4)")]
        public byte Enable { get; set; }
        [Column("ext_id")]
        [StringLength(100)]
        public string ExtId { get; set; }
        [Column("created")]
        public DateTime Created { get; set; }
        [Column("updated")]
        public DateTime Updated { get; set; }

        [ForeignKey("Block")]
        [InverseProperty("FrmQuestions")]
        public FrmBlocks BlockNavigation { get; set; }
        [InverseProperty("QuestionNavigation")]
        public ICollection<FarAnswers> FarAnswers { get; set; }
        [InverseProperty("QuestionNavigation")]
        public ICollection<FarResponsesBool> FarResponsesBool { get; set; }
        [InverseProperty("QuestionNavigation")]
        public ICollection<FarResponsesDate> FarResponsesDate { get; set; }
        [InverseProperty("QuestionNavigation")]
        public ICollection<FarResponsesNumeric> FarResponsesNumeric { get; set; }
        [InverseProperty("QuestionNavigation")]
        public ICollection<FarResponsesOptions> FarResponsesOptions { get; set; }
        [InverseProperty("QuestionNavigation")]
        public ICollection<FarResponsesText> FarResponsesText { get; set; }
        [InverseProperty("QuestionNavigation")]
        public ICollection<FrmOptions> FrmOptions { get; set; }
    }
}
