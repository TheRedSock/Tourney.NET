using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tourney.Model
{
    /// <summary>
    /// Superclass for a participant.
    /// </summary>
    public abstract class Participant
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
        /// Gets or sets the tournaments.
        /// </summary>
        /// <value>
        /// The tournaments.
        /// </value>
        public virtual List<Tournament> Tournaments { get; } = new List<Tournament>();

        /// <summary>
        /// Gets or sets the rankings.
        /// </summary>
        /// <value>
        /// The rankings.
        /// </value>
        public virtual List<Ranking> Rankings { get; } = new List<Ranking>();

        /// <summary>
        /// Gets or sets the wins.
        /// </summary>
        /// <value>
        /// The wins.
        /// </value>
        public virtual List<Match> Wins { get; } = new List<Match>();

        /// <summary>
        /// Gets or sets the losses.
        /// </summary>
        /// <value>
        /// The losses.
        /// </value>
        public virtual List<Match> Losses { get; } = new List<Match>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Participant"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        protected Participant(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Participant"/> class.
        /// </summary>
        protected Participant()
        {
        }
    }
}