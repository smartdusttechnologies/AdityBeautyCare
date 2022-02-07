using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AditiBeautyCare.Business.Core.Model.BeautyCareService
{
    /// <summary>
    /// Declaring properties here
    /// </summary>
    public class BeautyCareServiceModel:Entity
    {
        #region Public Properties
      
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public string Price { get; set; }
        public string Duration { get; set; }
        public string ImageUrl { get; set; }
        #endregion
    }
}
