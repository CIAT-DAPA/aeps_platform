using CIAT.DAPA.AEPS.Data.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CIAT.DAPA.AEPS.Data.Database
{
    [Table("frm_blocks_forms")]
    public partial class FrmBlocksForms
    {
        [Display(Name = "FrmBlocksFormsForm", ResourceType = typeof(Resource))]
        [Column("form", TypeName = "int(11)")]
        public int Form { get; set; }
        [Display(Name = "FrmBlocksFormsBlock", ResourceType = typeof(Resource))]
        [Column("block", TypeName = "int(11)")]
        public int Block { get; set; }
        [Display(Name = "FrmBlocksFormsOrder", ResourceType = typeof(Resource))]
        [Column("order", TypeName = "int(11)")]
        public int Order { get; set; }
        [Display(Name = "FrmBlocksFormsEnable", ResourceType = typeof(Resource))]
        [Column("enable", TypeName = "tinyint(4)")]
        public byte Enable { get; set; }
        [Display(Name = "FrmBlocksFormsCreated", ResourceType = typeof(Resource))]
        [Column("created")]
        public DateTime Created { get; set; }
        [Display(Name = "FrmBlocksFormsUpdated", ResourceType = typeof(Resource))]
        [Column("updated")]
        public DateTime Updated { get; set; }

        [Display(Name = "FrmBlocksFormsBlockNavigation", ResourceType = typeof(Resource))]
        [ForeignKey("Block")]
        [InverseProperty("FrmBlocksForms")]
        public virtual FrmBlocks BlockNavigation { get; set; }
        [Display(Name = "FrmBlocksFormsFormNavigation", ResourceType = typeof(Resource))]
        [ForeignKey("Form")]
        [InverseProperty("FrmBlocksForms")]
        public virtual FrmForms FormNavigation { get; set; }
    }
}
