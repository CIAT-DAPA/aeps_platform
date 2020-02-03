using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CIAT.DAPA.AEPS.Data.Database
{
    [Table("soc_technical_assistants")]
    public partial class SocTechnicalAssistants
    {
        public SocTechnicalAssistants()
        {
            FarProductionEvents = new HashSet<FarProductionEvents>();
        }

        [Column("id", TypeName = "bigint(20)")]
        public long Id { get; set; }
        [Column("person", TypeName = "bigint(20)")]
        public long Person { get; set; }
        [Column("association", TypeName = "int(11)")]
        public int Association { get; set; }
        [Column("enable", TypeName = "tinyint(4)")]
        public byte Enable { get; set; }
        [Column("created")]
        public DateTime Created { get; set; }
        [Column("updated")]
        public DateTime Updated { get; set; }

        [ForeignKey("Association")]
        [InverseProperty("SocTechnicalAssistants")]
        public virtual SocAssociations AssociationNavigation { get; set; }
        [ForeignKey("Person")]
        [InverseProperty("SocTechnicalAssistants")]
        public virtual SocPeople PersonNavigation { get; set; }
        [InverseProperty("TechnicalNavigation")]
        public virtual ICollection<FarProductionEvents> FarProductionEvents { get; set; }
    }
}
