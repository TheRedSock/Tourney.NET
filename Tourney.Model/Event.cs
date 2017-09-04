using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tourney.Model
{
    /// <summary>
    /// Class for an event within an Tournament class.
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
        public EventType EventType { get; set; }

        /// <summary>
        /// Gets or sets the matches.
        /// </summary>
        /// <value>
        /// The matches.
        /// </value>
        public virtual List<Match> Matches { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Event"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public Event(string name, Tournament tournament, EventType eventType)
        {
            Name = name;
            Tournament = tournament;
            EventType = eventType;
            Matches = new List<Match>();
        }

        // Work in progress on how to get amount of rounds for a event.
        public string[] GetRounds()
        {
            string[] r = { "N/A" };

            switch (EventType)
            {
                case EventType.SingleElimination:
                    return GetSingleEliminationRounds();
                case EventType.DoubleElimination:
                    return r;
                case EventType.RoundRobin:
                    return r;
                case EventType.Swiss:
                    return r;
                default:
                    return r;
            }
        }

        public string[] GetSingleEliminationRounds()
        {
            string[] r;

            int playerCount = 129; // Get amount of players in the event.
            double log = Math.Log(playerCount) / Math.Log(2);
            int roundLog = (int) Math.Ceiling(log);

            r = new string[roundLog];

            for (int i = 1; i <= r.Length; i++)
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
            return r;
        }
    }
}