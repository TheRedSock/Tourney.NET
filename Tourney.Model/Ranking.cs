using System.Collections.Generic;

namespace Tourney.Model
{
    /// <summary>
    /// Class for a ranking.
    /// </summary>
    public class Ranking
    {
        /// <summary>
        /// Gets or sets the ranking identifier.
        /// </summary>
        /// <value>
        /// The ranking identifier.
        /// </value>
        public int RankingId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the participants.
        /// </summary>
        /// <value>
        /// The participants.
        /// </value>
        public List<Participant> Participants { get; set; }

        /// <summary>
        /// Gets or sets the tournaments.
        /// </summary>
        /// <value>
        /// The tournaments.
        /// </value>
        public List<Tournament> Tournaments { get; set; }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>
        /// The location.
        /// </value>
        public Location Location { get; set; }
    }
}
