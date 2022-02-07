using System.ComponentModel.DataAnnotations;

namespace AditiBeautyCare.Web.UI.Models.BeautyCareService
{
    public class BeautyCareServiceBookingModel
    {
        #region Public Properties
        //public int ServiceId { get; set; }
        public int Id { get; set; }

      public int ServiceId { get; set; }
        public string From { get; set; }
      
        public string To { get; set; }
      
        public string Date { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        
        public string UserMobileNumber { get; set; }
        public string Description { get; set; }
        #endregion
    }
}
