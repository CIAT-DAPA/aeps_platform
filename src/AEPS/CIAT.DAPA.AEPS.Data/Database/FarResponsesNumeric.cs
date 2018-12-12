using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CIAT.DAPA.AEPS.Data.Database
{
    [Table("far_responses_numeric", Schema = "aeps_2_0")]
    public partial class FarResponsesNumeric
    {
        [Column("id", TypeName = "bigint(20)")]
        public long Id { get; set; }
        [Column("event", TypeName = "bigint(20)")]
        public long Event { get; set; }
        [Column("question", TypeName = "int(11)")]
        public int Question { get; set; }
        [Column("raw_value")]
        public double? RawValue { get; set; }
        [Column("fixed_value")]
        public double? FixedValue { get; set; }
        [Column("raw_units")]
        [StringLength(45)]
        public string RawUnits { get; set; }
        [Column("fixed_units")]
        [StringLength(45)]
        public string FixedUnits { get; set; }
        [Column("validated", TypeName = "tinyint(4)")]
        public byte Validated { get; set; }

        [ForeignKey("Event")]
        [InverseProperty("FarResponsesNumeric")]
        public FarProductionEvents EventNavigation { get; set; }
        [ForeignKey("Question")]
        [InverseProperty("FarResponsesNumeric")]
        public FrmQuestions QuestionNavigation { get; set; }
    }
}
