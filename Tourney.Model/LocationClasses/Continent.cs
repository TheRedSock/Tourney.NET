using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tourney.Model.LocationClasses
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
        public virtual List<Country> Countries { get; set; }
    }
}
