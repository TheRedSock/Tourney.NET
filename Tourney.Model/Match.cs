﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Tourney.Model
{
    /// <summary>
    /// Class for a match within an Phase class.
    /// </summary>
    public class Match
    {
        /// <summary>
        /// Gets or sets the match identifier.
        /// </summary>
        /// <value>
        /// The match identifier.
        /// </value>
        public int MatchId { get; set; }

        /// <summary>
        /// Gets or sets the Phase.
        /// </summary>
        /// <value>
        /// The Phase.
        /// </value>
        [Required]
        public virtual Phase Phase { get; set; }

        /// <summary>
        /// Gets or sets the Phase identifier.
        /// </summary>
        /// <value>
        /// The Phase identifier.
        /// </value>
        public int PhaseId { get; set; }

        /// <summary>
        /// Gets or sets the date time.
        /// </summary>
        /// <value>
        /// The date time.
        /// </value>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// Gets or sets the round.
        /// </summary>
        /// <value>
        /// The round.
        /// </value>
        public string Round { get; set; }

        /// <summary>
        /// Gets or sets the winner.
        /// </summary>
        /// <value>
        /// The winner.
        /// </value>
        [Required]
        public virtual Participant Winner { get; set; }

        /// <summary>
        /// Gets or sets the winner identifier.
        /// </summary>
        /// <value>
        /// The winner identifier.
        /// </value>
        public int? WinnerId { get; set; }

        /// <summary>
        /// Gets or sets the loser.
        /// </summary>
        /// <value>
        /// The loser.
        /// </value>
        [Required]
        public virtual Participant Loser { get; set; }

        /// <summary>
        /// Gets or sets the loser identifier.
        /// </summary>
        /// <value>
        /// The loser identifier.
        /// </value>
        public int? LoserId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the match is a draw.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is draw; otherwise, <c>false</c>.
        /// </value>
        public bool IsDraw { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this match was forfeited.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is forfeit; otherwise, <c>false</c>.
        /// </value>
        public bool IsForfeit { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Match"/> class.
        /// </summary>
        /// <param name="thePhase">The Phase.</param>
        /// <param name="winner">The winner.</param>
        /// <param name="loser">The loser.</param>
        public Match(Phase phase, Participant winner, Participant loser)
        {
            Phase = phase;
            Winner = winner;
            Loser = loser;

        }
        // Might need implement logic to force IsForfeit to be true if either winner or loser is null.
        // Another solution would be to add another boolean for whether a participants profile has been deleted.

        /// <summary>
        /// Initializes a new instance of the <see cref="Match"/> class.
        /// </summary>
        public Match()
        {
        }
    }
}