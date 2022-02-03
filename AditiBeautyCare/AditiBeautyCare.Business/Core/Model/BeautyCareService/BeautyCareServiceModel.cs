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
        public int ServiceId { get; set; }
        [Required]
        public string ServiceName { get; set; }
        [Required]
        public string Description { get; set; }
        public string ServicePrice { get; set; }
        public string ServiceDuration { get; set; }
        public string ImageUrl { get; set; }
        #endregion
    }
}
