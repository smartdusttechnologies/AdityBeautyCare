using System;
using System.ComponentModel.DataAnnotations;

namespace AditiBeautyCare.Web.UI.Models.BeautyCareService
{
    public class BeautyCareServiceBookingModel
    {
        #region Public Properties
        //public int property declared
        public int Id { get; set; }

        /// <summary>
        /// Beautycare Service Name 
        /// </summary>
        public string ServiceName { get; set; }

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
        //[Required(ErrorMessage = "Required 10Digit ")]
        //[RegularExpression(@"^(\d{10})$", ErrorMessage = "Less than 10Digit ")]
        //[Display (Name="userMobileNumber")]
        [Required(ErrorMessage = "Please Fill 10 Digit No.")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Please Fill 10 Digit ") ]

        public string UserMobileNumber { get; set; }

        /// <summary>
        /// Declaring Description Property
        /// </summary>
        public string Description { get; set; }
           
        #endregion
    }
}
