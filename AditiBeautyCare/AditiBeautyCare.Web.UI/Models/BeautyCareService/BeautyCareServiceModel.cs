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
        [Required(ErrorMessage = "Please mention service name.")]
        public string Name { get; set; }

        /// <summary>
        /// Declaring Description Property
        /// </summary>
        [Required(ErrorMessage = "Please mention the description of service.")]
        public string Description { get; set; }

        /// <summary>
        /// Declaring Price Property
        /// </summary>
        [Required(ErrorMessage = "Please fill service price.")]
        public int Price { get; set; }

        /// <summary>
        /// Declaring Duration Property
        /// </summary>
        [Required(ErrorMessage = "Please fill service duration.")]
        public int Duration { get; set; }

        /// <summary>
        /// Declaring ImageUrl property
        /// </summary>
        [Required(ErrorMessage = "Please select an image to upload")]
        [AllowedExtensions(new string[] { ".jpg", ".jpeg", ".png" })]
        [MaxFileSize(100000)]
        public IFormFile ImageUrl { get; set; }
        
        /// <summary>
        /// Declaring File Path to store file
        /// </summary>
        public string FilePath { get; set; }
        #endregion
    }
}
