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
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public string Price { get; set; }
        public string Duration { get; set; }
        public string ImageUrl { get; set; }
        #endregion
    }
}
