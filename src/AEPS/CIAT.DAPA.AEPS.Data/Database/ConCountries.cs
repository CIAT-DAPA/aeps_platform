using CIAT.DAPA.AEPS.Data.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CIAT.DAPA.AEPS.Data.Database
{
    [Table("con_countries")]
    public partial class ConCountries
    {
        public ConCountries()
        {
            ConStates = new HashSet<ConStates>();
        }
        [Display(Name = "ConCountriesId", ResourceType = typeof(Resource))]        
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }
        [Display(Name = "ConCountriesName", ResourceType = typeof(Resource))]
        [Required]
        [Column("name")]
        [StringLength(100)]
        public string Name { get; set; }
        [Display(Name = "ConCountriesIso2", ResourceType = typeof(Resource))]
        [Required]
        [Column("iso2", TypeName = "char(2)")]
        public string Iso2 { get; set; }
        [Display(Name = "ConCountriesExtId", ResourceType = typeof(Resource))]
        [Column("ext_id")]
        [StringLength(100)]
        public string ExtId { get; set; }
        [Display(Name = "ConCountriesCreated", ResourceType = typeof(Resource))]
        [Column("created")]
        public DateTime Created { get; set; }
        [Display(Name = "ConCountriesUpdated", ResourceType = typeof(Resource))]
        [Column("updated")]
        public DateTime Updated { get; set; }

        [InverseProperty("CountryNavigation")]
        public virtual ICollection<ConStates> ConStates { get; set; }
    }
}
