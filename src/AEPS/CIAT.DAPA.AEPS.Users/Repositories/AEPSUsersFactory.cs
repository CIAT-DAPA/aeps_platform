using CIAT.DAPA.AEPS.Users.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace CIAT.DAPA.AEPS.Users.Repositories
{
    public class AEPSUsersFactory
    {
        private AEPSUsersContext Context { get; set; }

        /// <summary>
        /// Method Construct
        /// </summary>
        /// <param name="context"></param>
        public AEPSUsersFactory(AEPSUsersContext context)
        {
            Context = context;
        }
    }
}
