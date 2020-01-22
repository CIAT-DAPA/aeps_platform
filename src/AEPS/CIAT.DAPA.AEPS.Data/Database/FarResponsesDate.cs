using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CIAT.DAPA.AEPS.Data.Database
{
    [Table("far_responses_date")]
    public partial class FarResponsesDate
    {
        [Column("id", TypeName = "bigint(20)")]
        public long Id { get; set; }
        [Column("event", TypeName = "bigint(20)")]
        public long Event { get; set; }
        [Column("question", TypeName = "int(11)")]
        public int Question { get; set; }
        [Column("raw_value")]
        public DateTime? RawValue { get; set; }
        [Column("fixed_value")]
        public DateTime? FixedValue { get; set; }
        [Column("validated", TypeName = "tinyint(4)")]
        public byte Validated { get; set; }

        [ForeignKey("Event")]
        [InverseProperty("FarResponsesDate")]
        public virtual FarProductionEvents EventNavigation { get; set; }
        [ForeignKey("Question")]
        [InverseProperty("FarResponsesDate")]
        public virtual FrmQuestions QuestionNavigation { get; set; }
    }
}
