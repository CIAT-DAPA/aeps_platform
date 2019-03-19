using System;
using System.Collections.Generic;
using System.Text;

namespace CIAT.DAPA.AEPS.ODK.Models
{
    /// <summary>
    /// This class represents the survey sheet in XLS Form
    /// </summary>
    public class Survey
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public string Hint { get; set; }
        public string Required { get; set; }
        public string RequiredMessage { get; set; }
        public string Default { get; set; }
        public string Constraint { get; set; }
        public string ConstraintMessage { get; set; }
        public string Relevant { get; set; }
        public string ChoiceFilter { get; set; }
        public string Appearance { get; set; }
        public string Calculation { get; set; }

        public Survey()
        {

        }
    }
}
