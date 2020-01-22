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

        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }
        [Column("country", TypeName = "int(11)")]
        public int Country { get; set; }
        [Required]
        [Column("name")]
        [StringLength(150)]
        public string Name { get; set; }
        [Column("ext_id")]
        [StringLength(100)]
        public string ExtId { get; set; }
        [Column("created")]
        public DateTime Created { get; set; }
        [Column("updated")]
        public DateTime Updated { get; set; }

        [ForeignKey("Country")]
        [InverseProperty("ConStates")]
        public virtual ConCountries CountryNavigation { get; set; }
        [InverseProperty("StateNavigation")]
        public virtual ICollection<ConMunicipalities> ConMunicipalities { get; set; }
    }
}
