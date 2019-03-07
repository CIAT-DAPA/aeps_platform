using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CIAT.DAPA.AEPS.ODK.Enums
{
    public enum EnumSurveyFields
    {
        [Description("type")]
        type,
        [Description("name")]
        name,
        [Description("label")]
        label,
        [Description("hint")]
        hint,
        [Description("required")]
        required,
        [Description("default")]
        default_value,
        [Description("constraint")]
        constraint,
        [Description("constraint_message")]
        constraint_message,
        [Description("relevant")]
        relevant,
        [Description("çalculation")]
        calculation,
        [Description("choice_filter")]
        choice_filter,
        [Description("appearance")]
        appearance
    }
}
