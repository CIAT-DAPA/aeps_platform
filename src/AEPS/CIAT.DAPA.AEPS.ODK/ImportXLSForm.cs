using CIAT.DAPA.AEPS.ODK.Models;
using CIAT.DAPA.AEPS.ODK.Repositories;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CIAT.DAPA.AEPS.ODK
{
    /// <summary>
    /// This class allows read files in XLS Form format
    /// </summary>
    public class ImportXLSForm
    {
        /// <summary>
        /// Method Construct
        /// </summary>
        public ImportXLSForm()
        {
        }

        public async Task<XLSForm> LoadAsync(string f, string keyWordSurvey)
        {
            XLSForm xlsform = new XLSForm();
            FileInfo file = new FileInfo(f);
            using (ExcelPackage package = new ExcelPackage(file))
            {
                RepositorySurvey rSurvey = new RepositorySurvey(package,keyWordSurvey);
                RepositoryChoice rChoices = new RepositoryChoice(package);
                RepositorySettings rSettings = new RepositorySettings(package);

                await rSurvey.LoadContentAsync();
                await rChoices.LoadContentAsync();
                await rSettings.LoadContentAsync();

                xlsform.Surveys = rSurvey.Records;
                xlsform.Choices = rChoices.Records;
                xlsform.Settings = rSettings.Records[0];
            }
            return xlsform;
        }
    }
}
