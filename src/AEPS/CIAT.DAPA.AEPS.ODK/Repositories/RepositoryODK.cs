using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

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
        public RepositoryODK(ExcelPackage package, string sheet)
        {
            worksheet = package.Workbook.Worksheets[sheet];
            Header = new Dictionary<T2, int>();
            Records = new List<T>();
        }

        /// <summary>
        /// Method that return the name of fields of each sheet. 
        /// It takes the description of the enum values
        /// </summary>
        /// <returns>List fields</returns>
        private List<string> GetNamesFields()
        {
            List<string> fields = new List<string>();
            foreach (T2 e in Enum.GetValues(typeof(T2)))
            {
                Type type = e.GetType();
                string name = Enum.GetName(type, e);
                if (name != null)
                {
                    var field = type.GetField(name);
                    if (field != null)
                    {
                        if (Attribute.GetCustomAttribute(field,typeof(DescriptionAttribute)) is DescriptionAttribute attr)
                        {
                            fields.Add(attr.Description);
                        }
                    }
                }
            }
            return fields;
        }

        public T2 GetEnum(string name)
        {
            var fields = GetNamesFields();
            foreach (T2 mc in Enum.GetValues(typeof(T2)))
                if (mc.ToString() == name)
                    return mc;
            foreach (T2 mc in Enum.GetValues(typeof(T2)))
                if (mc.ToString().StartsWith(name))
                    return mc;
            return default(T2);
        }

        /// <summary>
        /// Method which gets the position of fields
        /// </summary>
        public virtual async Task<bool> LoadHeaderAsync()
        {
            int cols = worksheet.Dimension.Columns;
            string f = string.Empty;
            List<string> fields = GetNamesFields();
            await Task.Run(() =>
            {
                for (int i = 1; i <= cols; i++)
                {
                    f = worksheet.Cells[1, i].Value == null ? string.Empty : worksheet.Cells[1, i].Value.ToString().ToLower().Trim();
                    if (fields.Any(p=>p.Contains(f) || p.StartsWith(f)))
                    {
                        //Header.Add((T2)Enum.Parse(typeof(T2), f, true), i);
                        Header.Add(GetEnum(f), i);
                    }
                        
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
