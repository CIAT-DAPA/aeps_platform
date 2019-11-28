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
    public class RepositoryFrmOptions : RepositoryBase, IAEPSRepository<FrmOptions>
    {
        /// <summary>
        /// Method Construct
        /// </summary>
        /// <param name="context">Database context</param>
        public RepositoryFrmOptions(AEPSContext context) : base(context)
        {

        }

        /// <summary>
        /// Method that search an entity by its id
        /// </summary>
        /// <param name="id">Id entity</param>
        /// <returns>Option</returns>
        public async Task<FrmOptions> ByIdAsync(int id)
        {
            return await DB.FrmOptions.SingleOrDefaultAsync(p => p.Id == id);
        }

        /// <summary>
        /// Method that delete one entity in the database.
        /// </summary>
        /// <param name="entity">Entity to delete</param>
        /// <returns>True if the register has been deleted, otherwise false</returns> 
        public async Task<bool> DeleteAsync(FrmOptions entity)
        {
            DB.FrmOptions.Remove(entity);
            int records = await DB.SaveChangesAsync();
            return records > 0;
        }

        /// <summary>
        /// Method that add new entity to the database
        /// </summary>
        /// <param name="entity">Entity to save</param>
        /// <returns>Entity with new Object ID</returns>
        public async Task<FrmOptions> InsertAsync(FrmOptions entity)
        {
            DateTime now = DateTime.Now;
            entity.Created = now;
            entity.Updated = now;
            entity.Enable = 1;
            DB.FrmOptions.Add(entity);
            await DB.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// Method that return all forms registered in the database
        /// </summary>
        /// <returns>List of options</returns>
        public async Task<List<FrmOptions>> ToListAsync()
        {
            return await DB.FrmOptions.OrderBy(p => p.Question).ToListAsync();
        }

        /// <summary>
        /// Method that return all entities enable in the database
        /// </summary>
        /// <returns>List of entities</returns>
        public async Task<List<FrmOptions>> ToListEnableAsync()
        {
            return await DB.FrmOptions.Where(p => p.Enable == 1).ToListAsync();
        }

        /// <summary>
        /// Method that updated one entity in the database.
        /// </summary>
        /// <param name="entity">Entity to update</param>
        /// <returns>True if the register has been updated, otherwise false</returns>
        public async Task<bool> UpdateAsync(FrmOptions entity)
        {
            FrmOptions model = await DB.FrmOptions.FindAsync(entity.Id);
            int records = 0;
            if (model != null)
            {
                model.ExtId = entity.ExtId;
                model.Name = entity.Name;
                model.Label = entity.Label;
                model.Enable = entity.Enable;
                model.Question = entity.Question;
                model.Updated = DateTime.Now;
                DB.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                records = await DB.SaveChangesAsync();
            }
            return records > 0;
        }

        /// <summary>
        /// Method that add new entity
        /// </summary>
        /// <param name="entity">Entity to save</param>
        /// <returns>Entity with new Object ID</returns>
        public FrmOptions AddAsync(FrmOptions entity)
        {
            DateTime now = DateTime.Now;
            entity.Created = now;
            entity.Updated = now;
            entity.Enable = 1;
            DB.FrmOptions.Add(entity);
            return entity;
        }
    }
}
