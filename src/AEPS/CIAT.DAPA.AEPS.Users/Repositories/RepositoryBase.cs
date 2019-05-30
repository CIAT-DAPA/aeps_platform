using CIAT.DAPA.AEPS.Users.Database;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CIAT.DAPA.AEPS.Users.Repositories
{
    /// <summary>
    /// This class is an abstract implementation to access to the database
    /// </summary>
    public abstract class RepositoryBase
    {
        protected AEPSUsersContext DB { get; set; }

        /// <summary>
        /// Method Construct
        /// </summary>
        /// <param name="context">Database context</param>
        public RepositoryBase(AEPSUsersContext context)
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
