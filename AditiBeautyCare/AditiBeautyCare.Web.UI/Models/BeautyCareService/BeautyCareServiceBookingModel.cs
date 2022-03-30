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
        /// Declaring From Time Property
        /// </summary>
       

        
        [Required (ErrorMessage = "Please Choose Time Correctly")]
        [DataType(DataType.Time)]
        //[Range(From<To)]
        
        public string From { get; set; }

        /// <summary>
        /// Declaring To Time Property
        /// </summary>
        
        [Required(ErrorMessage = "Please Set To after From")]
        [DataType(DataType.Time)]
       
        //[Range(booking.To>From)]

        public string To { get; set; }

        /// <summary>
        /// Declaring Date Property
        /// </summary>
        [Required]
        [Range(typeof(DateTime), "1/3/2022", "31/12/2022", ErrorMessage = "Value for {0} must be between {1} and {2}")]
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

        [Required(ErrorMessage = "Please Fill 10 Digit Mob. No.")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Please Fill 10 Digit Mob. No. ")]

        public string UserMobileNumber { get; set; }

        /// <summary>
        /// Declaring Description Property
        /// </summary>
        public string Description { get; set; }

        #endregion
    }
}


