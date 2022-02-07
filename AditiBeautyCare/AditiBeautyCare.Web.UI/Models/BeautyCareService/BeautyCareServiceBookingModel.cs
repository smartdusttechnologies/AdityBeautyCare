﻿using System.ComponentModel.DataAnnotations;

namespace AditiBeautyCare.Web.UI.Models.BeautyCareService
{
    public class BeautyCareServiceBookingModel
    {
        #region Public Properties
        //public int property declared
        public int Id { get; set; }

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