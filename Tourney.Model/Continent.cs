using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tourney.Model
{
    /// <summary>
    /// Class for a continent.
    /// </summary>
    public class Continent
    {
        /// <summary>
        /// Gets or sets the continent identifier.
        /// </summary>
        /// <value>
        /// The continent identifier.
        /// </value>
        public int ContinentId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the countries.
        /// </summary>
        /// <value>
        /// The countries.
        /// </value>
        public virtual List<Country> Countries { get; } = new List<Country>();

        /// <summary>
        /// Gets or sets the locations that use this class.
        /// </summary>
        /// <value>
        /// The locations.
        /// </value>
        public virtual List<Location> Locations { get; } = new List<Location>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Continent"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public Continent(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Continent"/> class.
        /// </summary>
        public Continent()
        {
        }
    }
}
