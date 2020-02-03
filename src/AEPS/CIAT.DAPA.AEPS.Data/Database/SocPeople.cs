using CIAT.DAPA.AEPS.Data.Resources;
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
        [Display(Name = "SocPeopleId", ResourceType = typeof(Resource))]
        [Column("id", TypeName = "bigint(20)")]
        public long Id { get; set; }
        [Display(Name = "SocPeopleMunicipality", ResourceType = typeof(Resource))]
        [Column("municipality", TypeName = "int(11)")]
        public int Municipality { get; set; }
        [Display(Name = "SocPeopleKindDocument", ResourceType = typeof(Resource))]
        [Required]
        [Column("kind_document", TypeName = "enum('N','P','O')")]
        public string KindDocument { get; set; }
        [Display(Name = "SocPeopleSex", ResourceType = typeof(Resource))]
        [Required]
        [Column("sex", TypeName = "enum('F','M','O')")]
        public string Sex { get; set; }
        [Display(Name = "SocPeopleDocument", ResourceType = typeof(Resource))]
        [Required]
        [Column("document")]
        [StringLength(45)]
        public string Document { get; set; }
        [Display(Name = "SocPeopleName", ResourceType = typeof(Resource))]
        [Required]
        [Column("name")]
        [StringLength(100)]
        public string Name { get; set; }
        [Display(Name = "SocPeopleLastName", ResourceType = typeof(Resource))]
        [Required]
        [Column("last_name")]
        [StringLength(100)]
        public string LastName { get; set; }
        [Display(Name = "SocPeopleCellphone", ResourceType = typeof(Resource))]
        [Required]
        [Column("cellphone")]
        [StringLength(25)]
        public string Cellphone { get; set; }
        [Display(Name = "SocPeopleAddress", ResourceType = typeof(Resource))]
        [Required]
        [Column("address")]
        [StringLength(100)]
        public string Address { get; set; }
        [Display(Name = "SocPeopleEmail", ResourceType = typeof(Resource))]
        [Column("email")]
        [StringLength(500)]
        public string Email { get; set; }
        [Display(Name = "SocPeopleExtId", ResourceType = typeof(Resource))]
        [Column("ext_id")]
        [StringLength(100)]
        public string ExtId { get; set; }
        [Display(Name = "SocPeopleCreated", ResourceType = typeof(Resource))]
        [Column("created")]
        public DateTime Created { get; set; }
        [Display(Name = "SocPeopleUpdated", ResourceType = typeof(Resource))]
        [Column("updated")]
        public DateTime Updated { get; set; }

        [Display(Name = "SocPeopleMunicipalityNavigation", ResourceType = typeof(Resource))]
        [ForeignKey("Municipality")]
        [InverseProperty("SocPeople")]
        public virtual ConMunicipalities MunicipalityNavigation { get; set; }
        [InverseProperty("FarmerNavigation")]
        public virtual ICollection<FarFarms> FarFarms { get; set; }
        [InverseProperty("PersonNavigation")]
        public virtual ICollection<SocTechnicalAssistants> SocTechnicalAssistants { get; set; }
    }
}
