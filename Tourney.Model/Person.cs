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
        /// Gets or sets the residence identifier.
        /// </summary>
        /// <value>
        /// The residence identifier.
        /// </value>
        public int? ResidenceId { get; set; }

        /// <summary>
        /// Gets or sets the nationality.
        /// </summary>
        /// <value>
        /// The nationality.
        /// </value>
        public virtual Location Nationality { get; set; }

        /// <summary>
        /// Gets or sets the nationality identifier.
        /// </summary>
        /// <value>
        /// The nationality identifier.
        /// </value>
        public int? NationalityId { get; set; }

        /// <summary>
        /// Gets or sets the date of birth.
        /// </summary>
        /// <value>
        /// The date of birth.
        /// </value>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Gets the age.
        /// </summary>
        /// <value>
        /// The age.
        /// </value>
        public int Age { get => DateTime.Today.Year - DateOfBirth.Year; } // Might need error handling.

        /// <summary>
        /// Gets the full name.
        /// </summary>
        /// <value>
        /// The full name.
        /// </value>
        public string FullName { get => $"{FirstName} {LastName}"; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            Players = new List<Player>();
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return FullName;
        }
    }
}
