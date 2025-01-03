﻿using System.ComponentModel.DataAnnotations;

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
    }
}

