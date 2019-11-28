using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CIAT.DAPA.AEPS.ODK.Enums
{
    public enum EnumSettingsFields
    {
        [Description("form_title")]
        form_title,
        [Description("form_id")]
        form_id,
        [Description("public_key")]
        public_key,
        [Description("submission_url")]
        submission_url,
        [Description("instance_name")]
        instance_name,
        [Description("version")]
        version
    }
}
