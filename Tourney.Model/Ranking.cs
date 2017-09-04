using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the game.
        /// </summary>
        /// <value>
        /// The game.
        /// </value>
        [Required]
        public virtual Game Game { get; set; }

        /// <summary>
        /// Gets or sets the game identifier.
        /// </summary>
        /// <value>
        /// The game identifier.
        /// </value>
        public int GameId { get; set; }

        /// <summary>
        /// Gets or sets the participants.
        /// </summary>
        /// <value>
        /// The participants.
        /// </value>
        public virtual List<Participant> Participants { get; set; }

        /// <summary>
        /// Gets or sets the tournaments.
        /// </summary>
        /// <value>
        /// The tournaments.
        /// </value>
        public virtual List<Tournament> Tournaments { get; set; }

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
        /// Initializes a new instance of the <see cref="Ranking"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public Ranking(string name, Game game)
        {
            Name = name;
            Game = game;
            Participants = new List<Participant>();
            Tournaments = new List<Tournament>();
        }

        public Ranking()
        {
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
