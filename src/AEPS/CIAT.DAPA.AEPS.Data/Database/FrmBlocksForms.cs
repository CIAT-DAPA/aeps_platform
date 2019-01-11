using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CIAT.DAPA.AEPS.Data.Database
{
    [Table("frm_blocks_forms", Schema = "aeps_2_0")]
    public partial class FrmBlocksForms
    {
        [Column("form", TypeName = "int(11)")]
        public int Form { get; set; }
        [Column("block", TypeName = "int(11)")]
        public int Block { get; set; }
        [Column("order", TypeName = "int(11)")]
        public int Order { get; set; }
        [Column("enable", TypeName = "tinyint(4)")]
        public byte Enable { get; set; }
        [Column("created")]
        public DateTime Created { get; set; }
        [Column("updated")]
        public DateTime Updated { get; set; }

        [ForeignKey("Block")]
        [InverseProperty("FrmBlocksForms")]
        public virtual FrmBlocks BlockNavigation { get; set; }
        [ForeignKey("Form")]
        [InverseProperty("FrmBlocksForms")]
        public virtual FrmForms FormNavigation { get; set; }
    }
}
