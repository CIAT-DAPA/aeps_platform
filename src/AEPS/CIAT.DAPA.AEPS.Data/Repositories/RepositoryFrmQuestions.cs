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
    /// This class allows to access to the information about questions
    /// </summary>
    public class RepositoryFrmQuestions : RepositoryBase, IAEPSRepository<FrmQuestions>
    {
        /// <summary>
        /// Method Construct
        /// </summary>
        /// <param name="context">Database context</param>
        public RepositoryFrmQuestions(AEPSContext context) : base(context)
        {

        }

        /// <summary>
        /// Method that search an entity by its id
        /// </summary>
        /// <param name="id">Id entity</param>
        /// <returns>Question</returns>
        public async Task<FrmQuestions> ByIdAsync(int id)
        {
            return await DB.FrmQuestions.SingleOrDefaultAsync(p => p.Id == id);
        }

        /// <summary>
        /// Method that delete one entity in the database.
        /// </summary>
        /// <param name="entity">Entity to delete</param>
        /// <returns>True if the register has been deleted, otherwise false</returns> 
        public async Task<bool> DeleteAsync(FrmQuestions entity)
        {
            DB.FrmQuestions.Remove(entity);
            int records = await DB.SaveChangesAsync();
            return records > 0;
        }

        /// <summary>
        /// Method that add new entity to the database
        /// </summary>
        /// <param name="entity">Entity to save</param>
        /// <returns>Entity with new Object ID</returns>
        public async Task<FrmQuestions> InsertAsync(FrmQuestions entity)
        {
            DateTime now = DateTime.Now;
            entity.Created = now;
            entity.Updated = now;
            entity.Enable = 1;
            DB.FrmQuestions.Add(entity);
            await DB.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// Method that return all forms registered in the database
        /// </summary>
        /// <returns>List of questions</returns>
        public async Task<List<FrmQuestions>> ToListAsync()
        {
            return await DB.FrmQuestions.OrderBy(p=>p.Block).ToListAsync();
        }

        /// <summary>
        /// Method that return all entities enable in the database
        /// </summary>
        /// <returns>List of entities</returns>
        public async Task<List<FrmQuestions>> ToListEnableAsync()
        {
            return await DB.FrmQuestions.Where(p => p.Enable == 1).ToListAsync();
        }

        /// <summary>
        /// Method that updated one entity in the database.
        /// </summary>
        /// <param name="entity">Entity to update</param>
        /// <returns>True if the register has been updated, otherwise false</returns>
        public async Task<bool> UpdateAsync(FrmQuestions entity)
        {
            FrmQuestions model = await DB.FrmQuestions.FindAsync(entity.Id);
            int records = 0;
            if (model != null)
            {
                model.Description = entity.Description;
                model.ExtId = entity.ExtId;
                model.Name = entity.Name;
                model.Label = entity.Label;
                model.Order = entity.Order;
                model.Type = entity.Type;
                model.Block = entity.Block;
                model.Updated = DateTime.Now;
                DB.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                records = await DB.SaveChangesAsync();
            }
            return records > 0;
        }

        /// <summary>
        /// Method that return a list of questions types 
        /// </summary>
        /// <returns>List type</returns>
        public List<string> ToListType()
        {
            return new List<string>() { "string", "int", "double", "bool", "date", "time", "datetime", "unique", "multiple" };
        }

        /// <summary>
        /// Method that return all entities in the database, that are enabled, according their types
        /// </summary>
        /// <param name="types">List of types</param>
        /// <returns>List of questions</returns>
        public async Task<List<FrmQuestions>> ToListEnableTypesAsync(params string[] types)
        {
            return await DB.FrmQuestions.Where(p => p.Enable == 1 && types.Contains(p.Type)).ToListAsync();
        }

        /// <summary>
        /// Method that add new entity
        /// </summary>
        /// <param name="entity">Entity to save</param>
        /// <returns>Entity with new Object ID</returns>
        public FrmQuestions AddAsync(FrmQuestions entity)
        {
            DateTime now = DateTime.Now;
            entity.Created = now;
            entity.Updated = now;
            entity.Enable = 1;
            DB.FrmQuestions.Add(entity);
            return entity;
        }
    }
}
