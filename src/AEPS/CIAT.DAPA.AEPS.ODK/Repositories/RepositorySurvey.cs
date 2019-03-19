using CIAT.DAPA.AEPS.ODK.Enums;
using CIAT.DAPA.AEPS.ODK.Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CIAT.DAPA.AEPS.ODK.Repositories
{
    public class RepositorySurvey : RepositoryODK<Survey, EnumSurveyFields>
    {
        /// <summary>
        /// Get or set the variable name which 
        /// </summary>
        public string KeyNameRow { get; set; }

        /// <summary>
        /// Method construct
        /// </summary>
        /// <param name="package">Excel document</param>
        /// <param name="keyNameRow">Key Name Row</param>
        public RepositorySurvey(ExcelPackage package, string keyNameRow) : base(package)
        {
            KeyNameRow = keyNameRow;
        }

        /// <summary>
        /// Method which load a row from survey worksheet
        /// </summary>
        /// <param name="rows">Rows of the worksheet</param>
        /// <param name="index">Index of the row</param>
        /// <returns>Survey</returns>
        public override Survey LoadRow(ExcelRange rows, int index)
        {
            Survey r = new Survey();

            try
            {
                r.Appearance = Header.ContainsKey(EnumSurveyFields.appearance) ? rows[index, Header[EnumSurveyFields.appearance]].Value == null ? string.Empty : rows[index, Header[EnumSurveyFields.appearance]].Value.ToString().Trim() : string.Empty;
                r.ChoiceFilter = Header.ContainsKey(EnumSurveyFields.choice_filter) ? rows[index, Header[EnumSurveyFields.choice_filter]].Value == null ? string.Empty : rows[index, Header[EnumSurveyFields.choice_filter]].Value.ToString().Trim() : string.Empty;
                r.Constraint = Header.ContainsKey(EnumSurveyFields.constraint) ? rows[index, Header[EnumSurveyFields.constraint]].Value == null ? string.Empty : rows[index, Header[EnumSurveyFields.constraint]].Value.ToString().Trim() : string.Empty;
                r.ConstraintMessage = Header.ContainsKey(EnumSurveyFields.constraint_message) ? rows[index, Header[EnumSurveyFields.constraint_message]].Value == null ? string.Empty : rows[index, Header[EnumSurveyFields.constraint_message]].Value.ToString().Trim() : string.Empty;
                r.Default = Header.ContainsKey(EnumSurveyFields.default_value) ? rows[index, Header[EnumSurveyFields.default_value]].Value == null ? string.Empty : rows[index, Header[EnumSurveyFields.default_value]].Value.ToString().Trim() : string.Empty;
                r.Hint = Header.ContainsKey(EnumSurveyFields.hint) ? rows[index, Header[EnumSurveyFields.hint]].Value == null ? string.Empty : rows[index, Header[EnumSurveyFields.hint]].Value.ToString().Trim() : string.Empty;
                r.Label = Header.ContainsKey(EnumSurveyFields.label) ? rows[index, Header[EnumSurveyFields.label]].Value == null ? string.Empty : rows[index, Header[EnumSurveyFields.label]].Value.ToString().Trim() : string.Empty;
                r.Name = Header.ContainsKey(EnumSurveyFields.name) ? rows[index, Header[EnumSurveyFields.name]].Value == null ? string.Empty : rows[index, Header[EnumSurveyFields.name]].Value.ToString().Trim() : string.Empty;
                r.Relevant = Header.ContainsKey(EnumSurveyFields.relevant) ? rows[index, Header[EnumSurveyFields.relevant]].Value == null ? string.Empty : rows[index, Header[EnumSurveyFields.relevant]].Value.ToString().Trim() : string.Empty;
                r.Required = Header.ContainsKey(EnumSurveyFields.required) ? rows[index, Header[EnumSurveyFields.required]].Value == null ? string.Empty : rows[index, Header[EnumSurveyFields.required]].Value.ToString().Trim() : string.Empty;
                r.RequiredMessage = Header.ContainsKey(EnumSurveyFields.required_message) ? rows[index, Header[EnumSurveyFields.required_message]].Value == null ? string.Empty : rows[index, Header[EnumSurveyFields.required_message]].Value.ToString().Trim() : string.Empty;
                r.Type = Header.ContainsKey(EnumSurveyFields.type) ? rows[index, Header[EnumSurveyFields.type]].Value == null ? string.Empty : rows[index, Header[EnumSurveyFields.type]].Value.ToString().Trim().ToLower() : string.Empty;
                r.Calculation = Header.ContainsKey(EnumSurveyFields.calculation) ? rows[index, Header[EnumSurveyFields.calculation]].Value == null ? string.Empty : rows[index, Header[EnumSurveyFields.calculation]].Value.ToString().Trim() : string.Empty;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return r;
        }

        /// <summary>
        /// Method which loads the records
        /// </summary>
        public override async Task<bool> LoadRecordsAsync()
        {
            int rowPlot = -1;
            object value;
            string cell;

            await Task.Run(() =>
            {

                for (int i = 2; i <= worksheet.Dimension.Rows - 1; i++)
                {
                    value = worksheet.Cells[i, Header[EnumSurveyFields.name]].Value;
                    cell = value == null ? string.Empty : value.ToString().Trim();
                    // The row is not empty and we have not found the plot variable
                    if (!string.IsNullOrEmpty(cell) && rowPlot < 0)
                    {
                        if (cell.Equals(KeyNameRow))
                            rowPlot = i;
                    }
                    // Row for starting
                    else if (!string.IsNullOrEmpty(cell) && rowPlot > 0)
                    {
                        Records.Add(LoadRow(worksheet.Cells, i));
                    }
                }
            });
            return true;
        }
    }
}