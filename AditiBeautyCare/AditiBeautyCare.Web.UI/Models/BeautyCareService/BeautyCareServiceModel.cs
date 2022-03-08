using System.ComponentModel.DataAnnotations;

namespace AditiBeautyCare.Web.UI.Models.BeautyCareService
{
    /// <summary>
    /// Declaring Public Properties
    /// </summary>
    public class BeautyCareServiceModel
    {
        #region Public Properties
        /// <summary>
        /// declariing id has property
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Declaring Name Property
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Declaring Description Property
        /// </summary>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// Declaring Price Property
        /// </summary>
        public string Price { get; set; }

        /// <summary>
        /// Declaring Duration Property
        /// </summary>
        public string Duration { get; set; }

        /// <summary>
        /// Declaring ImageUrl property
        /// </summary>

        public string ImageUrl { get; set; }
        #endregion
    }
}
