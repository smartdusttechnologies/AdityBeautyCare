using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using AditiBeautyCare.Web.UI.Common;

namespace AditiBeautyCare.Web.UI.Models.BeautyCareService
{
    /// <summary>
    /// Declaring Public Properties
    /// </summary>
    public class BeautyCareServiceModel
    {
        #region Public Properties
        /// <summary>
        /// declariing id has property
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Declaring Name Property
        /// </summary>
        
        [Required(ErrorMessage ="Please Mention Service Name")]
        public string Name { get; set; }

        /// <summary>
        /// Declaring Description Property
        /// </summary>
        [Required(ErrorMessage ="Please Mention the Description of Service")]
        
        public string Description { get; set; }

        /// <summary>
        /// Declaring Price Property
        /// </summary>
        [Required(ErrorMessage ="Please Fill Service Price")]
        public string Price { get; set; }

        /// <summary>
        /// Declaring Duration Property
        /// </summary>
        [Required(ErrorMessage ="Please Fill Service Duration")]
        public string Duration { get; set; }

        /// <summary>
        /// Declaring ImageUrl property
        /// </summary>

        [Required(ErrorMessage = "File Max Size 100Kb, jpg,png,jpeg allowed only")]
        [MaxFileSize(100000, ErrorMessage = "File Size Up to Max -100Kb only")]
        [AllowedExtensions(new string[] { ".jpg", ".jpeg", ".png" }, ErrorMessage = "Only jpg,jpeg, png type of Files allowed")]
        public IFormFile ImageUrl { get; set; } 

       public string FilePath{ get; set; }
        #endregion
    }
   
}
