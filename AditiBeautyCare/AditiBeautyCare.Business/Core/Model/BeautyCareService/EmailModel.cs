using System;
using System.Collections.Generic;
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
        public List<string> EmailTo { get; set; }
        /// <summary>
        /// Choose a Mail Templet to Send Mail
        /// </summary>
        public string EmailTemplate { get; set; }
        /// <summary>
        /// To Choose a Email Template to send Decorated eMails
        /// </summary>
        public string LogoImage { get; set; }
        public string BodyImage { get; set; }

        public string EmailContact { get; set; }
        public string HtmlMsg { get; set; }

        public string MobileNumber { get; set; }

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
        //TODO:ADD THE CORRESPONDING DB CHANGES
        [Required]
        public string Message { get; set; }

        public List<string> Bcc { get; set; }
        public List<string> AdminMailId { get; set; }
        public List<string> Cc { get; set; }
    }
}