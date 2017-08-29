using System.Collections.Generic;
using Tourney.Model.LocationClasses;
using Tourney.Model.ParticipantClasses;

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
        /// Gets or sets the continent identifier.
        /// </summary>
        /// <value>
        /// The continent identifier.
        /// </value>
        public int? ContinentId { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        public virtual Country Country { get; set; }

        /// <summary>
        /// Gets or sets the country identifier.
        /// </summary>
        /// <value>
        /// The country identifier.
        /// </value>
        public int? CountryId { get; set; }

        /// <summary>
        /// Gets or sets the region.
        /// </summary>
        /// <value>
        /// The region.
        /// </value>
        public virtual Region Region { get; set; }

        /// <summary>
        /// Gets or sets the region identifier.
        /// </summary>
        /// <value>
        /// The region identifier.
        /// </value>
        public int? RegionId { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>
        /// The city.
        /// </value>
        public virtual City City { get; set; }

        /// <summary>
        /// Gets or sets the city identifier.
        /// </summary>
        /// <value>
        /// The city identifier.
        /// </value>
        public int? CityId { get; set; }

        /// <summary>
        /// Gets or sets the people.
        /// </summary>
        /// <value>
        /// The people.
        /// </value>
        public virtual List<Person> People { get; set; }

        /// <summary>
        /// Gets or sets the teams.
        /// </summary>
        /// <value>
        /// The teams.
        /// </value>
        public virtual List<Team> Teams { get; set; }

        /// <summary>
        /// Gets or sets the rankings.
        /// </summary>
        /// <value>
        /// The rankings.
        /// </value>
        public virtual List<Ranking> Rankings { get; set; }

        /// <summary>
        /// Gets or sets the tournaments.
        /// </summary>
        /// <value>
        /// The tournaments.
        /// </value>
        public virtual List<Tournament> Tournaments { get; set; }
    }
}