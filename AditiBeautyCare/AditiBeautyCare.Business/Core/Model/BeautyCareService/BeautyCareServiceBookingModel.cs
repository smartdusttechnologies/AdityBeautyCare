﻿using System.ComponentModel.DataAnnotations;

namespace AditiBeautyCare.Business.Core.Model.BeautyCareService
{
    /// <summary>
    /// Declaring properties here
    /// </summary>
    public class BeautyCareServiceBookingModel:Entity
    {
        #region Public Properties

        /// <summary>
        /// Declaring ServiceId Property
        /// </summary>
       public int ServiceId { get; set; }

        /// <summary>
        /// Declaring From Property
        /// </summary>
        [Required]
        public string From { get; set; }

        /// <summary>
        /// Declaring To Property
        /// </summary>
        [Required]
        public string To { get; set; }

        /// <summary>
        /// Declaring Date Property
        /// </summary>
        [Required]
        public string Date { get; set; }

        /// <summary>
        /// Declaring UserName Property
        /// </summary>
        [Required]
        public string UserName { get; set; }

        /// <summary>
        /// Declaring UserEmail Property
        /// </summary>
        public string UserEmail { get; set; }
        [Required]

        /// <summary>
        /// Declaring UserMobileNumber Property
        /// </summary>
        public string UserMobileNumber { get; set; }

        /// <summary>
        /// Declaring Description Property
        /// </summary>
        public string Description { get; set; }

        #endregion
    }
}
