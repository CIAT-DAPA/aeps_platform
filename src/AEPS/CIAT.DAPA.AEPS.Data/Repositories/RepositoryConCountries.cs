﻿using CIAT.DAPA.AEPS.Data.Database;
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
    public class RepositoryConCountries : RepositoryBase, IAEPSRepository<ConCountries>
    {
        /// <summary>
        /// Method Construct
        /// </summary>
        /// <param name="context">Database context</param>
        public RepositoryConCountries(AEPSContext context) : base(context)
        {

        }
        /// <summary>
        /// Method that add new entity to the database
        /// </summary>
        /// <param name="entity">Entity to save</param>
        /// <returns>Entity with new Object ID</returns>
        public async Task<ConCountries> InsertAsync(ConCountries entity)
        {
            DateTime now = DateTime.Now;
            entity.Created = now;
            entity.Updated = now;
            DB.ConCountries.Add(entity);
            await DB.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// Method that delete one entity in the database.
        /// </summary>
        /// <param name="entity">Entity to delete</param>
        /// <returns>True if the register has been deleted, otherwise false</returns>      
        public async Task<bool> DeleteAsync(ConCountries entity)
        {
            DB.ConCountries.Remove(entity);
            int records = await DB.SaveChangesAsync();
            return records > 0;
        }

        /// <summary>
        /// Method that updated one entity in the database.
        /// </summary>
        /// <param name="entity">Entity to update</param>
        /// <returns>True if the register has been updated, otherwise false</returns>
        public async Task<bool> UpdateAsync(ConCountries entity)
        {
            ConCountries model = await DB.ConCountries.FindAsync(entity.Id);
            int records = 0;
            if (model != null)
            {
                model.ExtId = entity.ExtId;
                model.Name = entity.Name;
                model.Iso2 = entity.Iso2;
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
        public async Task<List<ConCountries>> ToListAsync()
        {
            return await DB.ConCountries.ToListAsync();
        }

        /// <summary>
        /// Method that return all entities enable in the database
        /// </summary>
        /// <returns>List of entities</returns>
        public async Task<List<ConCountries>> ToListEnableAsync()
        {
            return await DB.ConCountries.ToListAsync();
        }

        /// <summary>
        /// Method that search a entity by its id
        /// </summary>
        /// <param name="id">Entity id</param>
        /// <returns>Entity</returns>
        public async Task<ConCountries> ByIdAsync(int id)
        {
            return await DB.ConCountries.SingleOrDefaultAsync(p => p.Id == id);
        }

        /// <summary>
        /// Method that add new entity to the database
        /// </summary>
        /// <param name="entity">Entity to save</param>
        /// <returns>Entity with new Object ID</returns>
        public ConCountries AddAsync(ConCountries entity)
        {
            DateTime now = DateTime.Now;
            entity.Created = now;
            entity.Updated = now;
            DB.ConCountries.Add(entity);
            return entity;
        }

    }
}
