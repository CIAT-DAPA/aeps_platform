using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CIAT.DAPA.AEPS.Data.Database
{
    [Table("soc_people")]
    public partial class SocPeople
    {
        public SocPeople()
        {
            FarFarms = new HashSet<FarFarms>();
            SocTechnicalAssistants = new HashSet<SocTechnicalAssistants>();
        }

        [Column("id", TypeName = "bigint(20)")]
        public long Id { get; set; }
        [Column("municipality", TypeName = "int(11)")]
        public int Municipality { get; set; }
        [Required]
        [Column("kind_document", TypeName = "enum('N','P','O')")]
        public string KindDocument { get; set; }
        [Required]
        [Column("sex", TypeName = "enum('F','M','O')")]
        public string Sex { get; set; }
        [Required]
        [Column("document")]
        [StringLength(45)]
        public string Document { get; set; }
        [Required]
        [Column("name")]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [Column("last_name")]
        [StringLength(100)]
        public string LastName { get; set; }
        [Required]
        [Column("cellphone")]
        [StringLength(25)]
        public string Cellphone { get; set; }
        [Required]
        [Column("address")]
        [StringLength(100)]
        public string Address { get; set; }
        [Column("email")]
        [StringLength(500)]
        public string Email { get; set; }
        [Column("ext_id")]
        [StringLength(100)]
        public string ExtId { get; set; }
        [Column("created")]
        public DateTime Created { get; set; }
        [Column("updated")]
        public DateTime Updated { get; set; }

        [ForeignKey("Municipality")]
        [InverseProperty("SocPeople")]
        public virtual ConMunicipalities MunicipalityNavigation { get; set; }
        [InverseProperty("FarmerNavigation")]
        public virtual ICollection<FarFarms> FarFarms { get; set; }
        [InverseProperty("PersonNavigation")]
        public virtual ICollection<SocTechnicalAssistants> SocTechnicalAssistants { get; set; }
    }
}
