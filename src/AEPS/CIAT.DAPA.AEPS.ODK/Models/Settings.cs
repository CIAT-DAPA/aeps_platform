using System;
using System.Collections.Generic;
using System.Text;

namespace CIAT.DAPA.AEPS.ODK.Models
{
    /// <summary>
    /// This class represents the settings sheet in XLS Form
    /// </summary>
    public class Settings
    {
        public string FormTitle { get; set; }
        public string FormId { get; set; }
        public string PublicKey { get; set; }
        public string SubmissionUrl { get; set; }
        public string InstanceName { get; set; }
        public string Version { get; set; }

        public Settings()
        {

        }
    }
}
