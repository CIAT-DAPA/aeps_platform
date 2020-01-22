using CIAT.DAPA.AEPS.Data.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CIAT.DAPA.AEPS.Data.Database
{
    [Table("frm_blocks")]
    public partial class FrmBlocks
    {
        public FrmBlocks()
        {
            FrmBlocksForms = new HashSet<FrmBlocksForms>();
            FrmQuestions = new HashSet<FrmQuestions>();
        }
        [Display(Name = "FrmBlocksId", ResourceType = typeof(Resource))]
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }
        [Display(Name = "FrmBlocksName", ResourceType = typeof(Resource))]
        [Required]
        [Column("name")]
        [StringLength(250)]
        public string Name { get; set; }
        [Display(Name = "FrmBlocksTitle", ResourceType = typeof(Resource))]
        [Required]
        [Column("title")]
        [StringLength(250)]
        public string Title { get; set; }
        [Display(Name = "FrmBlocksDescription", ResourceType = typeof(Resource))]
        [Required]
        [Column("description")]
        [StringLength(500)]
        public string Description { get; set; }
        [Display(Name = "FrmBlocksRepeat", ResourceType = typeof(Resource))]
        [Column("repeat", TypeName = "tinyint(4)")]
        public byte Repeat { get; set; }
        [Display(Name = "FrmBlocksTimes", ResourceType = typeof(Resource))]
        [Column("times", TypeName = "int(11)")]
        public int Times { get; set; }
        [Display(Name = "FrmBlocksEnable", ResourceType = typeof(Resource))]
        [Column("enable", TypeName = "tinyint(4)")]
        public byte Enable { get; set; }
        [Display(Name = "FrmBlocksExtId", ResourceType = typeof(Resource))]
        [Column("ext_id")]
        [StringLength(100)]
        public string ExtId { get; set; }
        [Display(Name = "FrmBlocksCreated", ResourceType = typeof(Resource))]
        [Column("created")]
        public DateTime Created { get; set; }
        [Display(Name = "FrmBlocksUpdated", ResourceType = typeof(Resource))]
        [Column("updated")]
        public DateTime Updated { get; set; }

        [InverseProperty("BlockNavigation")]
        public virtual ICollection<FrmBlocksForms> FrmBlocksForms { get; set; }
        [InverseProperty("BlockNavigation")]
        public virtual ICollection<FrmQuestions> FrmQuestions { get; set; }
    }
}
