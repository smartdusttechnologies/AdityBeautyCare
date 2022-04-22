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
        /// To Choose a Logo Included in Email Template to send Decorated eMails
        /// </summary>
        public string LogoImage { get; set; }
        /// <summary>
        /// This represent the Aditi Beauty Care emailId
        /// </summary>
        public string EmailContact { get; set; }
        /// <summary>
        /// This is used to frame the message 
        /// </summary>
        public string HtmlMsg { get; set; }
        /// <summary>
        /// BodyImage
        /// </summary>
        public string BodyImage { get; set; }
        /// <summary>
        /// This represent the Aditi Beauty Care Contact Mobile NO.
        /// </summary>
        public string MobileNumber { get; set; }
        /// <summary>
        /// Declaring Name property of user
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
        public List<string> Cc { get; set; }
    }
}