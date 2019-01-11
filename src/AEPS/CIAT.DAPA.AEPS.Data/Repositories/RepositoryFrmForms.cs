using CIAT.DAPA.AEPS.Data.Database;
using CIAT.DAPA.AEPS.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIAT.DAPA.AEPS.Data.Repositories
{
    /// <summary>
    /// This class allow to access to the information about forms
    /// </summary>
    public class RepositoryFrmForms : RepositoryBase, IAEPSRepository<FrmForms>
    {
        /// <summary>
        /// Method Construct
        /// </summary>
        /// <param name="context">Database context</param>
        public RepositoryFrmForms(AEPSContext context) :base(context)
        {

        }

        /// <summary>
        /// Method that add new entity to the database
        /// </summary>
        /// <param name="entity">Entity to save</param>
        /// <returns>Entity with new Object ID</returns>
        public async Task<FrmForms> InsertAsync(FrmForms entity)
        {
            DateTime now = DateTime.Now;
            entity.Created = now;
            entity.Updated = now;
            entity.Enable = 1;
            DB.FrmForms.Add(entity);
            await DB.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// Method that delete one entity in the database.
        /// </summary>
        /// <param name="entity">Entity to delete</param>
        /// <returns>True if the register has been deleted, otherwise false</returns>      
        public async Task<bool> DeleteAsync(FrmForms entity)
        {
            DB.FrmForms.Remove(entity);
            int records = await DB.SaveChangesAsync();
            return records > 0;
        }

        /// <summary>
        /// Method that updated one entity in the database.
        /// </summary>
        /// <param name="entity">Entity to update</param>
        /// <returns>True if the register has been updated, otherwise false</returns>
        public async Task<bool> UpdateAsync(FrmForms entity)
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


        /// <summary>
        /// Method that return all forms registered in the database
        /// </summary>
        /// <returns>List of forms</returns>
        public async Task<List<FrmForms>> ToListAsync()
        {
            return await DB.FrmForms.ToListAsync();
        }

        /// <summary>
        /// Method that return all entities enable in the database
        /// </summary>
        /// <returns>List of entities</returns>
        public async Task<List<FrmForms>> ToListEnableAsync()
        {
            return await DB.FrmForms.Where(p => p.Enable == 1).ToListAsync();
        }

        /// <summary>
        /// Method that search an entity by its id
        /// </summary>
        /// <param name="id">Id entity</param>
        /// <returns>Form</returns>
        public async Task<FrmForms> ByIdAsync(int id)
        {
            return await DB.FrmForms.SingleOrDefaultAsync(p=>p.Id == id);
        }
    }
}