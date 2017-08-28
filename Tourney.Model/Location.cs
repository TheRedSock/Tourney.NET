using Tourney.Model.LocationClasses;

namespace Tourney.Model
{
    /// <summary>
    /// Class for a location.
    /// </summary>
    public class Location
    {
        /// <summary>
        /// Gets or sets the location identifier.
        /// </summary>
        /// <value>
        /// The location identifier.
        /// </value>
        public int LocationId { get; set; }

        /// <summary>
        /// Gets or sets the continent.
        /// </summary>
        /// <value>
        /// The continent.
        /// </value>
        public virtual Continent Continent { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        public virtual Country Country { get; set; }

        /// <summary>
        /// Gets or sets the region.
        /// </summary>
        /// <value>
        /// The region.
        /// </value>
        public virtual Region Region { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>
        /// The city.
        /// </value>
        public virtual City City { get; set; }
    }
}