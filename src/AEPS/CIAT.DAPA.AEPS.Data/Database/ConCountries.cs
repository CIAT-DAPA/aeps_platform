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

        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }
        [Required]
        [Column("name")]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [Column("iso2", TypeName = "char(2)")]
        public string Iso2 { get; set; }
        [Column("ext_id")]
        [StringLength(100)]
        public string ExtId { get; set; }
        [Column("created")]
        public DateTime Created { get; set; }
        [Column("updated")]
        public DateTime Updated { get; set; }

        [InverseProperty("CountryNavigation")]
        public virtual ICollection<ConStates> ConStates { get; set; }
    }
}
