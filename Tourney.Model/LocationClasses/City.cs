using System.ComponentModel.DataAnnotations;

namespace Tourney.Model.LocationClasses
{
    /// <summary>
    /// Class for a city.
    /// </summary>
    public class City
    {
        /// <summary>
        /// Gets or sets the region identifier.
        /// </summary>
        /// <value>
        /// The region identifier.
        /// </value>
        public int CityId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the region.
        /// </summary>
        /// <value>
        /// The region.
        /// </value>
        public virtual Region Region { get; set; } 
    }
}