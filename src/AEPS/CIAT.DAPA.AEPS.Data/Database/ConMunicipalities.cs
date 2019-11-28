using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CIAT.DAPA.AEPS.Data.Database
{
    [Table("con_municipalities", Schema = "aeps_2_0")]
    public partial class ConMunicipalities
    {
        public ConMunicipalities()
        {
            SocPeople = new HashSet<SocPeople>();
        }

        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }
        [Column("state", TypeName = "int(11)")]
        public int State { get; set; }
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

        [ForeignKey("State")]
        [InverseProperty("ConMunicipalities")]
        public virtual ConStates StateNavigation { get; set; }
        [InverseProperty("MunicipalityNavigation")]
        public virtual ICollection<SocPeople> SocPeople { get; set; }
    }
}
