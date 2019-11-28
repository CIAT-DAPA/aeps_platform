using System;
using System.Collections.Generic;
using System.Text;

namespace CIAT.DAPA.AEPS.Data.Tools
{
    public static class StringOperations
    {
        /// <summary>
        /// Method that return the value of object or empty
        /// </summary>
        /// <param name="obj">Object to validate</param>
        /// <returns>string</returns>
        public static string Values(object obj)
        {
            return obj == null ? string.Empty : obj.ToString();
        }
    }
}
