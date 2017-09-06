using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tourney.Model
{
    /// <summary>
    /// Class for an Phase within an Tournament class.
    /// </summary>
    public class Phase
    {
        /// <summary>
        /// Gets or sets the Phase identifier.
        /// </summary>
        /// <value>
        /// The Phase identifier.
        /// </value>
        public int PhaseId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the tournament.
        /// </summary>
        /// <value>
        /// The tournament.
        /// </value>
        public virtual Tournament Tournament { get; set; }

        /// <summary>
        /// Gets or sets the tournament identifier.
        /// </summary>
        /// <value>
        /// The tournament identifier.
        /// </value>
        public int TournamentId { get; set; }

        [Required]
        public PhaseType PhaseType { get; set; }

        /// <summary>
        /// Gets or sets the matches.
        /// </summary>
        /// <value>
        /// The matches.
        /// </value>
        public virtual List<Match> Matches { get; } = new List<Match>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Phase"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public Phase(string name, Tournament tournament, PhaseType phaseType)
        {
            Name = name;
            Tournament = tournament;
            PhaseType = phaseType;
        }

        // Work in progress on how to get amount of rounds for a Phase.
        public string[] GetRounds()
        {
            string[] r = { "N/A" };

            switch (PhaseType)
            {
                case PhaseType.SingleElimination:
                    return GetSingleEliminationRounds();
                case PhaseType.DoubleElimination:
                    return r;
                case PhaseType.RoundRobin:
                    return r;
                case PhaseType.Swiss:
                    return r;
                default:
                    return r;
            }
        }

        /// <summary>
        /// Gets the single elimination rounds.
        /// </summary>
        /// <returns>An array of round names.</returns>
        public string[] GetSingleEliminationRounds()
        {
            // Get amount of players in the Phase, and calculates the closest power of 2 above that number.
            int playerCount = Tournament.Participants.Count;
            double log = Math.Log(playerCount) / Math.Log(2);
            int roundLog = (int) Math.Ceiling(log);

            // Sets a string array to the size of the calculated power of 2, and iterates on it.
            string[] r = new string[roundLog];

            for (int i = 0; i < r.Length; i++)
            {
                if (i == 0)
                {
                    r[i] = "Grand Final";
                }
                else if (i == 1)
                {
                    r[i] = "Semi Finals";
                }
                else if (i == 2)
                {
                    r[i] = "Quarter Finals";
                }
                else
                {
                    r[i] = $"Round {r.Length - i}";
                }
            }

            Array.Reverse(r);

            // Return the string array containing the proper round names in the proper order.
            return r;
        }
    }
}