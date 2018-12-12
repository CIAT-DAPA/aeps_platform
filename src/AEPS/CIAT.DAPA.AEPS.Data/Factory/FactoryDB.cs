using CIAT.DAPA.AEPS.Data.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CIAT.DAPA.AEPS.Data.Factory
{
    /// <summary>
    /// This class is an abstract implementation to access to the database
    /// </summary>
    public abstract class FactoryDB<T> where T: class
    {
        protected AEPSContext DB { get; set; }

        /// <summary>
        /// Method Construct
        /// </summary>
        /// <param name="context">Database context</param>
        public FactoryDB(AEPSContext context)
        {
            DB = context;
        }

        /// <summary>
        /// Method that add new entity to the database
        /// </summary>
        /// <param name="entity">Entity to save</param>
        /// <returns>Entity with new Object ID</returns>
        public async virtual Task<T> InsertAsync(T entity)
        {
            DB.Add<T>(entity);
            await DB.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// Method that delete one entity in the database.
        /// </summary>
        /// <param name="entity">Entity to delete</param>
        /// <returns>True if the register has been deleted, otherwise false</returns>      
        public async virtual Task<bool> DeleteAsync(T entity)
        {
            DB.Remove<T>(entity);
            int records = await DB.SaveChangesAsync();
            return records > 0;
        }

        /// <summary>
        /// Method that updated one entity in the database.
        /// </summary>
        /// <param name="entity">Entity to update</param>
        /// <returns>True if the register has been updated, otherwise false</returns>
        public abstract Task<bool> UpdateAsync(T entity);

        /// <summary>
        /// Method that change the status one entity in the database.
        /// </summary>
        /// <param name="entity">Current to update</param>
        /// <returns>True if the register has been disable, otherwise false</returns>
        public abstract Task<bool> DisableAsync(T entity);

    }
}