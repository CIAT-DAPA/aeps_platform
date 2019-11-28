using CIAT.DAPA.AEPS.Data.Database;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CIAT.DAPA.AEPS.Data.Repositories
{
    /// <summary>
    /// This class is an abstract implementation to access to the database
    /// </summary>
    public abstract class RepositoryBase
    {
        protected AEPSContext DB { get; set; }

        /// <summary>
        /// Method Construct
        /// </summary>
        /// <param name="context">Database context</param>
        public RepositoryBase(AEPSContext context)
        {
            DB = context;
        }

        /// <summary>
        /// Method that start a transaction
        /// </summary>
        /// <returns></returns>
        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await DB.Database.BeginTransactionAsync();
        }
    }
}