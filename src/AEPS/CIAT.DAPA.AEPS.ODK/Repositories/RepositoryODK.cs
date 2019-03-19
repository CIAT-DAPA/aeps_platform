using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CIAT.DAPA.AEPS.ODK.Repositories
{
    public abstract class RepositoryODK<T, T2>
    {
        // Variables
        protected ExcelWorksheet worksheet;

        // Properties
        /// <summary>
        /// Gets or sets the records in the worksheet survey
        /// </summary>
        public List<T> Records { get; private set; }

        /// <summary>
        /// Get or set the sheet header
        /// </summary>
        public Dictionary<T2, int> Header { get; set; }

        /// <summary>
        /// Method Construct
        /// </summary>
        /// <param name=package>Excel document</param>
        public RepositoryODK(ExcelPackage package)
        {
            worksheet = package.Workbook.Worksheets["survey"];
            Header = new Dictionary<T2, int>();
            Records = new List<T>();
        }

        /// <summary>
        /// Method which gets the position of fields
        /// </summary>
        public virtual async Task<bool> LoadHeaderAsync()
        {
            int cols = worksheet.Dimension.Columns;
            string f = string.Empty;
            List<string> fields = new List<string>(Enum.GetNames(typeof(T2)));
            await Task.Run(() =>
            {
                for (int i = 1; i <= cols; i++)
                {
                    f = worksheet.Cells[1, i].Value == null ? string.Empty : worksheet.Cells[1, i].Value.ToString().ToLower().Trim();
                    if (fields.Contains(f))
                        Header.Add((T2)Enum.Parse(typeof(T2), f, true), i);
                }
            });
            return true;
        }

        /// <summary>
        /// Method which load a row from survey worksheet
        /// </summary>
        /// <param name="rows">Rows of the worksheet</param>
        /// <param name="index">Index of the row</param>
        /// <returns>Survey</returns>
        public abstract T LoadRow(ExcelRange rows, int index);

        /// <summary>
        /// Method which loads the records
        /// </summary>
        public abstract Task<bool> LoadRecordsAsync();

        /// <summary>
        /// Method that load a worksheet
        /// </summary>
        /// <returns></returns>
        public async Task<bool> LoadContentAsync()
        {
            await LoadHeaderAsync();
            await LoadRecordsAsync();
            return true;
        }
    }
}
