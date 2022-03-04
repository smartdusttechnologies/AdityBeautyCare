using System;
using System.ComponentModel.DataAnnotations;

namespace AditiBeautyCare.Business.Core.Model.BeautyCareService
{
    /// <summary>
    /// Declaring properties here
    /// </summary>
    public class EmailModel:Entity
    {
        /// <summary>
        /// Declaring EmailTo property
        /// </summary>
        [Required]
        public string EmailTo { get; set; }

        /// <summary>
        /// Declaring Name property
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Declaring Subject property
        /// </summary>
        [Required]
        public string Subject { get; set; }

        /// <summary>
        /// Declaring Body property
        /// </summary>
        [Required]
        public string Message { get; set; }

        public int ServiceId { get; set; }

        /// <summary>
        /// Beautycare Service Name 
        /// </summary>
        public string ServiceName { get; set; }

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
        public DateTime Date { get; set; }

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
        [Required]
        public string UserMobileNumber { get; set; }

        /// <summary>
        /// Declaring Description Property
        /// </summary>
        public string Description { get; set; }
    }
}

