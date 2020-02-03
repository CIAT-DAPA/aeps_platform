using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CIAT.DAPA.AEPS.Data.Database
{
    [Table("far_plots")]
    public partial class FarPlots
    {
        public FarPlots()
        {
            FarProductionEvents = new HashSet<FarProductionEvents>();
        }

        [Column("id", TypeName = "bigint(20)")]
        public long Id { get; set; }
        [Column("farm", TypeName = "bigint(20)")]
        public long Farm { get; set; }
        [Required]
        [Column("name")]
        [StringLength(500)]
        public string Name { get; set; }
        [Column("latitude")]
        public double Latitude { get; set; }
        [Column("longitude")]
        public double Longitude { get; set; }
        [Column("altitude")]
        public double Altitude { get; set; }
        [Column("enable", TypeName = "tinyint(4)")]
        public byte Enable { get; set; }
        [Column("ext_id")]
        [StringLength(100)]
        public string ExtId { get; set; }
        [Column("created")]
        public DateTime Created { get; set; }
        [Column("updated")]
        public DateTime Updated { get; set; }

        [ForeignKey("Farm")]
        [InverseProperty("FarPlots")]
        public virtual FarFarms FarmNavigation { get; set; }
        [InverseProperty("PlotNavigation")]
        public virtual ICollection<FarProductionEvents> FarProductionEvents { get; set; }
    }
}
