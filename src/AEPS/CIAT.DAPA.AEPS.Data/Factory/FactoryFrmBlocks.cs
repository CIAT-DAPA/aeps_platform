using CIAT.DAPA.AEPS.Data.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIAT.DAPA.AEPS.Data.Factory
{
    /// <summary>
    /// This class allow to access to the information about blocks
    /// </summary>
    public class FactoryFrmBlocks : FactoryDB<FrmBlocks>
    {
        /// <summary>
        /// Method Construct
        /// </summary>
        /// <param name="context">Database context</param>
        public FactoryFrmBlocks(AEPSContext context) : base(context)
        {

        }

        public async override Task<FrmBlocks> InsertAsync(FrmBlocks entity)
        {
            DateTime now = DateTime.Now;
            entity.Created = now;
            entity.Updated = now;
            entity.Enable = 1;
            DB.FrmBlocks.Add(entity);
            await DB.SaveChangesAsync();
            return entity;
        }

        public async override Task<bool> UpdateAsync(FrmBlocks entity)
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

        public async override Task<bool> DisableAsync(FrmBlocks entity)
        {
            FrmBlocks model = await DB.FrmBlocks.SingleOrDefaultAsync(p => p.Id == entity.Id);
            int records = 0;
            if (model != null)
            {
                model.Enable = 0;
                model.Updated = DateTime.Now;
                DB.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                records = await DB.SaveChangesAsync();
            }
            return records > 0;
        }

        /// <summary>
        /// Method that return all blocks registered in the database
        /// </summary>
        /// <returns>List of blocks</returns>
        public async Task<List<FrmBlocks>> ToListAsync()
        {
            return await DB.FrmBlocks.ToListAsync();
        }

        /// <summary>
        /// Method that search a block by its id
        /// </summary>
        /// <param name="id">Id block</param>
        /// <returns>Block</returns>
        public async Task<FrmBlocks> ByIdAsync(int id)
        {
            return await DB.FrmBlocks.SingleOrDefaultAsync(p => p.Id == id);
        }
    }
}
