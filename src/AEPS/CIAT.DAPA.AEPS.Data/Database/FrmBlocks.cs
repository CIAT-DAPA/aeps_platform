using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CIAT.DAPA.AEPS.Data.Database
{
    [Table("frm_blocks", Schema = "aeps_2_0")]
    public partial class FrmBlocks
    {
        public FrmBlocks()
        {
            FrmBlocksForms = new HashSet<FrmBlocksForms>();
            FrmQuestions = new HashSet<FrmQuestions>();
        }

        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }
        [Required]
        [Column("name")]
        [StringLength(250)]
        public string Name { get; set; }
        [Required]
        [Column("title")]
        [StringLength(250)]
        public string Title { get; set; }
        [Required]
        [Column("description")]
        [StringLength(500)]
        public string Description { get; set; }
        [Column("repeat", TypeName = "tinyint(4)")]
        public byte Repeat { get; set; }
        [Column("times", TypeName = "int(11)")]
        public int Times { get; set; }
        [Column("enable", TypeName = "tinyint(4)")]
        public byte Enable { get; set; }
        [Column("ext_id")]
        [StringLength(100)]
        public string ExtId { get; set; }
        [Column("created")]
        public DateTime Created { get; set; }
        [Column("updated")]
        public DateTime Updated { get; set; }

        [InverseProperty("BlockNavigation")]
        public ICollection<FrmBlocksForms> FrmBlocksForms { get; set; }
        [InverseProperty("BlockNavigation")]
        public ICollection<FrmQuestions> FrmQuestions { get; set; }
    }
}
