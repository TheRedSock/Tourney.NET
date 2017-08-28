using System;
using System.Collections.Generic;
using Tourney.Model.ParticipantClasses;

namespace Tourney.Model
{
    /// <summary>
    /// Class for a person.
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Gets or sets the person identifier.
        /// </summary>
        /// <value>
        /// The person identifier.
        /// </value>
        public int PersonId { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the players.
        /// </summary>
        /// <value>
        /// The players.
        /// </value>
        public virtual List<Player> Players { get; set; }

        /// <summary>
        /// Gets or sets the residence.
        /// </summary>
        /// <value>
        /// The residence.
        /// </value>
        public virtual Location Residence { get; set; }

        /// <summary>
        /// Gets or sets the nationality.
        /// </summary>
        /// <value>
        /// The nationality.
        /// </value>
        public virtual Location Nationality { get; set; }

        public DateTime Birthdate { get; set; }

        public int Age { get => DateTime.Today.Year - Birthdate.Year; }

        /// <summary>
        /// Gets the full name.
        /// </summary>
        /// <value>
        /// The full name.
        /// </value>
        public string FullName { get => $"{FirstName} {LastName}"; }
    }
}
