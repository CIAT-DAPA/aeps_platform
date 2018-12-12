using CIAT.DAPA.AEPS.Data.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIAT.DAPA.AEPS.Data.Factory
{
    /// <summary>
    /// This class allow to access to the information about forms
    /// </summary>
    public class FactoryFrmForms : FactoryDB<FrmForms>
    {
        /// <summary>
        /// Method Construct
        /// </summary>
        /// <param name="context">Database context</param>
        public FactoryFrmForms(AEPSContext context) :base(context)
        {

        }
                
        public async override Task<FrmForms> InsertAsync(FrmForms entity)
        {
            DateTime now = DateTime.Now;
            entity.Created = now;
            entity.Updated = now;
            entity.Enable = 1;
            DB.FrmForms.Add(entity);
            await DB.SaveChangesAsync();
            return entity;
        }

        public async override Task<bool> UpdateAsync(FrmForms entity)
        {
            FrmForms model = await DB.FrmForms.FindAsync(entity.Id);
            int records = 0;
            if (model != null)
            {
                model.Description = entity.Description;
                model.ExtId = entity.ExtId;
                model.Name = entity.Name;
                model.Title = entity.Title;
                model.Updated = DateTime.Now;
                DB.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                records = await DB.SaveChangesAsync();
            }
            return records > 0;
        }

        public async override Task<bool> DisableAsync(FrmForms entity)
        {
            FrmForms model = await DB.FrmForms.SingleOrDefaultAsync(p=> p.Id == entity.Id);
            int records = 0;
            if (model != null)
            {
                model.Enable = 0;
                model.Updated = DateTime.Now;
                DB.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                records = await DB.SaveChangesAsync();
            }
            return records > 0;
        }

        /// <summary>
        /// Method that return all forms registered in the database
        /// </summary>
        /// <returns></returns>
        public async Task<List<FrmForms>> ToListAsync()
        {
            return await DB.FrmForms.ToListAsync();
        }

        /// <summary>
        /// Method that search one form by its id
        /// </summary>
        /// <param name="id">Id form</param>
        /// <returns>Form</returns>
        public async Task<FrmForms> ByIdAsync(int id)
        {
            return await DB.FrmForms.SingleOrDefaultAsync(p=>p.Id == id);
        }
    }
}