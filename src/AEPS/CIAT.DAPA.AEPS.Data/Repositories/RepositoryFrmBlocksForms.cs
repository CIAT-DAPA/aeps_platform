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
    public class RepositoryFrmBlocksForms : RepositoryBase, IAEPSRepository<FrmBlocksForms>
    {
        /// <summary>
        /// Method Construct
        /// </summary>
        /// <param name="context">Database context</param>
        public RepositoryFrmBlocksForms(AEPSContext context) : base(context)
        {

        }

        /// <summary>
        /// Method not available
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Exception</returns>
        public async Task<FrmBlocksForms> ByIdAsync(int id)
        {
            throw new Exception();
        }

        /// <summary>
        /// Method that delete one entity in the database.
        /// </summary>
        /// <param name="entity">Entity to delete</param>
        /// <returns>True if the register has been deleted, otherwise false</returns> 
        public async Task<bool> DeleteAsync(FrmBlocksForms entity)
        {
            var questions = await DB.FrmQuestions.Where(p => p.Block == entity.Block).Select(p=>p.Id).ToListAsync();
            var answers = await DB.FarAnswers.Where(p => questions.Contains(p.Question)).ToListAsync();
            if (answers.Count > 0)
                throw new ExceptionModel("The form has answers with that block. Question amount (" + answers.Count + ")", "Form");
            DB.FrmBlocksForms.Remove(entity);
            int records = await DB.SaveChangesAsync();
            return records > 0;
        }

        /// <summary>
        /// Method that add new entity to the database
        /// </summary>
        /// <param name="entity">Entity to save</param>
        /// <returns>Entity with new Object ID</returns>
        public async Task<FrmBlocksForms> InsertAsync(FrmBlocksForms entity)
        {
            DateTime now = DateTime.Now;
            entity.Created = now;
            entity.Updated = now;
            entity.Enable = 1;
            DB.FrmBlocksForms.Add(entity);
            await DB.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// Method that return all entities registered in the database
        /// </summary>
        /// <returns>List of options</returns>
        public async Task<List<FrmBlocksForms>> ToListAsync()
        {
            return await DB.FrmBlocksForms.ToListAsync();
        }

        /// <summary>
        /// Method that return all entities enable in the database
        /// </summary>
        /// <returns>List of entities</returns>
        public async Task<List<FrmBlocksForms>> ToListEnableAsync()
        {
            return await DB.FrmBlocksForms.Where(p => p.Enable == 1).ToListAsync();
        }

        /// <summary>
        /// Method that updated one entity in the database.
        /// </summary>
        /// <param name="entity">Entity to update</param>
        /// <returns>True if the register has been updated, otherwise false</returns>
        public async Task<bool> UpdateAsync(FrmBlocksForms entity)
        {
            FrmBlocksForms model = await DB.FrmBlocksForms.FirstOrDefaultAsync(p=> p.Form == entity.Form && p.Block == entity.Block);
            int records = 0;
            if (model != null)
            {
                model.Enable = entity.Enable;
                model.Updated = DateTime.Now;
                DB.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                records = await DB.SaveChangesAsync();
            }
            return records > 0;
        }

        /// <summary>
        /// Method that return all entities registered in the database by form id
        /// </summary>
        /// <param name="form">Form id</param>
        /// <returns>List of entities</returns>
        public async Task<List<FrmBlocksForms>> ToListByFormAsync(int form)
        {
            return await DB.FrmBlocksForms.Where(p=>p.Form == form).ToListAsync();
        }

        /// <summary>
        /// Method that add new entity
        /// </summary>
        /// <param name="entity">Entity to save</param>
        /// <returns>Entity with new Object ID</returns>
        public FrmBlocksForms AddAsync(FrmBlocksForms entity)
        {
            DateTime now = DateTime.Now;
            entity.Created = now;
            entity.Updated = now;
            entity.Enable = 1;
            DB.FrmBlocksForms.Add(entity);
            return entity;
        }

    }
}
