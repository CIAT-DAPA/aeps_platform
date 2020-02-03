using CIAT.DAPA.AEPS.Data.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CIAT.DAPA.AEPS.Data.Database
{
    [Table("con_states")]
    public partial class ConStates
    {
        public ConStates()
        {
            ConMunicipalities = new HashSet<ConMunicipalities>();
        }
        [Display(Name = "ConStatesId", ResourceType = typeof(Resource))]
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }
        [Display(Name = "ConStatesCountry", ResourceType = typeof(Resource))]
        [Column("country", TypeName = "int(11)")]
        public int Country { get; set; }
        [Display(Name = "ConStatesName", ResourceType = typeof(Resource))]
        [Required]
        [Column("name")]
        [StringLength(150)]
        public string Name { get; set; }
        [Display(Name = "ConStatesExtId", ResourceType = typeof(Resource))]
        [Column("ext_id")]
        [StringLength(100)]
        public string ExtId { get; set; }
        [Display(Name = "ConStatesCreated", ResourceType = typeof(Resource))]
        [Column("created")]
        public DateTime Created { get; set; }
        [Display(Name = "ConStatesUpdated", ResourceType = typeof(Resource))]
        [Column("updated")]
        public DateTime Updated { get; set; }

        [Display(Name = "ConStatesCountryNavigation", ResourceType = typeof(Resource))]
        [ForeignKey("Country")]
        [InverseProperty("ConStates")]
        public virtual ConCountries CountryNavigation { get; set; }
        [InverseProperty("StateNavigation")]
        public virtual ICollection<ConMunicipalities> ConMunicipalities { get; set; }
    }
}
