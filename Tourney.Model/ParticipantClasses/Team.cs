using System.Collections.Generic;

namespace Tourney.Model.ParticipantClasses
{
    /// <summary>
    /// Class for a team which inherits from the <see cref="Participant"/> class.
    /// </summary>
    /// <seealso cref="Tourney.Model.Participant" />
    public class Team : Participant
    {
        /// <summary>
        /// Gets or sets the players.
        /// </summary>
        /// <value>
        /// The players.
        /// </value>
        public virtual List<Player> Players { get; set; }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>
        /// The location.
        /// </value>
        public virtual Location Location { get; set; }

        /// <summary>
        /// Gets or sets the location identifier.
        /// </summary>
        /// <value>
        /// The location identifier.
        /// </value>
        public int? LocationId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Team"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public Team(string name) : base(name)
        {
            Players = new List<Player>();
        }
    }
}
