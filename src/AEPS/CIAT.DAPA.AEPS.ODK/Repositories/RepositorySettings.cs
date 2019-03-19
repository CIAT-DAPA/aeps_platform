using CIAT.DAPA.AEPS.ODK.Enums;
using CIAT.DAPA.AEPS.ODK.Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CIAT.DAPA.AEPS.ODK.Repositories
{
    public class RepositorySettings : RepositoryODK<Settings, EnumSettingsFields>
    {
        /// <summary>
        /// Method construct
        /// </summary>
        /// <param name="package">Excel document</param>
        public RepositorySettings(ExcelPackage package) : base(package)
        {
        }

        /// <summary>
        /// Method which load a row from survey worksheet
        /// </summary>
        /// <param name="rows">Rows of the worksheet</param>
        /// <param name="index">Index of the row</param>
        /// <returns>Survey</returns>
        public override Settings LoadRow(ExcelRange rows, int index)
        {
            Settings r = new Settings();
            r.FormId = Header.ContainsKey(EnumSettingsFields.form_id) ? rows[index, Header[EnumSettingsFields.form_id]].Value == null ? string.Empty : rows[index, Header[EnumSettingsFields.form_id]].Value.ToString().Trim() : string.Empty;
            r.FormTitle = Header.ContainsKey(EnumSettingsFields.form_title) ? rows[index, Header[EnumSettingsFields.form_title]].Value == null ? string.Empty : rows[index, Header[EnumSettingsFields.form_title]].Value.ToString().Trim() : string.Empty;
            r.InstanceName = Header.ContainsKey(EnumSettingsFields.instance_name) ? rows[index, Header[EnumSettingsFields.instance_name]].Value == null ? string.Empty : rows[index, Header[EnumSettingsFields.instance_name]].Value.ToString().Trim() : string.Empty;
            r.PublicKey = Header.ContainsKey(EnumSettingsFields.public_key) ? rows[index, Header[EnumSettingsFields.public_key]].Value == null ? string.Empty : rows[index, Header[EnumSettingsFields.public_key]].Value.ToString().Trim() : string.Empty;
            r.SubmissionUrl = Header.ContainsKey(EnumSettingsFields.submission_url) ? rows[index, Header[EnumSettingsFields.submission_url]].Value == null ? string.Empty : rows[index, Header[EnumSettingsFields.submission_url]].Value.ToString().Trim() : string.Empty;
            r.Version = Header.ContainsKey(EnumSettingsFields.version) ? rows[index, Header[EnumSettingsFields.version]].Value == null ? string.Empty : rows[index, Header[EnumSettingsFields.version]].Value.ToString().Trim() : string.Empty;
            return r;
        }

        /// <summary>
        /// Method which loads the records
        /// </summary>
        public override async Task<bool> LoadRecordsAsync()
        {
            await Task.Run(() =>
            {
                Records.Add(LoadRow(worksheet.Cells, 2));
            });

            return true;
        }
    }
}
