
using System.ComponentModel.DataAnnotations;

namespace AditiBeautyCare.Business.Core.Model.BeautyCareService
{
    /// <summary>
    /// Declaring properties here
    /// </summary>
    public class BeautyCareServiceModel:Entity
    {
        #region Public Properties
        /// <summary>
        /// Declaring Name Property
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Declaring Description Property
        /// </summary>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// Declaring Price Property
        /// </summary>
        [Required]
        public string Price { get; set; }

        /// <summary>
        /// Declaring Duration Property
        /// </summary>
        [Required]
        public string Duration { get; set; }

        /// <summary>
        /// Declaring ImageUrl Property
        /// </summary>
        [Required]
        public string ImageUrl { get; set; }
      
        #endregion
    }
}
