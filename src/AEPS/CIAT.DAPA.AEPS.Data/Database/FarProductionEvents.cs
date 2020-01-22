using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CIAT.DAPA.AEPS.Data.Database
{
    [Table("far_production_events")]
    public partial class FarProductionEvents
    {
        public FarProductionEvents()
        {
            FarAnswers = new HashSet<FarAnswers>();
            FarResponsesBool = new HashSet<FarResponsesBool>();
            FarResponsesDate = new HashSet<FarResponsesDate>();
            FarResponsesNumeric = new HashSet<FarResponsesNumeric>();
            FarResponsesOptions = new HashSet<FarResponsesOptions>();
            FarResponsesText = new HashSet<FarResponsesText>();
        }

        [Column("id", TypeName = "bigint(20)")]
        public long Id { get; set; }
        [Column("plot", TypeName = "bigint(20)")]
        public long Plot { get; set; }
        [Column("form", TypeName = "int(11)")]
        public int Form { get; set; }
        [Column("technical", TypeName = "bigint(20)")]
        public long Technical { get; set; }
        [Column("enable", TypeName = "tinyint(4)")]
        public byte Enable { get; set; }
        [Column("ext_id")]
        [StringLength(100)]
        public string ExtId { get; set; }
        [Column("created")]
        public DateTime Created { get; set; }
        [Required]
        [Column("updated")]
        [StringLength(45)]
        public string Updated { get; set; }

        [ForeignKey("Form")]
        [InverseProperty("FarProductionEvents")]
        public virtual FrmForms FormNavigation { get; set; }
        [ForeignKey("Plot")]
        [InverseProperty("FarProductionEvents")]
        public virtual FarPlots PlotNavigation { get; set; }
        [ForeignKey("Technical")]
        [InverseProperty("FarProductionEvents")]
        public virtual SocTechnicalAssistants TechnicalNavigation { get; set; }
        [InverseProperty("EventNavigation")]
        public virtual ICollection<FarAnswers> FarAnswers { get; set; }
        [InverseProperty("EventNavigation")]
        public virtual ICollection<FarResponsesBool> FarResponsesBool { get; set; }
        [InverseProperty("EventNavigation")]
        public virtual ICollection<FarResponsesDate> FarResponsesDate { get; set; }
        [InverseProperty("EventNavigation")]
        public virtual ICollection<FarResponsesNumeric> FarResponsesNumeric { get; set; }
        [InverseProperty("EventNavigation")]
        public virtual ICollection<FarResponsesOptions> FarResponsesOptions { get; set; }
        [InverseProperty("EventNavigation")]
        public virtual ICollection<FarResponsesText> FarResponsesText { get; set; }
    }
}
