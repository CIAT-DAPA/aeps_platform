using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIAT.DAPA.AEPS.WebAdministrative.Models
{
    public enum LogginEvent
    {
        List = 1001,
        Details = 1002,
        Create = 1003,
        Edit = 1004,
        Delete = 1005,
        Exception = 1006,
        UserError = 1007,
        Import = 1008
    }
}
