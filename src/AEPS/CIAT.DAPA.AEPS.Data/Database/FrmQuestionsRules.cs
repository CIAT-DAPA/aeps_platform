using CIAT.DAPA.AEPS.Data.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CIAT.DAPA.AEPS.Data.Database
{
    [Table("frm_questions_rules")]
    public partial class FrmQuestionsRules
    {
        public FrmQuestionsRules()
        {
            
        }
        [Display(Name = "FrmQuestionsRulesId", ResourceType = typeof(Resource))]
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }
        [Display(Name = "FrmQuestionsRulesQuestion", ResourceType = typeof(Resource))]
        [Column("question", TypeName = "int(11)")]
        public int Question { get; set; }
        [Display(Name = "FrmQuestionsRulesApp", ResourceType = typeof(Resource))]
        [Required]
        [Column("app", TypeName = "enum('all','odk','pdi')")]
        public string App { get; set; }
        [Display(Name = "FrmQuestionsRulesType", ResourceType = typeof(Resource))]
        [Required]
        [Column("type", TypeName = "enum('required', 'constraint', 'relevant', 'appearance', 'calculation', 'choice_filter')")]
        public string Type { get; set; }
        [Display(Name = "FrmQuestionsRulesMessage", ResourceType = typeof(Resource))]
        [Column("message")]
        public string Message { get; set; }
        [Display(Name = "FrmQuestionsRulesRule", ResourceType = typeof(Resource))]
        [Required]
        [Column("rule")]
        public string Rule { get; set; }
        
        [Display(Name = "FrmQuestionsRulesQuestionsNavigation", ResourceType = typeof(Resource))]
        [ForeignKey("Question")]
        [InverseProperty("FrmQuestionsRules")]
        public virtual FrmQuestions QuestionNavigation { get; set; }
    }
}
