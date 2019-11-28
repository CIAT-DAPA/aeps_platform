using CIAT.DAPA.AEPS.ODK.Enums;
using CIAT.DAPA.AEPS.ODK.Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CIAT.DAPA.AEPS.ODK.Repositories
{
    public class RepositoryChoice : RepositoryODK<Choice, EnumChoiceFields>
    {
        /// <summary>
        /// Method construct
        /// </summary>
        /// <param name="package">Excel document</param>
        public RepositoryChoice(ExcelPackage package) : base(package, "choices")
        {
        }

        /// <summary>
        /// Method which load a row from survey worksheet
        /// </summary>
        /// <param name="rows">Rows of the worksheet</param>
        /// <param name="index">Index of the row</param>
        /// <returns>Survey</returns>
        public override Choice LoadRow(ExcelRange rows, int index)
        {
            Choice r = new Choice();
            r.Label = Header.ContainsKey(EnumChoiceFields.label) ? rows[index, Header[EnumChoiceFields.label]].Value == null ? string.Empty : rows[index, Header[EnumChoiceFields.label]].Value.ToString().Trim() : string.Empty;
            r.ListName = Header.ContainsKey(EnumChoiceFields.list_name) ? rows[index, Header[EnumChoiceFields.list_name]].Value == null ? string.Empty : rows[index, Header[EnumChoiceFields.list_name]].Value.ToString().Trim() : string.Empty;
            r.Name = Header.ContainsKey(EnumChoiceFields.name) ? rows[index, Header[EnumChoiceFields.name]].Value == null ? string.Empty : rows[index, Header[EnumChoiceFields.name]].Value.ToString().Trim() : string.Empty;

            return r;
        }

        /// <summary>
        /// Method which loads the records
        /// </summary>
        public override async Task<bool> LoadRecordsAsync()
        {
            object value;
            string cell;

            await Task.Run(() =>
           {
               for (int i = 2; i <= worksheet.Dimension.Rows; i++)
               {
                   value = worksheet.Cells[i, Header[EnumChoiceFields.name]].Value;
                   cell = value == null ? string.Empty : value.ToString();
                   if (!string.IsNullOrEmpty(cell))
                   {
                       Records.Add(LoadRow(worksheet.Cells, i));
                   }
               }
           });
            return true;
        }
    }
}
