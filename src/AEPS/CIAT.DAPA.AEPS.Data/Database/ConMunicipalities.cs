using CIAT.DAPA.AEPS.Data.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CIAT.DAPA.AEPS.Data.Database
{
    [Table("con_municipalities")]
    public partial class ConMunicipalities
    {
        public ConMunicipalities()
        {
            SocPeople = new HashSet<SocPeople>();
        }
        [Display(Name = "ConMunicipalitiesId", ResourceType = typeof(Resource))]
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }
        [Display(Name = "ConMunicipalitiesState", ResourceType = typeof(Resource))]
        [Column("state", TypeName = "int(11)")]
        public int State { get; set; }
        [Display(Name = "ConMunicipalitiesName", ResourceType = typeof(Resource))]
        [Required]
        [Column("name")]
        [StringLength(150)]
        public string Name { get; set; }
        [Display(Name = "ConMunicipalitiesExtId", ResourceType = typeof(Resource))]
        [Column("ext_id")]
        [StringLength(100)]
        public string ExtId { get; set; }
        [Display(Name = "ConMunicipalitiesCreated", ResourceType = typeof(Resource))]
        [Column("created")]
        public DateTime Created { get; set; }
        [Display(Name = "ConMunicipalitiesUpdate", ResourceType = typeof(Resource))]
        [Column("updated")]
        public DateTime Updated { get; set; }

        [Display(Name = "ConMunicipalitiesStateNavigation", ResourceType = typeof(Resource))]
        [ForeignKey("State")]
        [InverseProperty("ConMunicipalities")]
        public virtual ConStates StateNavigation { get; set; }
        [InverseProperty("MunicipalityNavigation")]
        public virtual ICollection<SocPeople> SocPeople { get; set; }
    }
}
