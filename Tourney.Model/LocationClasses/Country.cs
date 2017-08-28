using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tourney.Model.LocationClasses
{
    /// <summary>
    /// Class for a country.
    /// </summary>
    public class Country
    {
        /// <summary>
        /// Gets or sets the country identifier.
        /// </summary>
        /// <value>
        /// The country identifier.
        /// </value>
        public int CountryId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the continent.
        /// </summary>
        /// <value>
        /// The continent.
        /// </value>
        public virtual Continent Continent { get; set; }

        /// <summary>
        /// Gets or sets the regions.
        /// </summary>
        /// <value>
        /// The regions.
        /// </value>
        public virtual List<Region> Regions { get; set; }
    }
}