using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AditiBeautyCare.Web.UI.Models.BeautyCareService
{

    /// <summary>
    /// Declaring Public Properties
    /// </summary>
    public class BeautyCareServiceModel
    {
        #region Public Properties
        public int Id { get; set; }
        [Required]
        public string ServiceName { get; set; }
        [Required]
        public string Description { get; set; }
        public string ServicePrice { get; set; }
        public string ServiceDuration { get; set; }
        public string ImageUrl { get; set; }
        #endregion
    }
}
