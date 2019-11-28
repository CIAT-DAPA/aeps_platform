using CIAT.DAPA.AEPS.Data.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CIAT.DAPA.AEPS.Data.Database
{
    [Table("frm_forms_settings", Schema = "aeps_2_0")]
    public partial class FrmFormsSettings
    {
        public FrmFormsSettings()
        {
        }
        [Display(Name = "FrmFormsSettingsId", ResourceType = typeof(Resource))]
        [Column("id", TypeName = "int(11)")]
        public int Id { get; set; }
        [Display(Name = "FrmFormsSettingsForm", ResourceType = typeof(Resource))]
        [Column("form", TypeName = "int(11)")]
        public int Form { get; set; }
        [Display(Name = "FrmFormsSettingsApp", ResourceType = typeof(Resource))]
        [Required]
        [Column("app", TypeName = "enum('all','odk','pdi')")]
        public string App { get; set; }
        [Display(Name = "FrmFormsSettingsName", ResourceType = typeof(Resource))]
        [Required]
        [Column("name")]
        public string Name { get; set; }
        [Display(Name = "FrmFormsSettingsValue", ResourceType = typeof(Resource))]
        [Required]
        [Column("value")]
        public string Value { get; set; }
        [Display(Name = "FrmFormsSettingsCreated", ResourceType = typeof(Resource))]
        [Column("created")]
        public DateTime Created { get; set; }
        [Display(Name = "FrmFormsSettingsUpdated", ResourceType = typeof(Resource))]
        [Column("updated")]
        public DateTime Updated { get; set; }

        [Display(Name = "FrmFormsSettingsFormsNavigation", ResourceType = typeof(Resource))]
        [ForeignKey("Form")]
        [InverseProperty("FrmFormsSettings")]
        public virtual FrmForms FormNavigation { get; set; }
    }
}
