using System;
using System.Collections.Generic;
using System.Text;

namespace CIAT.DAPA.AEPS.ODK.Models
{
    /// <summary>
    /// This class represents a XLSForm
    /// </summary>
    public class XLSForm
    {
        public List<Survey> Surveys { get; set; }
        public List<Choice> Choices { get; set; }
        public Settings Settings { get; set; }
    }
}
