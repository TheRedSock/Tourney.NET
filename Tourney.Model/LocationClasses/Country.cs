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
        [Required]
        public virtual Continent Continent { get; set; }

        /// <summary>
        /// Gets or sets the continent identifier.
        /// </summary>
        /// <value>
        /// The continent identifier.
        /// </value>
        public int ContinentId { get; set; }

        /// <summary>
        /// Gets or sets the regions.
        /// </summary>
        /// <value>
        /// The regions.
        /// </value>
        public virtual List<Region> Regions { get; set; }

        /// <summary>
        /// Gets or sets the locations that use this class.
        /// </summary>
        /// <value>
        /// The locations.
        /// </value>
        public virtual List<Location> Locations { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Country"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="continent">The continent.</param>
        public Country(string name, Continent continent)
        {
            Name = name;
            Continent = continent;
            Regions = new List<Region>();
            Locations = new List<Location>();
        }
    }
}