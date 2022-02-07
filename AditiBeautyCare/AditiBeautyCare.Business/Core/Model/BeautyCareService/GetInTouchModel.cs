using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AditiBeautyCare.Business.Core.Model.BeautyCareService
{
    /// <summary>
    /// Declaring properties here
    /// </summary>
    public class GetInTouchModel
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
        public string Body { get; set; }
    }

}
