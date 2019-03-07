using CIAT.DAPA.AEPS.ODK.Enums;
using CIAT.DAPA.AEPS.ODK.Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CIAT.DAPA.AEPS.ODK.Repositories
{
    public class RepositorySurvey
    {
        // Variables
        private ExcelWorksheet worksheet;
        public Dictionary<EnumSurveyFields, int> Header;

        // Properties
        /// <summary>
        /// Gets or sets the records in the worksheet survey
        /// </summary>
        public List<Survey> Records { get; private set; }

        /// <summary>
        /// Method Construct
        /// </summary>
        /// <param name=package>Excel document</param>
        public RepositorySurvey(ExcelPackage package)
        {
            worksheet = package.Workbook.Worksheets["survey"];
            Header = new Dictionary<EnumSurveyFields, int>();
            Records = new List<Survey>();
        }

        /// <summary>
        /// Method which gets the position of fields
        /// </summary>
        public void LoadHeader()
        {
            int cols = worksheet.Dimension.Columns;
            string f = string.Empty;
            List<string> fields = new List<string>(Enum.GetNames(typeof(EnumSurveyFields)));
            for (int i = 1; i <= cols; i++)
            {
                worksheet.Cells[1, i].Value.ToString().ToLower().Trim();
                if (fields.Contains(f))
                    Header.Add((EnumSurveyFields)Enum.Parse(typeof(EnumSurveyFields), f, true), i);
            }
        }

        /// <summary>
        /// Method which load a row from survey worksheet
        /// </summary>
        /// <param name="rows">Rows of the worksheet</param>
        /// <param name="index">Index of the row</param>
        /// <returns>Survey</returns>
        private Survey LoadRow(ExcelRange rows, int index)
        {
            Survey r = new Survey()
            {
                Appearance = rows[index, Header[EnumSurveyFields.appearance]].Value.ToString() ?? string.Empty,
                ChoiceFilter = rows[index, Header[EnumSurveyFields.choice_filter]].Value.ToString() ?? string.Empty,
                Constraint = rows[index, Header[EnumSurveyFields.constraint]].Value.ToString() ?? string.Empty,
                ConstraintMessage = rows[index, Header[EnumSurveyFields.constraint_message]].Value.ToString() ?? string.Empty,
                Default = rows[index, Header[EnumSurveyFields.default_value]].Value.ToString() ?? string.Empty,
                Hint = rows[index, Header[EnumSurveyFields.hint]].Value.ToString() ?? string.Empty,
                Label = rows[index, Header[EnumSurveyFields.label]].Value.ToString() ?? string.Empty,
                Name = rows[index, Header[EnumSurveyFields.name]].Value.ToString() ?? string.Empty,
                Relevant = rows[index, Header[EnumSurveyFields.relevant]].Value.ToString() ?? string.Empty,
                Required = rows[index, Header[EnumSurveyFields.required]].Value.ToString() ?? string.Empty,
                Type = rows[index, Header[EnumSurveyFields.type]].Value.ToString() ?? string.Empty,
            };
            return r;
        }

        /// <summary>
        /// Method which loads the recor
        /// </summary>
        public async Task<bool> LoadRecordsAsync()
        {
            int rows = worksheet.Dimension.Rows;
            int rowPlot = -1;
            object value;
            string cell;

            await Task.Run(() => {
                for (int i = 1; i <= rows; i++)
                {
                    value = worksheet.Cells[i, Header[EnumSurveyFields.name]].Value;
                    cell = value.ToString() ?? string.Empty;
                    // The row is not empty and we have not found the plot variable
                    if (!string.IsNullOrEmpty(cell) && rowPlot < 0)
                    {
                        if (cell.Equals(Enum.GetName(typeof(EnumSurveyFields), "plot")))
                        {
                            rowPlot = i;
                        }
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