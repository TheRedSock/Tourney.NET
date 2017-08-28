using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tourney.Model
{
    /// <summary>
    /// Class for a tournament.
    /// </summary>
    public class Tournament
    {
        /// <summary>
        /// Gets or sets the tournament identifier.
        /// </summary>
        /// <value>
        /// The tournament identifier.
        /// </value>
        public int TournamentId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the events.
        /// </summary>
        /// <value>
        /// The events.
        /// </value>
        public virtual List<Event> Events { get; set; }

        /// <summary>
        /// Gets or sets the rankings.
        /// </summary>
        /// <value>
        /// The rankings.
        /// </value>
        public virtual List<Ranking> Rankings { get; set; }
    }
}