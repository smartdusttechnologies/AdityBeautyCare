using System.ComponentModel.DataAnnotations;

namespace AditiBeautyCare.Web.UI.Models.Sample
{
    /// <summary>
    /// Declaring Public Properties
    /// </summary>
    public class SampleModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
    }
}