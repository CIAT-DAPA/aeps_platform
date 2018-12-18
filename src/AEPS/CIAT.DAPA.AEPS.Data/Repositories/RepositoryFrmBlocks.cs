using CIAT.DAPA.AEPS.Data.Database;
using CIAT.DAPA.AEPS.Data.Interfaces;
using CIAT.DAPA.AEPS.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIAT.DAPA.AEPS.Data.Repositories
{
    /// <summary>
    /// This class allow to access to the information about blocks
    /// </summary>
    public class RepositoryFrmBlocks : RepositoryBase, IAEPSRepository<FrmBlocks>
    {
        /// <summary>
        /// Method Construct
        /// </summary>
        /// <param name="context">Database context</param>
        public RepositoryFrmBlocks(AEPSContext context) : base(context)
        {

        }

        /// <summary>
        /// Method that add new entity to the database
        /// </summary>
        /// <param name="entity">Entity to save</param>
        /// <returns>Entity with new Object ID</returns>
        public async Task<FrmBlocks> InsertAsync(FrmBlocks entity)
        {
            DateTime now = DateTime.Now;
            entity.Created = now;
            entity.Updated = now;
            entity.Enable = 1;
            DB.FrmBlocks.Add(entity);
            await DB.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// Method that delete one entity in the database.
        /// </summary>
        /// <param name="entity">Entity to delete</param>
        /// <returns>True if the register has been deleted, otherwise false</returns>      
        public async Task<bool> DeleteAsync(FrmBlocks entity)
        {
            DB.FrmBlocks.Remove(entity);
            int records = await DB.SaveChangesAsync();
            return records > 0;
        }

        /// <summary>
        /// Method that updated one entity in the database.
        /// </summary>
        /// <param name="entity">Entity to update</param>
        /// <returns>True if the register has been updated, otherwise false</returns>
        public async Task<bool> UpdateAsync(FrmBlocks entity)
        {
            FrmBlocks model = await DB.FrmBlocks.FindAsync(entity.Id);
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
        /// Method that return all entities registered in the database
        /// </summary>
        /// <returns>List of entities</returns>
        public async Task<List<FrmBlocks>> ToListAsync()
        {
            return await DB.FrmBlocks.ToListAsync();
        }

        /// <summary>
        /// Method that search a entity by its id
        /// </summary>
        /// <param name="id">Entity id</param>
        /// <returns>Entity</returns>
        public async Task<FrmBlocks> ByIdAsync(int id)
        {
            return await DB.FrmBlocks.SingleOrDefaultAsync(p => p.Id == id);
        }
    }
}
