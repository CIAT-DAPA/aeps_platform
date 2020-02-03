using CIAT.DAPA.AEPS.Data.Database;
using CIAT.DAPA.AEPS.Data.Interfaces;
using CIAT.DAPA.AEPS.Data.Tools;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIAT.DAPA.AEPS.Data.Repositories
{
    public class RepositoryConMunicipalities : RepositoryBase, IAEPSRepository<ConMunicipalities>
    {
        /// <summary>
        /// Method Construct
        /// </summary>
        /// <param name="context">Database context</param>
        public RepositoryConMunicipalities(AEPSContext context) : base(context)
        {

        }
        /// <summary>
        /// Method that add new entity to the database
        /// </summary>
        /// <param name="entity">Entity to save</param>
        /// <returns>Entity with new Object ID</returns>
        public async Task<ConMunicipalities> InsertAsync(ConMunicipalities entity)
        {
            DateTime now = DateTime.Now;
            entity.Created = now;
            entity.Updated = now;
            DB.ConMunicipalities.Add(entity);
            await DB.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// Method that delete one entity in the database.
        /// </summary>
        /// <param name="entity">Entity to delete</param>
        /// <returns>True if the register has been deleted, otherwise false</returns>      
        public async Task<bool> DeleteAsync(ConMunicipalities entity)
        {
            DB.ConMunicipalities.Remove(entity);
            int records = await DB.SaveChangesAsync();
            return records > 0;
        }

        /// <summary>
        /// Method that updated one entity in the database.
        /// </summary>
        /// <param name="entity">Entity to update</param>
        /// <returns>True if the register has been updated, otherwise false</returns>
        public async Task<bool> UpdateAsync(ConMunicipalities entity)
        {
            ConMunicipalities model = await DB.ConMunicipalities.FindAsync(entity.Id);
            int records = 0;
            if (model != null)
            {
                model.ExtId = entity.ExtId;
                model.Name = entity.Name;
                model.State = entity.State;
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
        public async Task<List<ConMunicipalities>> ToListAsync()
        {
            return await DB.ConMunicipalities.ToListAsync();
        }

        /// <summary>
        /// Method that return all entities enable in the database
        /// </summary>
        /// <returns>List of entities</returns>
        public async Task<List<ConMunicipalities>> ToListEnableAsync()
        {
            return await DB.ConMunicipalities.ToListAsync();
        }

        /// <summary>
        /// Method that search a entity by its id
        /// </summary>
        /// <param name="id">Entity id</param>
        /// <returns>Entity</returns>
        public async Task<ConMunicipalities> ByIdAsync(int id)
        {
            return await DB.ConMunicipalities.SingleOrDefaultAsync(p => p.Id == id);
        }

        /// <summary>
        /// Method that add new entity to the database
        /// </summary>
        /// <param name="entity">Entity to save</param>
        /// <returns>Entity with new Object ID</returns>
        public ConMunicipalities AddAsync(ConMunicipalities entity)
        {
            DateTime now = DateTime.Now;
            entity.Created = now;
            entity.Updated = now;
            DB.ConMunicipalities.Add(entity);
            return entity;
        }
    }
}
