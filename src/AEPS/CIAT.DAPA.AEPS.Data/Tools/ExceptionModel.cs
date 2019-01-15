using System;
using System.Collections.Generic;
using System.Text;

namespace CIAT.DAPA.AEPS.Data.Tools
{
    /// <summary>
    /// This class is an exception from model in the database
    /// </summary>
    public class ExceptionModel: Exception
    {
        /// <summary>
        /// Get the property that has an error
        /// </summary>
        public string Property { private get; set; }

        /// <summary>
        /// Method construct
        /// </summary>
        /// <param name="message">Exception message</param>
        public ExceptionModel(string message) : base(message)
        {
        }

        /// <summary>
        /// Method construct
        /// </summary>        
        /// <param name="message">Exception message</param>
        /// /// <param name="property">Property name</param>
        public ExceptionModel(string message, string property) : base(message)
        {
            Property = property;
        }
    }
}
