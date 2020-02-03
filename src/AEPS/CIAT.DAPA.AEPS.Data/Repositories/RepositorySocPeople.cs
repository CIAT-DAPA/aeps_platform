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
    public class RepositorySocPeople : RepositoryBase, IAEPSRepository<SocPeople>
    {
        /// <summary>
        /// Method Construct
        /// </summary>
        /// <param name="context">Database context</param>
        public RepositorySocPeople(AEPSContext context) : base(context)
        {

        }
        /// <summary>
        /// Method that add new entity to the database
        /// </summary>
        /// <param name="entity">Entity to save</param>
        /// <returns>Entity with new Object ID</returns>
        public async Task<SocPeople> InsertAsync(SocPeople entity)
        {
            DateTime now = DateTime.Now;
            entity.Created = now;
            entity.Updated = now;
            DB.SocPeople.Add(entity);
            await DB.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// Method that delete one entity in the database.
        /// </summary>
        /// <param name="entity">Entity to delete</param>
        /// <returns>True if the register has been deleted, otherwise false</returns>      
        public async Task<bool> DeleteAsync(SocPeople entity)
        {
            DB.SocPeople.Remove(entity);
            int records = await DB.SaveChangesAsync();
            return records > 0;
        }

        /// <summary>
        /// Method that updated one entity in the database.
        /// </summary>
        /// <param name="entity">Entity to update</param>
        /// <returns>True if the register has been updated, otherwise false</returns>
        public async Task<bool> UpdateAsync(SocPeople entity)
        {
            SocPeople model = await DB.SocPeople.FindAsync(entity.Id);
            int records = 0;
            if (model != null)
            {
                model.Address = entity.Address;
                model.Cellphone = entity.Cellphone;
                model.Document = entity.Document;
                model.Email = entity.Email;
                model.KindDocument = entity.KindDocument;
                model.LastName = entity.LastName;
                model.Municipality = entity.Municipality;
                model.Name = entity.Name;
                model.Sex = entity.Sex;
                model.ExtId = entity.ExtId;                
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
        public async Task<List<SocPeople>> ToListAsync()
        {
            return await DB.SocPeople.ToListAsync();
        }

        /// <summary>
        /// Method that return all entities enable in the database
        /// </summary>
        /// <returns>List of entities</returns>
        public async Task<List<SocPeople>> ToListEnableAsync()
        {
            return await DB.SocPeople.ToListAsync();
        }

        /// <summary>
        /// Method that search a entity by its id
        /// </summary>
        /// <param name="id">Entity id</param>
        /// <returns>Entity</returns>
        public async Task<SocPeople> ByIdAsync(int id)
        {
            return await DB.SocPeople.SingleOrDefaultAsync(p => p.Id == id);
        }

        /// <summary>
        /// Method that add new entity to the database
        /// </summary>
        /// <param name="entity">Entity to save</param>
        /// <returns>Entity with new Object ID</returns>
        public SocPeople AddAsync(SocPeople entity)
        {
            DateTime now = DateTime.Now;
            entity.Created = now;
            entity.Updated = now;
            DB.SocPeople.Add(entity);
            return entity;
        }

        /// <summary>
        /// Method that return a list of kind of documents 
        /// </summary>
        /// <returns>List of the kind documents</returns>
        public List<string> ListKindDocuments()
        {
            return new List<string>() { "N", "P", "O" };
        }

        /// <summary>
        /// Method that return a list of genders
        /// </summary>
        /// <returns>List of the genders</returns>
        public List<string> ListSex()
        {
            return new List<string>() { "F", "M", "O" };
        }

    }
}
