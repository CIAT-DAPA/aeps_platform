using System;
using System.Collections.Generic;
using System.Text;

namespace CIAT.DAPA.AEPS.ODK.Models
{
    /// <summary>
    /// This class represents the choices sheet in XLS Form
    /// </summary>
    public class Choice
    {
        public string ListName { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public string[] Others { get; set; }

        public Choice()
        {

        }
    }
}
