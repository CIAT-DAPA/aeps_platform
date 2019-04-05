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
    public class RepositoryFrmFormsSettings : RepositoryBase, IAEPSRepository<FrmFormsSettings>
    {
        /// <summary>
        /// Method Construct
        /// </summary>
        /// <param name="context">Database context</param>
        public RepositoryFrmFormsSettings(AEPSContext context) : base(context)
        {

        }

        /// <summary>
        /// Method that add new entity to the database
        /// </summary>
        /// <param name="entity">Entity to save</param>
        /// <returns>Entity with new Object ID</returns>
        public async Task<FrmFormsSettings> InsertAsync(FrmFormsSettings entity)
        {
            DateTime now = DateTime.Now;
            entity.Created = now;
            entity.Updated = now;
            DB.FrmFormsSettings.Add(entity);
            await DB.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// Method that delete one entity in the database.
        /// </summary>
        /// <param name="entity">Entity to delete</param>
        /// <returns>True if the register has been deleted, otherwise false</returns>      
        public async Task<bool> DeleteAsync(FrmFormsSettings entity)
        {
            DB.FrmFormsSettings.Remove(entity);
            int records = await DB.SaveChangesAsync();
            return records > 0;
        }

        /// <summary>
        /// Method that updated one entity in the database.
        /// </summary>
        /// <param name="entity">Entity to update</param>
        /// <returns>True if the register has been updated, otherwise false</returns>
        public async Task<bool> UpdateAsync(FrmFormsSettings entity)
        {
            FrmFormsSettings model = await DB.FrmFormsSettings.FindAsync(entity.Id);
            int records = 0;
            if (model != null)
            {
                model.App = entity.App;                
                model.Name = entity.Name;
                model.Value = entity.Value;
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
        public async Task<List<FrmFormsSettings>> ToListAsync()
        {
            return await DB.FrmFormsSettings.ToListAsync();
        }

        /// <summary>
        /// Method that return all entities enable in the database
        /// </summary>
        /// <returns>List of entities</returns>
        public async Task<List<FrmFormsSettings>> ToListEnableAsync()
        {
            throw new Exception();
        }

        /// <summary>
        /// Method that search an entity by its id
        /// </summary>
        /// <param name="id">Id entity</param>
        /// <returns>Form</returns>
        public async Task<FrmFormsSettings> ByIdAsync(int id)
        {
            return await DB.FrmFormsSettings.SingleOrDefaultAsync(p => p.Id == id);
        }

        /// <summary>
        /// Method that add new entity 
        /// </summary>
        /// <param name="entity">Entity to save</param>
        /// <returns>Entity with new Object ID</returns>
        public FrmFormsSettings AddAsync(FrmFormsSettings entity)
        {
            DateTime now = DateTime.Now;
            entity.Created = now;
            entity.Updated = now;
            DB.FrmFormsSettings.Add(entity);
            return entity;
        }
    }
}