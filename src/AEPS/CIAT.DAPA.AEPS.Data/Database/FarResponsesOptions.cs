using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CIAT.DAPA.AEPS.Data.Database
{
    [Table("far_responses_options", Schema = "aeps_2_0")]
    public partial class FarResponsesOptions
    {
        [Column("id", TypeName = "bigint(20)")]
        public long Id { get; set; }
        [Column("event", TypeName = "bigint(20)")]
        public long Event { get; set; }
        [Column("question", TypeName = "int(11)")]
        public int Question { get; set; }
        [Column("option", TypeName = "int(11)")]
        public int Option { get; set; }
        [Required]
        [Column("value")]
        [StringLength(250)]
        public string Value { get; set; }

        [ForeignKey("Event")]
        [InverseProperty("FarResponsesOptions")]
        public FarProductionEvents EventNavigation { get; set; }
        [ForeignKey("Option")]
        [InverseProperty("FarResponsesOptions")]
        public FrmOptions OptionNavigation { get; set; }
        [ForeignKey("Question")]
        [InverseProperty("FarResponsesOptions")]
        public FrmQuestions QuestionNavigation { get; set; }
    }
}
