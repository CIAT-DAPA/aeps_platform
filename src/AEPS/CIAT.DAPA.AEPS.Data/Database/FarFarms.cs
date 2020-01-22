using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CIAT.DAPA.AEPS.Data.Database
{
    [Table("far_farms")]
    public partial class FarFarms
    {
        public FarFarms()
        {
            FarPlots = new HashSet<FarPlots>();
        }

        [Column("id", TypeName = "bigint(20)")]
        public long Id { get; set; }
        [Column("farmer", TypeName = "bigint(20)")]
        public long Farmer { get; set; }
        [Required]
        [Column("name")]
        [StringLength(250)]
        public string Name { get; set; }
        [Column("latitude")]
        public double Latitude { get; set; }
        [Column("longitude")]
        public double Longitude { get; set; }
        [Column("location_comments")]
        [StringLength(700)]
        public string LocationComments { get; set; }
        [Column("enable", TypeName = "tinyint(4)")]
        public byte Enable { get; set; }
        [Column("ext_id")]
        [StringLength(100)]
        public string ExtId { get; set; }
        [Column("created")]
        public DateTime Created { get; set; }
        [Column("updated")]
        public DateTime Updated { get; set; }

        [ForeignKey("Farmer")]
        [InverseProperty("FarFarms")]
        public virtual SocPeople FarmerNavigation { get; set; }
        [InverseProperty("FarmNavigation")]
        public virtual ICollection<FarPlots> FarPlots { get; set; }
    }
}
