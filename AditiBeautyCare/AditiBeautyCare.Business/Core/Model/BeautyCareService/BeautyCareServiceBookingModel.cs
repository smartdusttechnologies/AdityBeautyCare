using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AditiBeautyCare.Business.Core.Model.BeautyCareService
{
    public class BeautyCareServiceBookingModel:Entity
    {
        #region Public Properties
       public int ServiceId { get; set; }
      
       
     
        public string From { get; set; }
        [Required]
        public string To { get; set; }
        [Required]
        public string Date { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        [Required]
        public string UserMobileNumber { get; set; }
        public string Description { get; set; }

        #endregion
    }
}
