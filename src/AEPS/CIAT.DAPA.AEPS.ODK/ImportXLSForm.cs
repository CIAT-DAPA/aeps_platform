using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CIAT.DAPA.AEPS.ODK
{
    /// <summary>
    /// This class allows read files in XLS Form format
    /// </summary>
    public class ImportXLSForm
    {
        private FileInfo File { get; set; }

        /// <summary>
        /// Method Construct
        /// </summary>
        public ImportXLSForm(string path)
        {
            File = new FileInfo(path);
        }

        public void Read()
        {
            using (ExcelPackage package = new ExcelPackage(File))
            {
                
            }
        }
    }
}
