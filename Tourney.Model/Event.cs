using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tourney.Model
{
    /// <summary>
    /// Class for an event within an <see cref="Tournament"/> class.
    /// </summary>
    public class Event
    {
        /// <summary>
        /// Gets or sets the event identifier.
        /// </summary>
        /// <value>
        /// The event identifier.
        /// </value>
        public int EventId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the rounds.
        /// </summary>
        /// <value>
        /// The rounds.
        /// </value>
        public virtual List<Round> Rounds { get; set; }

        /// <summary>
        /// Gets or sets the tournament.
        /// </summary>
        /// <value>
        /// The tournament.
        /// </value>
        public virtual Tournament Tournament { get; set; }

        /// <summary>
        /// Gets or sets the matches.
        /// </summary>
        /// <value>
        /// The matches.
        /// </value>
        public virtual List<Match> Matches { get; set; }
    }
}