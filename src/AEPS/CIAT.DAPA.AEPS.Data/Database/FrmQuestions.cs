using CIAT.DAPA.AEPS.Data.Resources;
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
            FrmQuestionsRules = new HashSet<FrmQuestionsRules>();
        }
        [Display(Name = "FrmQuestionsId", ResourceType = typeof(Resource))]
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }
        [Display(Name = "FrmQuestionsBlock", ResourceType = typeof(Resource))]
        [Column("block", TypeName = "int(11)")]
        public int Block { get; set; }
        [Display(Name = "FrmQuestionsName", ResourceType = typeof(Resource))]
        [Required]
        [Column("name")]
        [StringLength(250)]
        public string Name { get; set; }
        [Display(Name = "FrmQuestionsLabel", ResourceType = typeof(Resource))]
        [Required]
        [Column("label")]
        [StringLength(400)]
        public string Label { get; set; }
        [Display(Name = "FrmQuestionsDescription", ResourceType = typeof(Resource))]
        [Required]
        [Column("description")]
        [StringLength(500)]
        public string Description { get; set; }
        [Display(Name = "FrmQuestionsType", ResourceType = typeof(Resource))]
        [Required]
        [Column("type", TypeName = "enum('string','int','double','bool','date','time','datetime','unique','multiple')")]
        public string Type { get; set; }
        [Display(Name = "FrmQuestionsOrder", ResourceType = typeof(Resource))]
        [Column("order", TypeName = "int(11)")]
        public int Order { get; set; }
        [Display(Name = "FrmQuestionsEnable", ResourceType = typeof(Resource))]
        [Column("enable", TypeName = "tinyint(4)")]
        public byte Enable { get; set; }
        [Display(Name = "FrmQuestionsExtId", ResourceType = typeof(Resource))]
        [Column("ext_id")]
        [StringLength(100)]
        public string ExtId { get; set; }
        [Display(Name = "FrmQuestionsCreated", ResourceType = typeof(Resource))]
        [Column("created")]
        public DateTime Created { get; set; }
        [Display(Name = "FrmQuestionsUpdated", ResourceType = typeof(Resource))]
        [Column("updated")]
        public DateTime Updated { get; set; }

        [Display(Name = "FrmQuestionsBlockNavigation", ResourceType = typeof(Resource))]
        [ForeignKey("Block")]
        [InverseProperty("FrmQuestions")]
        public virtual FrmBlocks BlockNavigation { get; set; }
        [InverseProperty("QuestionNavigation")]
        public virtual ICollection<FarAnswers> FarAnswers { get; set; }
        [InverseProperty("QuestionNavigation")]
        public virtual ICollection<FarResponsesBool> FarResponsesBool { get; set; }
        [InverseProperty("QuestionNavigation")]
        public virtual ICollection<FarResponsesDate> FarResponsesDate { get; set; }
        [InverseProperty("QuestionNavigation")]
        public virtual ICollection<FarResponsesNumeric> FarResponsesNumeric { get; set; }
        [InverseProperty("QuestionNavigation")]
        public virtual ICollection<FarResponsesOptions> FarResponsesOptions { get; set; }
        [InverseProperty("QuestionNavigation")]
        public virtual ICollection<FarResponsesText> FarResponsesText { get; set; }
        [InverseProperty("QuestionNavigation")]
        public virtual ICollection<FrmOptions> FrmOptions { get; set; }
        [InverseProperty("QuestionNavigation")]
        public virtual ICollection<FrmQuestionsRules> FrmQuestionsRules { get; set; }
    }
}
