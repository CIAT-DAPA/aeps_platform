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
    public class RepositoryFrmQuestionsRules : RepositoryBase, IAEPSRepository<FrmQuestionsRules>
    {
        /// <summary>
        /// Method Construct
        /// </summary>
        /// <param name="context">Database context</param>
        public RepositoryFrmQuestionsRules(AEPSContext context) : base(context)
        {

        }

        /// <summary>
        /// Method that search an entity by its id
        /// </summary>
        /// <param name="id">Id entity</param>
        /// <returns>Option</returns>
        public async Task<FrmQuestionsRules> ByIdAsync(int id)
        {
            return await DB.FrmQuestionsRules.SingleOrDefaultAsync(p => p.Id == id);
        }

        /// <summary>
        /// Method that delete one entity in the database.
        /// </summary>
        /// <param name="entity">Entity to delete</param>
        /// <returns>True if the register has been deleted, otherwise false</returns> 
        public async Task<bool> DeleteAsync(FrmQuestionsRules entity)
        {
            DB.FrmQuestionsRules.Remove(entity);
            int records = await DB.SaveChangesAsync();
            return records > 0;
        }

        /// <summary>
        /// Method that add new entity to the database
        /// </summary>
        /// <param name="entity">Entity to save</param>
        /// <returns>Entity with new Object ID</returns>
        public async Task<FrmQuestionsRules> InsertAsync(FrmQuestionsRules entity)
        {
            DB.FrmQuestionsRules.Add(entity);
            await DB.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// Method that return all forms registered in the database
        /// </summary>
        /// <returns>List of options</returns>
        public async Task<List<FrmQuestionsRules>> ToListAsync()
        {
            return await DB.FrmQuestionsRules.OrderBy(p => p.Question).ToListAsync();
        }

        /// <summary>
        /// Method that return all entities enable in the database
        /// </summary>
        /// <returns>List of entities</returns>
        public async Task<List<FrmQuestionsRules>> ToListEnableAsync()
        {
            throw new Exception();
        }

        /// <summary>
        /// Method that updated one entity in the database.
        /// </summary>
        /// <param name="entity">Entity to update</param>
        /// <returns>True if the register has been updated, otherwise false</returns>
        public async Task<bool> UpdateAsync(FrmQuestionsRules entity)
        {
            FrmQuestionsRules model = await DB.FrmQuestionsRules.FindAsync(entity.Id);
            int records = 0;
            if (model != null)
            {
                model.App = entity.App;
                model.Type = entity.Type;
                model.Message = entity.Message;
                model.Rule = entity.Rule;
                DB.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                records = await DB.SaveChangesAsync();
            }
            return records > 0;
        }

        /// <summary>
        /// Method that return a list of applications 
        /// </summary>
        /// <returns>List apps</returns>
        public List<string> ListApps()
        {
            return new List<string>() { "all", "odk", "pdi" };
        }

        /// <summary>
        /// Method that return a list of types of rules 
        /// </summary>
        /// <returns>List types</returns>
        public List<string> ListTypes()
        {
            return new List<string>() { "required", "constraint", "relevant", "appearance", "calculation", "choice_filter" };
        }
    }
}
