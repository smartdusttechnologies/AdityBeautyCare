using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace AditiBeautyCare.Web.UI.Models
{
    /// <summary>
    /// Declaring Public Properties
    /// </summary>
    public class EmailModel
    {
        /// <summary>
        /// declaring Id property
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Declaring emailto property
        /// </summary>
        public string EmailTo { get; set; }

        /// <summary>
        /// declaring name property
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Declaring subject property
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Declaring Body property
        /// </summary>
        public string Message { get; set; }


    }
}
