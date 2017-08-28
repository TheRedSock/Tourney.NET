using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tourney.Model
{
    /// <summary>
    /// Superclass for a participant.
    /// </summary>
    public class Participant
    {
        /// <summary>
        /// Gets or sets the participant identifier.
        /// </summary>
        /// <value>
        /// The participant identifier.
        /// </value>
        public int ParticipantId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the rankings.
        /// </summary>
        /// <value>
        /// The rankings.
        /// </value>
        public virtual List<Ranking> Rankings { get; set; }

        /// <summary>
        /// Gets or sets the matches.
        /// </summary>
        /// <value>
        /// The matches.
        /// </value>
        public virtual List<Match> Matches { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Participant"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public Participant(string name)
        {
            Name = name;
            Rankings = new List<Ranking>();
            Matches = new List<Match>();
        }
    }
}