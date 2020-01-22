using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CIAT.DAPA.AEPS.Data.Database
{
    [Table("far_answers")]
    public partial class FarAnswers
    {
        [Column("id", TypeName = "bigint(20)")]
        public long Id { get; set; }
        [Column("event", TypeName = "bigint(20)")]
        public long Event { get; set; }
        [Column("question", TypeName = "int(11)")]
        public int Question { get; set; }
        [Column("value_raw")]
        public string ValueRaw { get; set; }
        [Required]
        [Column("value_fixed")]
        public string ValueFixed { get; set; }
        [Column("validated", TypeName = "tinyint(4)")]
        public byte Validated { get; set; }
        [Column("created")]
        public DateTime Created { get; set; }
        [Column("updated")]
        public DateTime Updated { get; set; }

        [ForeignKey("Event")]
        [InverseProperty("FarAnswers")]
        public virtual FarProductionEvents EventNavigation { get; set; }
        [ForeignKey("Question")]
        [InverseProperty("FarAnswers")]
        public virtual FrmQuestions QuestionNavigation { get; set; }
    }
}
