﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CIAT.DAPA.AEPS.Data.Database
{
    [Table("far_responses_text")]
    public partial class FarResponsesText
    {
        [Column("id", TypeName = "bigint(20)")]
        public long Id { get; set; }
        [Column("event", TypeName = "bigint(20)")]
        public long Event { get; set; }
        [Column("question", TypeName = "int(11)")]
        public int Question { get; set; }
        [Column("raw_value")]
        public string RawValue { get; set; }
        [Column("fixed_value")]
        public string FixedValue { get; set; }
        [Column("validated", TypeName = "tinyint(4)")]
        public byte Validated { get; set; }

        [ForeignKey("Event")]
        [InverseProperty("FarResponsesText")]
        public virtual FarProductionEvents EventNavigation { get; set; }
        [ForeignKey("Question")]
        [InverseProperty("FarResponsesText")]
        public virtual FrmQuestions QuestionNavigation { get; set; }
    }
}
